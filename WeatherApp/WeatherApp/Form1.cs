using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net.Http; // giao thức HTTP để tải dữ liệu từ API
using System.Threading.Tasks;
using System.Windows.Forms;
using static Weather_Application.WeatherInfo;
using System.Diagnostics;// Thư viện này sẽ giúp chúng ta mở trình duyệt web mặc định của máy tính

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        private Timer timerDateTime;
        private Timer timerWeatherUpdate;
        private string currentCity;
        private string currentCountry;
        private HttpClient httpClient = new HttpClient();
        #region API Key
        private string APIKey = "68d42b9ada53b7dacca41373c7c14a71"; // API key
        #endregion
        public Form1()
        {
            InitializeComponent();
            // Khởi tạo timer cho đồng hồ
            timerDateTime = new Timer { Interval = 1000 };
            timerDateTime.Tick += TimerDateTime_Tick;
            timerDateTime.Start();
            timerWeatherUpdate = new Timer { Interval = 1800000 };
            timerWeatherUpdate.Tick += TimerWeatherUpdate_Tick;
            // Bắt sự kiện khi nhấn Enter trong TextBox thành phố
            TBCity.KeyPress += TBCity_KeyPress;

            // Kiểm tra kết nối internet
            Task<bool> task = CheckInternetConnection();

            // Khởi tạo DataGridView
            InitializeDataGridView();

            // Khởi tạo AutoComplete
            SetupAutoComplete();

        }

        // Kiểm tra kết nối với server OpenWeatherMap
        private async Task<bool> CheckInternetConnection()
        {
            try
            {
                var response = await httpClient.GetAsync("https://openweathermap.org");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                MessageBox.Show("Không thể kết nối với máy chủ, vui lòng kiểm tra kết nối internet",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        // Xử lý sự kiện khi thay đổi nội dung trong TextBox thành phố
        private async Task TBCity_TextChangedAsync(object sender, EventArgs e)
        {
            string input = TBCity.Text.Trim();
            if (input.Length >= 3)
            {
                var suggestions = await GetCitySuggestions(input);
                if (suggestions != null)
                {
                    var autoCompleteCollection = new AutoCompleteStringCollection();
                    autoCompleteCollection.AddRange(suggestions.ToArray());
                    TBCity.AutoCompleteCustomSource = autoCompleteCollection;
                }
            }
            // Xóa dữ liệu cũ khi người dùng xóa hết nội dung trong TextBox
            if (string.IsNullOrEmpty(input))
            {
                TBCity.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            }
        }
        

        // Xử lý sự kiện khi nhấn Enter trong TextBox thành phố
        private async void TimerWeatherUpdate_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentCity))
            {
                await GetWeatherByCity(currentCity);// Lấy thông tin thời tiết theo thành phố
            }
        }

        // Khởi tạo DataGridView
        private void InitializeDataGridView()
        {
            DataGridView grid = new DataGridView(); // Tạo một DataGridView mới
            // Xóa cột cũ và thiết lập cơ bản
            dataGridView1.Columns.Clear();
            dataGridView1.TopLeftHeaderCell.Value = "Thời tiết trong tuần";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Thêm các cột với cấu hình riêng lẻ
            AddTextColumn("DayOfWeek", "Thứ", 50);
            AddTextColumn("Date", "Ngày", 100);
            AddTextColumn("Temperature", "Nhiệt Độ", 30);
            AddTextColumn("Condition", "Trạng Thái", 100);
            AddImageColumn("WeatherIcon", "Biểu Tượng", 30);
        }

        // Thêm cột văn bản
        private void AddTextColumn(string columnName, string headerText, int width)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
            {
                Name = columnName,
                HeaderText = headerText,
                Width = width,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView1.Columns.Add(column);
        }

        // Thêm cột hình ảnh
        private void AddImageColumn(string columnName, string headerText, int width)
        {
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = columnName;
            imageColumn.HeaderText = headerText;
            imageColumn.Width = width;
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageColumn.DefaultCellStyle.BackColor = Color.DodgerBlue;
            dataGridView1.Columns.Add(imageColumn);
        }

        // Xử lý sự kiện khi nhấn nút Search hoặc Enter trong TextBox thành phố
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string city = TBCity.Text.Trim();
            await GetWeatherByCity();
            await CheckInternetConnection();
        }

        // Xử lý sự kiện khi nhấn nút Location
        private async void btnLocation_Click(object sender, EventArgs e)
        {
            await GetCurrentLocationWeather();
            await GetWeatherByCity();
            // Kiểm tra kết nối internet
            await CheckInternetConnection();

        }

        // Xử lý sự kiện khi nhấn Enter trong TextBox thành phố
        private async void TBCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            string input = TBCity.Text.Trim();
            if (e.KeyChar == (char)Keys.Enter)
            {
                await TBCity_TextChangedAsync(sender, e);
                btnSearch.PerformClick();
                e.Handled = true;
            }
        }

        // Khởi tạo AutoComplete
        private void SetupAutoComplete()
        {
            TBCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TBCity.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        // Lấy gợi ý thành phố từ OpenWeatherMap Geo API
        private async Task GetWeatherByCity(string city = null)
        {
            if (city == null)
            {
                city = TBCity.Text.Trim();
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Vui lòng nhập tên thành phố hợp lệ.");
                return;
            }

            try
            {
                // Lấy thông tin thời tiết hiện tại và dự báo
                var currentInfo = await GetCurrentWeather(city);
                var forecastInfo = await GetForecast(city);

                // Cập nhật giao diện
                await UpdateCurrentWeather(currentInfo);
                await UpdateForecast(forecastInfo);

                // Kiểm tra và hiển thị thông báo thiên tai
                foreach (var weather in currentInfo.weather)
                {
                    if (weather.description.Contains("storm") && !stormWarningDisplayed)
                    {
                        stormWarningDisplayed = true;
                        break;
                    }
                    else if (weather.description.Contains("earthquake") && !earthquakeWarningDisplayed)
                    {
                        earthquakeWarningDisplayed = true;
                        break;
                    }
                    else if (weather.description.Contains("tsunami") && !tsunamiWarningDisplayed)
                    {
                        tsunamiWarningDisplayed = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        // Kiểm tra và hiển thị thông báo thiên tai
        private async Task ShowWarningMessage(string message)
        {
            MessageBox.Show(message);
            await Task.Delay(10000);
            stormWarningDisplayed = false;
            earthquakeWarningDisplayed = false;
            tsunamiWarningDisplayed = false;
        }

        // Lấy gợi ý thành phố từ OpenWeatherMap Geo API
        private async Task<List<string>> GetCitySuggestions(string cityName)
        {
            string geoApiUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=5&appid={APIKey}";
            var response = await httpClient.GetStringAsync(geoApiUrl);
            var locations = JsonConvert.DeserializeObject<List<GeoLocation>>(response);
            return locations?.Select(location => $"{location.name}, {location.country}").ToList();
        }

        // Lấy thông tin thời tiết hiện tại từ OpenWeatherMap API
        private async Task<root> GetCurrentWeather(string city)
        {
            string weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={APIKey}";
            var weatherJson = await httpClient.GetStringAsync(weatherUrl);
            return JsonConvert.DeserializeObject<root>(weatherJson);
        }

        // Lấy thông tin dự báo thời tiết từ OpenWeatherMap API
        private async Task<ForecastRoot> GetForecast(string city)
        {
            string forecastUrl = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={APIKey}&lang=vi";
            var forecastJson = await httpClient.GetStringAsync(forecastUrl);
            return JsonConvert.DeserializeObject<ForecastRoot>(forecastJson);
        }

        // Lấy thông tin thời tiết cho vị trí hiện tại
        private async Task GetCurrentLocationWeather()
        {
            try
            {
                string city = await GetCurrentCity();

                // Lấy thông tin thời tiết hiện tại và dự báo
                var currentInfo = await GetCurrentWeather(city);
                var forecastInfo = await GetForecast(city);

                // Cập nhật giao diện
                TBCity.Text = city;
                await UpdateCurrentWeather(currentInfo);
                await UpdateForecast(forecastInfo);
                await Update7DayForecast(forecastInfo);
                Update3HourChart(forecastInfo);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        // Lấy tên thành phố hiện tại dựa trên IP
        private async Task<string> GetCurrentCity()
        {
            string locationUrl = "https://ipinfo.io/json";
            var locationJson = await httpClient.GetStringAsync(locationUrl);
            dynamic locationInfo = JsonConvert.DeserializeObject(locationJson);
            return locationInfo.city;
        }

        // Cập nhật giao diện với thông tin thời tiết hiện tại
        private async Task UpdateCurrentWeather(root currentInfo)
        {
            picIcon.LoadAsync("https://openweathermap.org/img/wn/" + currentInfo.weather[0].icon + ".png");
            //labCondition.Text = currentInfo.weather[0].main;
            //labCondition.Text = currentInfo.weather[0].description;
            labSunset.Text = ConvertDateTime(currentInfo.sys.sunset).ToShortTimeString();
            labSunrise.Text = ConvertDateTime(currentInfo.sys.sunrise).ToShortTimeString();
            labTemp_max.Text = $"{currentInfo.main.temp_max - 273} °C";
            labTemp_min.Text = $"{currentInfo.main.temp_min - 273} °C";
            double tempCelsius = currentInfo.main.temp - 273;
            labTemperature.Text = $"{tempCelsius:0.#}°C";
            labWindSpeed.Text = $"{currentInfo.wind.speed} m/s";
            labPressure.Text = $"{currentInfo.main.pressure} hPa";
            labHumidity.Text = $"{currentInfo.main.humidity} %";
            labFeels_like.Text = $"{currentInfo.main.feels_like - 273} °C";

            string district = await GetDistrict(currentInfo);
            if (!string.IsNullOrEmpty(district))
            {
                labDistrict.Text = district;
                labDistrict.Visible = true;
            }
            else
            {
                labDistrict.Visible = false;
            }

            tempCelsius = currentInfo.main.temp - 273;
            labTemperature.Text = $"{tempCelsius:0.#}°C";

            // Tô màu đỏ nếu nhiệt độ cao
            if (tempCelsius >= 30)
            {
                labTemperature.ForeColor = Color.Red;
            }
            else
            {
                labTemperature.ForeColor = SystemColors.Window; // Màu mặc định
            }

            // Gợi ý địa điểm mát mẻ nếu nhiệt độ cao
            if (tempCelsius > 30)
            {
                string coolPlaces = "Đà Lạt, Sapa, Tam Đảo, Vịnh Hạ Long, Phú Quốc, Nha Trang, Hội An, Huế, Đà Nẵng..."; // Thay bằng danh sách địa điểm mát mẻ
                labCoolPlaces.Text = $"Địa điểm mát mẻ: {coolPlaces}";
                labCoolPlaces.Visible = true;

                // Gợi ý tour du lịch
                string tourSuggestions = "Tour Đà Lạt 3 ngày 2 đêm, Tour Sapa trekking, Tour Hạ Long 2 ngày 1 đêm,...";
                labTourSuggestions.Text = $"Tour gợi ý: {tourSuggestions}";
                labTourSuggestions.Visible = true;

                // Thêm sự kiện click để mở link công ty du lịch 
                labTourSuggestions.Click += (sender, e) =>
                {
                    Process.Start("https://www.vietourist.com.vn/vn/");
                };
                labTourSuggestions.Cursor = Cursors.Hand; // Thay đổi con trỏ chuột để thể hiện là link

            }
            else
            {
                labCoolPlaces.Visible = false;
                labTourSuggestions.Visible = false;
            }

            // Cập nhật hình nền dựa trên điều kiện thời tiết
            UpdateBackground(currentInfo.weather[0].main);

            // Cập nhật lời khuyên dựa trên điều kiện thời tiết
            UpdateWeatherAdvice(currentInfo.weather[0].description.ToLower());
        }

        // Lấy thông tin quận/huyện từ API OpenWeatherMap
        private async Task<string> GetDistrict(root currentInfo)
        {
            if (currentInfo == null || currentInfo.coord == null)
            {
                return null;
            }

            string district = null;
            try
            {
                string url = $"http://api.openweathermap.org/geo/1.0/reverse?lat={currentInfo.coord.lat}&lon={currentInfo.coord.lon}&limit=1&appid={APIKey}";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var locationData = JsonConvert.DeserializeObject<List<GeoLocation>>(responseData);
                    if (locationData != null && locationData.Count > 0)
                    {
                        district = locationData[0].name;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi Không tìm thấy quận huyện!: {ex.Message}");
            }

            return district;
        }


        // Cập nhật hình nền dựa trên điều kiện thời tiết
        private void UpdateBackground(string weatherCondition)
        {
            // Đặt hình nền mặc định là trời nắng
            string backgroundImage = "nang.jpg";
            switch (weatherCondition.ToLower())
            {
                case "clear":
                    backgroundImage = "nang2.jpg"; // Hình nền cho trời quang đãng
                    break;
                case "few clouds":
                    backgroundImage = "may.jpg"; // Hình nền cho trời ít mây
                    break;
                case "light intensity drizzle":
                    backgroundImage = "muaphun.jpg"; // Hình nền cho mưa phùn nhẹ
                    break;
                case "drizzle":
                    backgroundImage = "muaphun.jpg"; // Hình nền cho mưa phùn
                    break;
                case "scattered clouds":
                    backgroundImage = "may.jpg"; // Hình nền cho mây rải rác
                    break;
                case "broken clouds":
                    backgroundImage = "may.jpg"; // Hình nền cho mây nhiều
                    break;
                case "rain":
                    backgroundImage = "mua2.jpg"; // Hình nền cho trời mưa
                    break;
                case "light intensity shower rain":
                    backgroundImage = "muanho.jpg"; // Hình nền cho mưa rào nhỏ
                    break;
                case "shower rain":
                    backgroundImage = "mua2.jpg"; // Hình nền cho mưa rào
                    break;
                case "heavy intensity shower rain":
                    backgroundImage = "mua2.jpg"; // Hình nền cho mưa rào lớn
                    break;
                case "thunderstorm":
                    backgroundImage = "mua2.jpg"; // Hình nền cho trời dông
                    break;
                case "light rain":
                    backgroundImage = "amu.jpg"; // Hình nền cho mưa nhỏ
                    break;
                case "moderate rain":
                    backgroundImage = "amu.jpg"; // Hình nền cho mưa vừa
                    break;
                case "heavy intensity rain":
                    backgroundImage = "mua2.jpg"; // Hình nền cho mưa lớn
                    break;
                case "light shower rain":
                    backgroundImage = "mua2.jpg"; // Hình nền cho mưa rào nhỏ
                    break;
                case "heavy shower rain":
                    backgroundImage = "mua2.jpg"; // Hình nền cho mưa rào lớn
                    break;
                case "clouds":
                    backgroundImage = "troicomay.jpg"; // Hình nền cho trời nhiều mây
                    break;
                case "overcast clouds":
                    backgroundImage = "may.jpg"; // Hình nền cho trời âm u
                    break;
                case "mist":
                    backgroundImage = "suongmu.jpg"; // Hình nền cho sương mù
                    break;
                case "haze":
                    backgroundImage = "amu.jpg"; // Hình nền cho trời mờ
                    break;
                case "snow":
                    backgroundImage = "tuyet.jpg"; // Hình nền cho trời tuyết
                    break;
                case "light snow":
                    backgroundImage = "tuyet.jpg"; // Hình nền cho tuyết nhẹ
                    break;
                case "fog":
                    backgroundImage = "suongmu.jpg"; // Hình nền cho sương mù dày
                    break;
                case "heavy fog":
                    backgroundImage = "suongmu.jpg"; // Hình nền cho sương mù dày đặc
                    break;
                default:
                    backgroundImage = "nang.jpg"; // Hình nền mặc định nếu không rõ điều kiện thời tiết
                    break;
            }
            this.BackgroundImage = Image.FromFile(backgroundImage); // Thiết lập hình nền cho form
            this.BackgroundImageLayout = ImageLayout.Stretch; // Để hình nền căng
        }

        // Cập nhật dữ liệu dự báo thời tiết
        private async Task UpdateForecast(ForecastRoot forecastInfo)
        {
            Update3HourChart(forecastInfo);
            await Update7DayForecast(forecastInfo);
        }

        // Hàm cập nhật dữ liệu cho DataGridView với dự báo 7 ngày
        private async Task Update7DayForecast(ForecastRoot forecastInfo)
        {
            dataGridView1.Rows.Clear();
            // Lấy danh sách dự báo cho 7 ngày tiếp theo
            var dailyForecasts = GetNext7DaysForecasts(forecastInfo);
            List<Task<Bitmap>> imageTasks = new List<Task<Bitmap>>();

            // Xác định thứ đầu tiên (thứ Hai) trong tuần tới
            DateTime currentDate = DateTime.UtcNow.Date;
            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek + 1); // Ngày bắt đầu từ thứ Hai

            for (int day = 0; day < 7; day++)
            {
                DateTime targetDate = startOfWeek.AddDays(day);

                // Tìm dự báo gần nhất cho ngày đó hoặc sao chép dự báo cuối cùng nếu thiếu
                var forecast = dailyForecasts.FirstOrDefault(f => ConvertDateTime(f.dt).Date == targetDate.Date)
                               ?? dailyForecasts.Last(); // Sử dụng dự báo cuối nếu thiếu
                DateTime forecastDateTime = ConvertDateTime(forecast.dt);
                double tempCelsius = forecast.main.temp - 273;
                string condition = forecast.weather[0].description;
                string iconUrl = $"https://openweathermap.org/img/wn/{forecast.weather[0].icon}@2x.png";
                string dayOfWeek = targetDate.ToString("dddd");
                imageTasks.Add(GetImageFromUrl(iconUrl));

                dataGridView1.Rows.Add(
                    dayOfWeek, // Hiển thị tên thứ
                    targetDate.ToShortDateString(),
                    $"{tempCelsius:0.#}°C",
                    condition,
                    null
                );
            }

            // Chờ tất cả các hình ảnh được tải về
            var images = await Task.WhenAll(imageTasks);

            // Cập nhật hình ảnh vào DataGridView
            for (int i = 0; i < images.Length; i++)
            {
                dataGridView1.Rows[i].Cells["WeatherIcon"].Value = images[i];
                dataGridView1.Rows[i].Height = 100; // Điều chỉnh chiều cao hàng cho vừa hình ảnh
                dataGridView1.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa hình ảnh
            }
        }

        // Lấy dữ liệu dự báo cho 7 ngày tiếp theo
        private List<Forecast> GetNext7DaysForecasts(ForecastRoot forecastInfo)
        {
            return forecastInfo.list
                .Where(forecast => DateTimeOffset.
                FromUnixTimeSeconds(forecast.dt).UtcDateTime.Date > DateTime.UtcNow.Date)
                .Take(7)
                .ToList();
        }

        // Lấy dữ liệu dự báo 3 giờ một lần
        private List<Forecast> Get3HourForecasts(ForecastRoot forecastInfo)
        {
            List<Forecast> fourHourForecasts = new List<Forecast>();

            for (int i = 0; i < forecastInfo.list.Count; i += 4)  // Lấy mỗi 4 dự báo
            {
                fourHourForecasts.Add(forecastInfo.list[i]);
            }

            return fourHourForecasts;
        }

        // Cập nhật biểu đồ dự báo 3 giờ
        private void Update3HourChart(ForecastRoot forecastInfo)
        {
            chart1.Series[0].Points.Clear();

            var hourlyForecasts = Get3HourForecasts(forecastInfo);

            DateTime initialForecastTime = DateTime.MinValue;

            for (int i = 0; i < hourlyForecasts.Count; i++)
            {
                var forecast = hourlyForecasts[i];
                DateTime forecastDateTime = ConvertDateTime(forecast.dt);
                double tempCelsius = forecast.main.temp - 273;

                if (initialForecastTime == DateTime.MinValue)
                {
                    initialForecastTime = forecastDateTime;
                }

                chart1.Series[0].Name = "Nhiệt độ";
                chart1.Series[0].Points.AddXY(i, tempCelsius);
                chart1.Series[0].Points[i].ToolTip = $"{forecastDateTime:dd/MM HH:mm}\n{tempCelsius:0.#}°C";
                chart1.Series[0].Points[i].Label = $"{tempCelsius:0.#}°C";

                // Tô màu đỏ nếu nhiệt độ trên 30 độ
                if (tempCelsius >= 30)
                {
                    chart1.Series[0].Points[i].Color = Color.Red; // Tô cột màu đỏ
                }
                else
                {
                    // Màu mặc định
                    chart1.Series[0].Points[i].Color = Color.Blue; 
                }
            }

            // Cập nhật trục X với các nhãn thời gian cách nhau 4 giờ
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0}°C";
            chart1.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 10;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();

            for (int i = 0; i < hourlyForecasts.Count; i++)
            {
                DateTime labelTime = initialForecastTime.AddHours(i * 5);// Cập nhật nhãn thời gian cách nhau 4 giờ
                var label = new System.Windows.Forms.DataVisualization.Charting.CustomLabel
                {
                    Text = labelTime.ToString("HH:mm"),
                    FromPosition = i + 0,  // Bắt đầu từ giữa cột trước
                    ToPosition = i + 0.3,     // Kết thúc ở giữa cột sau
                };
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(label);
            }
        }

        // Lấy dữ liệu hình ảnh từ URL
        private async Task<Bitmap> GetImageFromUrl(string url)
        {
            using (var response = await httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        return new Bitmap(stream);
                    }
                }
                else
                {
                    // Trả về null nếu không thể tải hình ảnh
                    return null;
                }
            }
        }

        // Chuyển đổi Unix Timestamp sang DateTime
        private DateTime ConvertDateTime(long unixTimestamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);
            return dateTimeOffset.DateTime.ToLocalTime();
        }

        // Cập nhật đồng hồ
        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            labDateTime.Text = DateTime.Now.ToString("HH:mm:ss");
            labDateTime2.Text = DateTime.Now.ToString("dddd, dd - M - yyyy");
        }

        // Biến để kiểm tra xem cảnh báo bão đã được hiển thị hay chưa
        private bool stormWarningDisplayed = false; // Cảnh báo bão
        private bool earthquakeWarningDisplayed = false;// Cảnh báo động đất
        private bool tsunamiWarningDisplayed = false;// Cảnh báo sóng thần

        // Hàm để cập nhật lời khuyên
        private void UpdateWeatherAdvice(string condition)
        {
            switch (condition)
            {
                case "light rain":
                    labDetail2.Text = "Mưa nhỏ";
                    labAdvice.Text = "Trời mưa nhỏ, bạn nên mang theo ô đề phòng.";
                    break;
                case "scattered clouds":
                    labDetail2.Text = "Mây rải rác";
                    labAdvice.Text = "Trời có mây rải rác, bạn có thể thoải mái đi lại.";
                    break;
                case "broken clouds":
                    labDetail2.Text = "Mây rải rác";
                    labAdvice.Text = "Trời có mây rải rác, bạn có thể thoải mái đi lại.";
                    break;
                case "light intensity drizzle":
                    labDetail2.Text = "Mưa phùn nhỏ";
                    labAdvice.Text = "Trời mưa phùn nhỏ, bạn nên mang theo ô và áo mưa đề phòng.";
                    break;
                case "drizzle":
                    labDetail2.Text = "Mưa phùn";
                    labAdvice.Text = "Trời mưa phùn, bạn nên mang theo ô đề phòng.";
                    break;
                case "heavy intensity drizzle":
                    labDetail2.Text = "Mưa phùn lớn";
                    labAdvice.Text = "Trời mưa phùn lớn, bạn nên mang theo ô và áo mưa đề phòng.";
                    break;
                case "clear sky":
                    labDetail2.Text = "Trời quang đãng";
                    labAdvice.Text = "Trời quang đãng, bạn có thể thoải mái đi lại.";
                    break;
                case "few clouds":
                    labDetail2.Text = "Ít mây";
                    labAdvice.Text = "Trời có ít mây, bạn có thể thoải mái đi lại.";
                    break;
                case "overcast clouds":
                    labDetail2.Text = "Trời âm u";
                    labAdvice.Text = "Trời có mưa, bạn nên mang theo ô đề phòng.";
                    break;
                case "moderate rain":
                    labDetail2.Text = "Mưa nhỏ";
                    labAdvice.Text = "Trời có sẽ mưa, bạn nên mang theo ô đề phòng.";
                    break;
                case "rain":
                    labDetail2.Text = "Mưa";
                    labAdvice.Text = "Trời mưa, bạn nên mang theo ô đề phòng.";
                    break;
                case "heavy intensity rain":
                    labDetail2.Text = "Mưa lớn";
                    labAdvice.Text = "Trời mưa lớn, bạn nên mang theo ô đề phòng.";
                    break;
                case "snow":
                    labDetail2.Text = "Tuyết";
                    labAdvice.Text = "Trời có tuyết, bạn nên mang theo áo ấm.";
                    break;
                case "mist":
                    labDetail2.Text = "Sương mù";
                    labAdvice.Text = "Trời có sương mù, bạn nên chú ý khi lái xe.";
                    break;
                case "haze":
                    labDetail2.Text = "Sương mù";
                    labAdvice.Text = "Trời có sương mù, bạn nên chú ý khi lái xe.";
                    break;
                case "light intensity shower rain":
                    labDetail2.Text = "Mưa rào";
                    labAdvice.Text = "Trời có mưa rào, bạn nên mang theo ô và áo mưa đề phòng.";
                    break;
                case "shower rain":
                    labDetail2.Text = "Mưa rào";
                    labAdvice.Text = "Trời có mưa rào, bạn nên mang theo ô và áo mưa đề phòng.";
                    break;
                case "heavy intensity shower rain":
                    labDetail2.Text = "Mưa rào lớn";
                    labAdvice.Text = "Trời có mưa rào lớn, bạn nên mang theo ô và áo mưa đề phòng.";
                    break;
                case "fog":
                    labDetail2.Text = "Sương mù";
                    labAdvice.Text = "Trời có sương mù, bạn nên chú ý khi lái xe.";
                    break;
                case "thunderstorm":
                    labDetail2.Text = "Dông";
                    labAdvice.Text = "Trời có dông nguy hiểm, bạn nên ở trong nhà đên khi hết mưa.";
                    MessageBox.Show("Cảnh báo: Có mưa dông! Bạn cẩn thận khi đi ra ngoài.", "Cảnh báo dông", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "clouds":
                    labDetail2.Text = "Mây";
                    labAdvice.Text = "Trời có mây, bạn có thể thoải mái đi lại.";
                    break;
                case "thunderstorm with light rain":
                    labDetail2.Text = "Dông và mưa nhỏ";
                    labAdvice.Text = "Trời có dông với mưa, bạn nên ở trong nhà.";
                    MessageBox.Show("Cảnh báo: Có mưa dông! Bạn cẩn thận khi đi ra ngoài.", "Cảnh báo dông", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "thunderstorm with rain":
                    labDetail2.Text = "Dông và mưa";
                    labAdvice.Text = "Trời có dông với mưa, bạn nên ở trong nhà.";
                    MessageBox.Show("Cảnh báo: Có mưa dông! Bạn cẩn thận khi đi ra ngoài.", "Cảnh báo dông", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "thunderstorm with heavy rain":
                    labDetail2.Text = "Dông với mưa lớn";
                    labAdvice.Text = "Trời có dông và mưa lớn, bạn nên ở trong nhà.";
                    MessageBox.Show("Cảnh báo: Có mưa dông! Bạn cẩn thận khi đi ra ngoài.", "Cảnh báo dông", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "thunderstorm with light drizzle":
                    labDetail2.Text = "Dông với mưa phùn nhỏ";
                    labAdvice.Text = "Trời có dông với mưa, bạn nên ở trong nhà .";
                    break;
                case "thunderstorm with drizzle":
                    labDetail2.Text = "Dông với mưa phùn";
                    labAdvice.Text = "Trời có dông và mưa phùn, bạn nên ở trong nhà.";
                    MessageBox.Show("Cảnh báo: Có mưa dông! Bạn cẩn thận khi đi ra ngoài.", "Cảnh báo dông", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "thunderstorm with heavy drizzle":
                    labDetail2.Text = "Dông với mưa phùn lớn";
                    labAdvice.Text = "Trời có dông và mưa lớn, bạn nên ở trong nhà.";
                    MessageBox.Show("Cảnh báo: Có mưa dông! Bạn cẩn thận khi đi ra ngoài.", "Cảnh báo dông", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "light snow":
                    labDetail2.Text = "Tuyết nhẹ";
                    labAdvice.Text = "Trời có tuyết, bạn nên mang theo áo ấm.";
                    break;
                case "overcast":
                    labDetail2.Text = "Trời âm u";
                    labAdvice.Text = "Trời sẽ có mưa, bạn nên mang theo ô và áo mưa đề phòng.";
                    break;

                // Các trường hợp cảnh báo đặc biệt nguy hiểm!
                case "storm":
                    labDetail2.Text = "BÃO SẮP ĐẾN!";
                    labAdvice.Text = "BÃO ĐANG ĐẾN!, BẠN HÃY TÌM NƠI TRÚ ẨN AN TOÀN!";
                    if (!stormWarningDisplayed)
                    {
                        MessageBox.Show("Cảnh báo: BÃO ĐANG ĐẾN! BẠN HÃY TÌM NƠI TRÚ ẨN AN TOÀN .", "CẢNH BÁO BÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        stormWarningDisplayed = true;
                    }
                    break;
                case "earthquake":
                    labDetail2.Text = "ĐỘNG ĐẤT SẮP ĐẾN!";
                    labAdvice.Text = "SẮP CÓ ĐỘNG ĐẤT, BẠN NÊN TÌM NƠI TRÚ ẨN AN TOÀN!.";
                    if (!earthquakeWarningDisplayed)
                    {
                        MessageBox.Show("Cảnh báo: ĐỘNG ĐẤT ĐANG ĐẾN! BẠN HÃY TÌM NƠI TRÚ ẨN AN TOÀN.", "CẢNH BÁO ĐỘNG ĐẤT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        earthquakeWarningDisplayed = true;
                    }
                    break;
                case "tsunami":
                    labDetail2.Text = "SÓNG THẦN SẮP ĐẾN!";
                    labAdvice.Text = "SẮP CÓ SÓNG THẦN!, BẠN NÊN DI CHUYỂN NƠI LÊN NƠI CAO HƠN, ĐỂ ĐẢM BẢO AN TOÀN!.";
                    if (!tsunamiWarningDisplayed)
                    {
                        MessageBox.Show("Cảnh báo: Sóng thần! Hãy di chuyển đến nơi cao hơn và tránh xa bờ biển.", "Cảnh báo Sóng thần", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tsunamiWarningDisplayed = true;
                    }
                    break;
                default:
                    labDetail2.Text = "Không rõ! Không thể xác định thời tiết hiện tại!";
                    labAdvice.Text = "Thời tiết hiện tại: " + condition;
                    stormWarningDisplayed = false;
                    earthquakeWarningDisplayed = false;
                    tsunamiWarningDisplayed = false;
                    break;
            }
        }
    }
}
