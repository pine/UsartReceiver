namespace UsartReceiver
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSerialPortList = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxRawData = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelTextDataLineCount = new System.Windows.Forms.Label();
            this.buttonSaveTextData = new System.Windows.Forms.Button();
            this.buttonGetTextData100 = new System.Windows.Forms.Button();
            this.textBoxTextData = new System.Windows.Forms.TextBox();
            this.buttonGetAllTextData = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonGetCsvData100 = new System.Windows.Forms.Button();
            this.buttonSaveCsvData = new System.Windows.Forms.Button();
            this.labelCsvDataLineCount = new System.Windows.Forms.Label();
            this.dataGridViewCsv = new System.Windows.Forms.DataGridView();
            this.buttonGetAllCsvData = new System.Windows.Forms.Button();
            this.buttonConnectSerialPort = new System.Windows.Forms.Button();
            this.buttonSerialPortListUpdate = new System.Windows.Forms.Button();
            this.timerRawData = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.labelBufferLineCount = new System.Windows.Forms.Label();
            this.buttonBufferClear = new System.Windows.Forms.Button();
            this.buttonBufferStopOrStart = new System.Windows.Forms.Button();
            this.buttonSerialPortConfig = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCsv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "COMポート";
            // 
            // comboBoxSerialPortList
            // 
            this.comboBoxSerialPortList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSerialPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPortList.FormattingEnabled = true;
            this.comboBoxSerialPortList.Location = new System.Drawing.Point(94, 13);
            this.comboBoxSerialPortList.Name = "comboBoxSerialPortList";
            this.comboBoxSerialPortList.Size = new System.Drawing.Size(328, 20);
            this.comboBoxSerialPortList.TabIndex = 1;
            this.comboBoxSerialPortList.SelectionChangeCommitted += new System.EventHandler(this.comboBoxSerialPortList_SelectionChangeCommitted);
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 38400;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 73);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(676, 407);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxRawData);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(668, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生データ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxRawData
            // 
            this.textBoxRawData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRawData.Location = new System.Drawing.Point(3, 3);
            this.textBoxRawData.MaxLength = 0;
            this.textBoxRawData.Multiline = true;
            this.textBoxRawData.Name = "textBoxRawData";
            this.textBoxRawData.ReadOnly = true;
            this.textBoxRawData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRawData.Size = new System.Drawing.Size(662, 375);
            this.textBoxRawData.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelTextDataLineCount);
            this.tabPage3.Controls.Add(this.buttonSaveTextData);
            this.tabPage3.Controls.Add(this.buttonGetTextData100);
            this.tabPage3.Controls.Add(this.textBoxTextData);
            this.tabPage3.Controls.Add(this.buttonGetAllTextData);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(668, 381);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "テキスト";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labelTextDataLineCount
            // 
            this.labelTextDataLineCount.Location = new System.Drawing.Point(457, 6);
            this.labelTextDataLineCount.Name = "labelTextDataLineCount";
            this.labelTextDataLineCount.Size = new System.Drawing.Size(120, 23);
            this.labelTextDataLineCount.TabIndex = 6;
            this.labelTextDataLineCount.Text = "0行";
            this.labelTextDataLineCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSaveTextData
            // 
            this.buttonSaveTextData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveTextData.Location = new System.Drawing.Point(584, 6);
            this.buttonSaveTextData.Name = "buttonSaveTextData";
            this.buttonSaveTextData.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveTextData.TabIndex = 4;
            this.buttonSaveTextData.Text = "保存";
            this.buttonSaveTextData.UseVisualStyleBackColor = true;
            this.buttonSaveTextData.Click += new System.EventHandler(this.buttonSaveTextData_Click);
            // 
            // buttonGetTextData100
            // 
            this.buttonGetTextData100.Location = new System.Drawing.Point(103, 6);
            this.buttonGetTextData100.Name = "buttonGetTextData100";
            this.buttonGetTextData100.Size = new System.Drawing.Size(105, 23);
            this.buttonGetTextData100.TabIndex = 3;
            this.buttonGetTextData100.Text = "最新100行取得";
            this.buttonGetTextData100.UseVisualStyleBackColor = true;
            this.buttonGetTextData100.Click += new System.EventHandler(this.buttonGetTextData100_Click);
            // 
            // textBoxTextData
            // 
            this.textBoxTextData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTextData.Location = new System.Drawing.Point(3, 35);
            this.textBoxTextData.MaxLength = 0;
            this.textBoxTextData.Multiline = true;
            this.textBoxTextData.Name = "textBoxTextData";
            this.textBoxTextData.ReadOnly = true;
            this.textBoxTextData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTextData.Size = new System.Drawing.Size(656, 340);
            this.textBoxTextData.TabIndex = 2;
            // 
            // buttonGetAllTextData
            // 
            this.buttonGetAllTextData.Location = new System.Drawing.Point(3, 6);
            this.buttonGetAllTextData.Name = "buttonGetAllTextData";
            this.buttonGetAllTextData.Size = new System.Drawing.Size(94, 23);
            this.buttonGetAllTextData.TabIndex = 1;
            this.buttonGetAllTextData.Text = "全データ取得";
            this.buttonGetAllTextData.UseVisualStyleBackColor = true;
            this.buttonGetAllTextData.Click += new System.EventHandler(this.buttonGetAllTextData_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonGetCsvData100);
            this.tabPage2.Controls.Add(this.buttonSaveCsvData);
            this.tabPage2.Controls.Add(this.labelCsvDataLineCount);
            this.tabPage2.Controls.Add(this.dataGridViewCsv);
            this.tabPage2.Controls.Add(this.buttonGetAllCsvData);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(668, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CSV";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonGetCsvData100
            // 
            this.buttonGetCsvData100.Location = new System.Drawing.Point(104, 5);
            this.buttonGetCsvData100.Name = "buttonGetCsvData100";
            this.buttonGetCsvData100.Size = new System.Drawing.Size(105, 23);
            this.buttonGetCsvData100.TabIndex = 9;
            this.buttonGetCsvData100.Text = "最新100行取得";
            this.buttonGetCsvData100.UseVisualStyleBackColor = true;
            this.buttonGetCsvData100.Click += new System.EventHandler(this.buttonGetCsvData100_Click);
            // 
            // buttonSaveCsvData
            // 
            this.buttonSaveCsvData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveCsvData.Location = new System.Drawing.Point(587, 6);
            this.buttonSaveCsvData.Name = "buttonSaveCsvData";
            this.buttonSaveCsvData.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveCsvData.TabIndex = 8;
            this.buttonSaveCsvData.Text = "保存";
            this.buttonSaveCsvData.UseVisualStyleBackColor = true;
            this.buttonSaveCsvData.Click += new System.EventHandler(this.buttonSaveCsvData_Click);
            // 
            // labelCsvDataLineCount
            // 
            this.labelCsvDataLineCount.Location = new System.Drawing.Point(461, 5);
            this.labelCsvDataLineCount.Name = "labelCsvDataLineCount";
            this.labelCsvDataLineCount.Size = new System.Drawing.Size(120, 23);
            this.labelCsvDataLineCount.TabIndex = 7;
            this.labelCsvDataLineCount.Text = "0行";
            this.labelCsvDataLineCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewCsv
            // 
            this.dataGridViewCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCsv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCsv.Location = new System.Drawing.Point(4, 34);
            this.dataGridViewCsv.Name = "dataGridViewCsv";
            this.dataGridViewCsv.ReadOnly = true;
            this.dataGridViewCsv.RowTemplate.Height = 21;
            this.dataGridViewCsv.Size = new System.Drawing.Size(661, 343);
            this.dataGridViewCsv.TabIndex = 1;
            this.dataGridViewCsv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewCsv_CellFormatting);
            // 
            // buttonGetAllCsvData
            // 
            this.buttonGetAllCsvData.Location = new System.Drawing.Point(4, 5);
            this.buttonGetAllCsvData.Name = "buttonGetAllCsvData";
            this.buttonGetAllCsvData.Size = new System.Drawing.Size(94, 23);
            this.buttonGetAllCsvData.TabIndex = 0;
            this.buttonGetAllCsvData.Text = "全データ取得";
            this.buttonGetAllCsvData.UseVisualStyleBackColor = true;
            this.buttonGetAllCsvData.Click += new System.EventHandler(this.buttonGetAllCsvData_Click);
            // 
            // buttonConnectSerialPort
            // 
            this.buttonConnectSerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnectSerialPort.Location = new System.Drawing.Point(432, 10);
            this.buttonConnectSerialPort.Name = "buttonConnectSerialPort";
            this.buttonConnectSerialPort.Size = new System.Drawing.Size(75, 23);
            this.buttonConnectSerialPort.TabIndex = 3;
            this.buttonConnectSerialPort.Text = "接続";
            this.buttonConnectSerialPort.UseVisualStyleBackColor = true;
            this.buttonConnectSerialPort.Click += new System.EventHandler(this.buttonConnectSerialPort_Click);
            // 
            // buttonSerialPortListUpdate
            // 
            this.buttonSerialPortListUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSerialPortListUpdate.Location = new System.Drawing.Point(593, 10);
            this.buttonSerialPortListUpdate.Name = "buttonSerialPortListUpdate";
            this.buttonSerialPortListUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonSerialPortListUpdate.TabIndex = 3;
            this.buttonSerialPortListUpdate.Text = "一覧更新";
            this.buttonSerialPortListUpdate.UseVisualStyleBackColor = true;
            this.buttonSerialPortListUpdate.Click += new System.EventHandler(this.buttonSerialPortListUpdate_Click);
            // 
            // timerRawData
            // 
            this.timerRawData.Enabled = true;
            this.timerRawData.Interval = 10;
            this.timerRawData.Tick += new System.EventHandler(this.timerRawData_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "バッファ";
            // 
            // labelBufferLineCount
            // 
            this.labelBufferLineCount.Location = new System.Drawing.Point(97, 40);
            this.labelBufferLineCount.Name = "labelBufferLineCount";
            this.labelBufferLineCount.Size = new System.Drawing.Size(90, 12);
            this.labelBufferLineCount.TabIndex = 5;
            this.labelBufferLineCount.Text = "0行";
            this.labelBufferLineCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonBufferClear
            // 
            this.buttonBufferClear.Location = new System.Drawing.Point(594, 40);
            this.buttonBufferClear.Name = "buttonBufferClear";
            this.buttonBufferClear.Size = new System.Drawing.Size(75, 23);
            this.buttonBufferClear.TabIndex = 6;
            this.buttonBufferClear.Text = "クリア";
            this.buttonBufferClear.UseVisualStyleBackColor = true;
            this.buttonBufferClear.Click += new System.EventHandler(this.buttonBufferClear_Click);
            // 
            // buttonBufferStopOrStart
            // 
            this.buttonBufferStopOrStart.Location = new System.Drawing.Point(513, 40);
            this.buttonBufferStopOrStart.Name = "buttonBufferStopOrStart";
            this.buttonBufferStopOrStart.Size = new System.Drawing.Size(75, 23);
            this.buttonBufferStopOrStart.TabIndex = 7;
            this.buttonBufferStopOrStart.Text = "中断";
            this.buttonBufferStopOrStart.UseVisualStyleBackColor = true;
            this.buttonBufferStopOrStart.Click += new System.EventHandler(this.buttonBufferStopOrStart_Click);
            // 
            // buttonSerialPortConfig
            // 
            this.buttonSerialPortConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSerialPortConfig.Location = new System.Drawing.Point(512, 10);
            this.buttonSerialPortConfig.Name = "buttonSerialPortConfig";
            this.buttonSerialPortConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonSerialPortConfig.TabIndex = 8;
            this.buttonSerialPortConfig.Text = "設定";
            this.buttonSerialPortConfig.UseVisualStyleBackColor = true;
            this.buttonSerialPortConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(676, 480);
            this.Controls.Add(this.buttonSerialPortConfig);
            this.Controls.Add(this.buttonBufferStopOrStart);
            this.Controls.Add(this.buttonBufferClear);
            this.Controls.Add(this.labelBufferLineCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSerialPortListUpdate);
            this.Controls.Add(this.buttonConnectSerialPort);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBoxSerialPortList);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Usart Receiver";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCsv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSerialPortList;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxRawData;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonConnectSerialPort;
        private System.Windows.Forms.Button buttonSerialPortListUpdate;
        private System.Windows.Forms.Timer timerRawData;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonGetAllTextData;
        private System.Windows.Forms.Button buttonGetAllCsvData;
        private System.Windows.Forms.TextBox textBoxTextData;
        private System.Windows.Forms.Button buttonGetTextData100;
        private System.Windows.Forms.Button buttonSaveTextData;
        private System.Windows.Forms.Label labelTextDataLineCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBufferLineCount;
        private System.Windows.Forms.DataGridView dataGridViewCsv;
        private System.Windows.Forms.Button buttonBufferClear;
        private System.Windows.Forms.Label labelCsvDataLineCount;
        private System.Windows.Forms.Button buttonBufferStopOrStart;
        private System.Windows.Forms.Button buttonSaveCsvData;
        private System.Windows.Forms.Button buttonGetCsvData100;
        private System.Windows.Forms.Button buttonSerialPortConfig;
    }
}

