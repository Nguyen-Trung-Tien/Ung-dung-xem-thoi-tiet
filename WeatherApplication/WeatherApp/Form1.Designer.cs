namespace WeatherApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.TBCity = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.labCondition = new System.Windows.Forms.Label();
            this.labDetail = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labSunrise = new System.Windows.Forms.Label();
            this.labTemperature = new System.Windows.Forms.Label();
            this.labSunset = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labPressure = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labWindSpeed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.labDateTime = new System.Windows.Forms.Label();
            this.labDateTime2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labHumidity = new System.Windows.Forms.Label();
            this.labFeels_like = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.labTemp_max = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labTemp_min = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.butExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.butReload = new System.Windows.Forms.Button();
            this.labSeaLevel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labGrndLevel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labCountry = new System.Windows.Forms.Label();
            this.labClouds = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(83, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find City";
            // 
            // TBCity
            // 
            this.TBCity.BackColor = System.Drawing.Color.White;
            this.TBCity.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCity.ForeColor = System.Drawing.Color.Black;
            this.TBCity.Location = new System.Drawing.Point(194, 61);
            this.TBCity.Name = "TBCity";
            this.TBCity.Size = new System.Drawing.Size(611, 36);
            this.TBCity.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(826, 77);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 44);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labCondition
            // 
            this.labCondition.AutoSize = true;
            this.labCondition.BackColor = System.Drawing.Color.Transparent;
            this.labCondition.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCondition.ForeColor = System.Drawing.Color.White;
            this.labCondition.Location = new System.Drawing.Point(190, 89);
            this.labCondition.Name = "labCondition";
            this.labCondition.Size = new System.Drawing.Size(48, 28);
            this.labCondition.TabIndex = 3;
            this.labCondition.Text = "N/A";
            // 
            // labDetail
            // 
            this.labDetail.AutoSize = true;
            this.labDetail.BackColor = System.Drawing.Color.Transparent;
            this.labDetail.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDetail.ForeColor = System.Drawing.Color.White;
            this.labDetail.Location = new System.Drawing.Point(112, 53);
            this.labDetail.Name = "labDetail";
            this.labDetail.Size = new System.Drawing.Size(48, 28);
            this.labDetail.TabIndex = 4;
            this.labDetail.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(18, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sunrise:";
            // 
            // labSunrise
            // 
            this.labSunrise.AutoSize = true;
            this.labSunrise.BackColor = System.Drawing.Color.Transparent;
            this.labSunrise.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSunrise.ForeColor = System.Drawing.Color.Transparent;
            this.labSunrise.Location = new System.Drawing.Point(191, 123);
            this.labSunrise.Name = "labSunrise";
            this.labSunrise.Size = new System.Drawing.Size(48, 28);
            this.labSunrise.TabIndex = 6;
            this.labSunrise.Text = "N/A";
            // 
            // labTemperature
            // 
            this.labTemperature.AutoSize = true;
            this.labTemperature.BackColor = System.Drawing.Color.Transparent;
            this.labTemperature.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTemperature.ForeColor = System.Drawing.Color.Transparent;
            this.labTemperature.Location = new System.Drawing.Point(405, 130);
            this.labTemperature.Name = "labTemperature";
            this.labTemperature.Size = new System.Drawing.Size(167, 146);
            this.labTemperature.TabIndex = 7;
            this.labTemperature.Text = "°C";
            // 
            // labSunset
            // 
            this.labSunset.AutoSize = true;
            this.labSunset.BackColor = System.Drawing.Color.Transparent;
            this.labSunset.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSunset.ForeColor = System.Drawing.Color.Transparent;
            this.labSunset.Location = new System.Drawing.Point(190, 163);
            this.labSunset.Name = "labSunset";
            this.labSunset.Size = new System.Drawing.Size(48, 28);
            this.labSunset.TabIndex = 9;
            this.labSunset.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(18, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 28);
            this.label7.TabIndex = 8;
            this.label7.Text = "Sunset:";
            // 
            // labPressure
            // 
            this.labPressure.AutoSize = true;
            this.labPressure.BackColor = System.Drawing.Color.Transparent;
            this.labPressure.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPressure.ForeColor = System.Drawing.Color.Transparent;
            this.labPressure.Location = new System.Drawing.Point(190, 243);
            this.labPressure.Name = "labPressure";
            this.labPressure.Size = new System.Drawing.Size(48, 28);
            this.labPressure.TabIndex = 13;
            this.labPressure.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(17, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "Pressure:";
            // 
            // labWindSpeed
            // 
            this.labWindSpeed.AutoSize = true;
            this.labWindSpeed.BackColor = System.Drawing.Color.Transparent;
            this.labWindSpeed.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWindSpeed.ForeColor = System.Drawing.Color.Transparent;
            this.labWindSpeed.Location = new System.Drawing.Point(190, 205);
            this.labWindSpeed.Name = "labWindSpeed";
            this.labWindSpeed.Size = new System.Drawing.Size(48, 28);
            this.labWindSpeed.TabIndex = 11;
            this.labWindSpeed.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(17, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 28);
            this.label6.TabIndex = 10;
            this.label6.Text = "Wind Speed :";
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Location = new System.Drawing.Point(251, 139);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(137, 97);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 14;
            this.picIcon.TabStop = false;
            // 
            // labDateTime
            // 
            this.labDateTime.AutoSize = true;
            this.labDateTime.BackColor = System.Drawing.Color.Transparent;
            this.labDateTime.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDateTime.ForeColor = System.Drawing.Color.White;
            this.labDateTime.Location = new System.Drawing.Point(14, 9);
            this.labDateTime.Name = "labDateTime";
            this.labDateTime.Size = new System.Drawing.Size(63, 28);
            this.labDateTime.TabIndex = 16;
            this.labDateTime.Text = "Time:";
            // 
            // labDateTime2
            // 
            this.labDateTime2.AutoSize = true;
            this.labDateTime2.BackColor = System.Drawing.Color.Transparent;
            this.labDateTime2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDateTime2.ForeColor = System.Drawing.Color.White;
            this.labDateTime2.Location = new System.Drawing.Point(83, 9);
            this.labDateTime2.Name = "labDateTime2";
            this.labDateTime2.Size = new System.Drawing.Size(53, 28);
            this.labDateTime2.TabIndex = 17;
            this.labDateTime2.Text = "Day:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.labCountry);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.labGrndLevel);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.labSeaLevel);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.labHumidity);
            this.groupBox1.Controls.Add(this.labFeels_like);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.labTemp_max);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labTemp_min);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(551, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 290);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // labHumidity
            // 
            this.labHumidity.AutoSize = true;
            this.labHumidity.BackColor = System.Drawing.Color.Transparent;
            this.labHumidity.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHumidity.ForeColor = System.Drawing.Color.Transparent;
            this.labHumidity.Location = new System.Drawing.Point(214, 165);
            this.labHumidity.Name = "labHumidity";
            this.labHumidity.Size = new System.Drawing.Size(48, 28);
            this.labHumidity.TabIndex = 17;
            this.labHumidity.Text = "N/A";
            // 
            // labFeels_like
            // 
            this.labFeels_like.AutoSize = true;
            this.labFeels_like.BackColor = System.Drawing.Color.Transparent;
            this.labFeels_like.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFeels_like.ForeColor = System.Drawing.Color.Transparent;
            this.labFeels_like.Location = new System.Drawing.Point(214, 125);
            this.labFeels_like.Name = "labFeels_like";
            this.labFeels_like.Size = new System.Drawing.Size(48, 28);
            this.labFeels_like.TabIndex = 15;
            this.labFeels_like.Text = "N/A";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(26, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 28);
            this.label13.TabIndex = 14;
            this.label13.Text = "Feels Like:";
            // 
            // labTemp_max
            // 
            this.labTemp_max.AutoSize = true;
            this.labTemp_max.BackColor = System.Drawing.Color.Transparent;
            this.labTemp_max.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTemp_max.ForeColor = System.Drawing.Color.Transparent;
            this.labTemp_max.Location = new System.Drawing.Point(214, 91);
            this.labTemp_max.Name = "labTemp_max";
            this.labTemp_max.Size = new System.Drawing.Size(48, 28);
            this.labTemp_max.TabIndex = 13;
            this.labTemp_max.Text = "N/A";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(22, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 28);
            this.label11.TabIndex = 16;
            this.label11.Text = "Humidity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(22, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 28);
            this.label5.TabIndex = 12;
            this.label5.Text = "Temp Max:";
            // 
            // labTemp_min
            // 
            this.labTemp_min.AutoSize = true;
            this.labTemp_min.BackColor = System.Drawing.Color.Transparent;
            this.labTemp_min.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTemp_min.ForeColor = System.Drawing.Color.Transparent;
            this.labTemp_min.Location = new System.Drawing.Point(214, 55);
            this.labTemp_min.Name = "labTemp_min";
            this.labTemp_min.Size = new System.Drawing.Size(48, 28);
            this.labTemp_min.TabIndex = 11;
            this.labTemp_min.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(22, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 28);
            this.label9.TabIndex = 10;
            this.label9.Text = "Temp Min:";
            // 
            // butExit
            // 
            this.butExit.BackColor = System.Drawing.Color.Transparent;
            this.butExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butExit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.ForeColor = System.Drawing.Color.Red;
            this.butExit.Location = new System.Drawing.Point(12, 534);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(64, 35);
            this.butExit.TabIndex = 19;
            this.butExit.Text = "EXIT";
            this.butExit.UseVisualStyleBackColor = false;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.labClouds);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labSunrise);
            this.groupBox2.Controls.Add(this.labSunset);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.labWindSpeed);
            this.groupBox2.Controls.Add(this.labPressure);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labDetail);
            this.groupBox2.Controls.Add(this.labCondition);
            this.groupBox2.ForeColor = System.Drawing.Color.Transparent;
            this.groupBox2.Location = new System.Drawing.Point(88, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 290);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 28);
            this.label2.TabIndex = 22;
            this.label2.Text = "Details:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(18, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 28);
            this.label10.TabIndex = 21;
            this.label10.Text = "Condition:";
            // 
            // butReload
            // 
            this.butReload.BackColor = System.Drawing.Color.Transparent;
            this.butReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butReload.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butReload.ForeColor = System.Drawing.Color.White;
            this.butReload.Location = new System.Drawing.Point(826, 36);
            this.butReload.Name = "butReload";
            this.butReload.Size = new System.Drawing.Size(120, 39);
            this.butReload.TabIndex = 21;
            this.butReload.Text = "Reload";
            this.butReload.UseVisualStyleBackColor = false;
            this.butReload.Click += new System.EventHandler(this.butReload_Click);
            // 
            // labSeaLevel
            // 
            this.labSeaLevel.AutoSize = true;
            this.labSeaLevel.BackColor = System.Drawing.Color.Transparent;
            this.labSeaLevel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSeaLevel.ForeColor = System.Drawing.Color.Transparent;
            this.labSeaLevel.Location = new System.Drawing.Point(214, 207);
            this.labSeaLevel.Name = "labSeaLevel";
            this.labSeaLevel.Size = new System.Drawing.Size(48, 28);
            this.labSeaLevel.TabIndex = 19;
            this.labSeaLevel.Text = "N/A";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(22, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 28);
            this.label12.TabIndex = 18;
            this.label12.Text = "Sea Level:";
            // 
            // labGrndLevel
            // 
            this.labGrndLevel.AutoSize = true;
            this.labGrndLevel.BackColor = System.Drawing.Color.Transparent;
            this.labGrndLevel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGrndLevel.ForeColor = System.Drawing.Color.Transparent;
            this.labGrndLevel.Location = new System.Drawing.Point(214, 245);
            this.labGrndLevel.Name = "labGrndLevel";
            this.labGrndLevel.Size = new System.Drawing.Size(48, 28);
            this.labGrndLevel.TabIndex = 21;
            this.labGrndLevel.Text = "N/A";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(22, 245);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 28);
            this.label14.TabIndex = 20;
            this.label14.Text = " Grnd Level:";
            // 
            // labCountry
            // 
            this.labCountry.AutoSize = true;
            this.labCountry.BackColor = System.Drawing.Color.Transparent;
            this.labCountry.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCountry.ForeColor = System.Drawing.Color.Transparent;
            this.labCountry.Location = new System.Drawing.Point(214, 24);
            this.labCountry.Name = "labCountry";
            this.labCountry.Size = new System.Drawing.Size(48, 28);
            this.labCountry.TabIndex = 22;
            this.labCountry.Text = "N/A";
            // 
            // labClouds
            // 
            this.labClouds.AutoSize = true;
            this.labClouds.BackColor = System.Drawing.Color.Transparent;
            this.labClouds.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labClouds.ForeColor = System.Drawing.Color.Transparent;
            this.labClouds.Location = new System.Drawing.Point(190, 25);
            this.labClouds.Name = "labClouds";
            this.labClouds.Size = new System.Drawing.Size(48, 28);
            this.labClouds.TabIndex = 23;
            this.labClouds.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(18, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 28);
            this.label8.TabIndex = 24;
            this.label8.Text = "Clouds:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(22, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 28);
            this.label16.TabIndex = 22;
            this.label16.Text = "Nation:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1015, 581);
            this.Controls.Add(this.butReload);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labDateTime2);
            this.Controls.Add(this.labDateTime);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.labTemperature);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.TBCity);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WeatherApplication";
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBCity;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label labCondition;
        private System.Windows.Forms.Label labDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labSunrise;
        private System.Windows.Forms.Label labTemperature;
        private System.Windows.Forms.Label labSunset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labPressure;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labWindSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label labDateTime;
        private System.Windows.Forms.Label labDateTime2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labHumidity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labFeels_like;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labTemp_max;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labTemp_min;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button butReload;
        private System.Windows.Forms.Label labSeaLevel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labGrndLevel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labCountry;
        private System.Windows.Forms.Label labClouds;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
    }
}

