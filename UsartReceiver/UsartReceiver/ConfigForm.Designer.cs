namespace UsartReceiver
{
    partial class ConfigForm
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
            this.comboBoxBoudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBufferStopOrStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxBoudRate
            // 
            this.comboBoxBoudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBoudRate.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxBoudRate.FormattingEnabled = true;
            this.comboBoxBoudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.comboBoxBoudRate.Location = new System.Drawing.Point(178, 23);
            this.comboBoxBoudRate.Name = "comboBoxBoudRate";
            this.comboBoxBoudRate.Size = new System.Drawing.Size(210, 35);
            this.comboBoxBoudRate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "ボー・レート";
            // 
            // buttonBufferStopOrStart
            // 
            this.buttonBufferStopOrStart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonBufferStopOrStart.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonBufferStopOrStart.Location = new System.Drawing.Point(358, 136);
            this.buttonBufferStopOrStart.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonBufferStopOrStart.Name = "buttonBufferStopOrStart";
            this.buttonBufferStopOrStart.Size = new System.Drawing.Size(154, 34);
            this.buttonBufferStopOrStart.TabIndex = 8;
            this.buttonBufferStopOrStart.Text = "キャンセル";
            this.buttonBufferStopOrStart.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(223, 136);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 34);
            this.button1.TabIndex = 9;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 197);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonBufferStopOrStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxBoudRate);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "ConfigForm";
            this.Text = "設定";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxBoudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBufferStopOrStart;
        private System.Windows.Forms.Button button1;
    }
}