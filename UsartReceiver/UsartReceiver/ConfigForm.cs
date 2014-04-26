using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace UsartReceiver
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 現在の設定を読み込む
        /// </summary>
        private void LoadSettings()
        {
            // 設定されたボーレートを読み込む
            string boudRate = Properties.Settings.Default.SerialBoudRate;
            string boudRateDefault = Properties.Settings.Default.SerialBoudRateDefault;

            // 設定されたのボーレートをコンボボックスから選択する
            this.comboBoxBoudRate.SelectedItem = boudRate;

            // ボーレートの選択が成功していない場合、初期値を選択する
            if (this.comboBoxBoudRate.SelectedIndex == -1)
            {
                this.comboBoxBoudRate.SelectedItem = boudRateDefault;
            }

            // ボーレートの初期値も存在しない場合は、一番上を選択する
            if (this.comboBoxBoudRate.SelectedIndex == -1 && this.comboBoxBoudRate.Items.Count > 0)
            {
                this.comboBoxBoudRate.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// 現在の設定を保存する
        /// </summary>
        private async Task SaveSettings()
        {
            // 現在のフォームの設定を取り出す
            string boudRate = this.comboBoxBoudRate.SelectedItem.ToString();

            // 設定クラスに設定する
            Properties.Settings.Default.SerialBoudRate = boudRate;
            
            // 設定を保存する
            await Task.Run(() =>
            {
                Properties.Settings.Default.Save();
            });
        }

        /// <summary>
        /// フォームがロードされた時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigForm_Load(object sender, EventArgs e)
        {
            this.LoadSettings();
        }

        /// <summary>
        /// フォームが閉じられた時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 「OK」が押されてフォームが閉じる場合
            if (this.DialogResult == DialogResult.OK)
            {
                // 設定を保存する
                await this.SaveSettings();
            }
        }
    }
}
