using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using Weather_Application;
using static Weather_Application.WeatherInfo;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        private Timer timerDateTime;
        public Form1()
        {
            InitializeComponent();
            timerDateTime = new Timer();
            timerDateTime.Interval = 1000;
            timerDateTime.Tick += TimerDateTime_Tick;
            timerDateTime.Tick += TimerDateTime_Tick2;
            timerDateTime.Start();
            // Gọi hàm getWeather() khi nhấn nút Search
            TBCity.KeyPress += TBCity_KeyPress;

            // Gọi hàm lấy vị trí hiện tại
            GetCurrentLocationWeather();

        }

        // API key
        string APIKey = "68d42b9ada53b7dacca41373c7c14a71";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();
        }

        private void TBCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem phím nhấn có phải là phím Enter hay không
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Gọi hàm getWeather() khi nhấn Enter
                getWeather();
                e.Handled = true; // Ngăn chặn âm thanh nhấn phím Enter
            }
        }

        private async void GetCurrentLocationWeather()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    // Lấy vị trí hiện tại qua IP
                    string locationUrl = "https://ipinfo.io/json";
                    var locationJson = await web.DownloadStringTaskAsync(locationUrl);
                    dynamic locationInfo = JsonConvert.DeserializeObject(locationJson);

                    // Tách kinh độ và vĩ độ
                    string[] latlong = locationInfo.loc.ToString().Split(',');
                    string latitude = latlong[0];
                    string longitude = latlong[1];

                    // Hiển thị tên thành phố hiện tại
                    TBCity.Text = locationInfo.city;

                    // Gọi API thời tiết với kinh độ và vĩ độ
                    string weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={APIKey}";
                    var json = await web.DownloadStringTaskAsync(weatherUrl);
                    WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                    // Cập nhật thông tin giao diện
                    picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                    labCondition.Text = Info.weather[0].main;
                    labDetail.Text = Info.weather[0].description;
                    labSunset.Text = convertDatime(Info.sys.sunset).ToShortTimeString();
                    labSunrise.Text = convertDatime(Info.sys.sunrise).ToShortTimeString();
                    labTemp_max.Text = $"{Info.main.temp_max - 273.15} °C";
                    labTemp_min.Text = $"{Info.main.temp_min - 273.15} °C";
                    double tempCelsius = Info.main.temp - 273.15;
                    labTemperature.Text = $"{tempCelsius:0.#}°C";
                    labWindSpeed.Text = $"{Info.wind.speed} m/s";
                    labPressure.Text = $"{Info.main.pressure} hPa";
                    labHumidity.Text = $"{Info.main.humidity} %";
                    labFeels_like.Text = $"{Info.main.feels_like - 273.15} °C";     
                    labSeaLevel.Text = $"{Info.main.sea_level} hPa";
                    labGrndLevel.Text = $"{Info.main.grnd_level} hPa";
                    labCountry.Text = Info.sys.country;
                    labClouds.Text = $"{Info.clouds.all} %";
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error fetching current location weather data: " + ex.Message);
            }
        }

       private async void getWeather()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    string city = TBCity.Text.Trim();

                    if (string.IsNullOrWhiteSpace(city))
                    {
                        MessageBox.Show("Please enter a valid city name.");
                        return; // Thoát khỏi phương thức nếu tên thành phố rỗng
                    }

                    string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", TBCity.Text, APIKey);
                    var json = await web.DownloadStringTaskAsync(url);
                    WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                    // Cập nhật thông tin thời tiết
                    picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                    labCondition.Text = Info.weather[0].main;
                    labDetail.Text = Info.weather[0].description;
                    labSunset.Text = convertDatime(Info.sys.sunset).ToShortTimeString();
                    labSunrise.Text = convertDatime(Info.sys.sunrise).ToShortTimeString();
                    labTemp_max.Text = $"{Info.main.temp_max - 273.15} °C";
                    labTemp_min.Text = $"{Info.main.temp_min - 273.15} °C";
                    double tempCelsius = Info.main.temp - 273.15;
                    labTemperature.Text = $"{tempCelsius:0.#}°C";
                    labWindSpeed.Text = $"{Info.wind.speed} m/s";
                    labPressure.Text = $"{Info.main.pressure} hPa";
                    labHumidity.Text = $"{Info.main.humidity} %";
                    labFeels_like.Text = $"{Info.main.feels_like - 273.15} °C";
                    labSeaLevel.Text = $"{Info.main.sea_level} hPa";
                    labGrndLevel.Text = $"{Info.main.grnd_level} hPa";
                    labCountry.Text = Info.sys.country;
                    labClouds.Text = $"{Info.clouds.all} %";
                    

                }
            }

            catch (WebException webEx)
            {
                MessageBox.Show("Error fetching weather data: " + webEx.Message);
            }

            catch (JsonException jsonEx)
            {
                MessageBox.Show("Error parsing weather data: " + jsonEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }

            finally
            {
                TBCity.Clear(); //xoá dữ liệu trong ô tìm kiếm
            }


        }

        DateTime convertDatime(long millisec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisec).ToLocalTime();
            return day;
        }

        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            labDateTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void TimerDateTime_Tick2(object sender, EventArgs e)
        {
            labDateTime2.Text = DateTime.Now.ToString("dddd, dd - M - yyyy");
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void butReload_Click(object sender, EventArgs e)
        {
            try
            {
                GetCurrentLocationWeather();
                MessageBox.Show("Reload successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}