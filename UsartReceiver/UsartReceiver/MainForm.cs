using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;


namespace UsartReceiver
{
    public partial class MainForm : Form
    {
        private DataTable serialPortList = null;
        private Thread receiveSerialPortThread = null;
        private List<string> receiveLines = new List<string>();
        private List<long> receiveTimes = new List<long>();
        private bool receiveBufferStop = false;

        /// <summary>
        /// 生データとして取得した際の行数
        /// </summary>
        private int rawDataLastCount = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームの初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // シリアルポートの一覧を更新
            this.UpdateSerialPortList();

            // シリアルポートの過去の設定値を引き継ぎ
            this.InheritSerialPortName();
        }

        /// <summary>
        /// シリアルポートの一覧を更新する
        /// </summary>
        private void UpdateSerialPortList()
        {
            this.serialPortList = SerialPortUtility.GetSerialPortsAsDataTable();

            this.comboBoxSerialPortList.DataSource = serialPortList;
            this.comboBoxSerialPortList.DisplayMember = "Caption";
            this.comboBoxSerialPortList.ValueMember = "DeviceID";
        }

        /// <summary>
        /// シリアルポートの過去の設定を引き継ぐ
        /// </summary>
        private void InheritSerialPortName()
        {
            // 以前の設定を読み出す
            var pastSerialPortName = Properties.Settings.Default.SerialPortName;

            if (pastSerialPortName != null)
            {
                for (int i = 0; i < this.serialPortList.Rows.Count; ++i)
                {
                    if (this.serialPortList.Rows[i].Field<string>("DeviceID") == pastSerialPortName)
                    {
                        this.comboBoxSerialPortList.SelectedIndex = i;
                    }
                }
            }
        }


        /// <summary>
        /// シリアルポートへ接続する
        /// </summary>
        private void ConnectSerialPort()
        {
            // 中断
            this.StopReceiveSerialPortThread();
            

            // 既にポートが開かれている場合
            if (serialPort.IsOpen)
            {
                // 閉じる
                serialPort.Close();
            }

            // ポートの情報を設定
            if (!this.SetSerialPortConfig())
            {
                // 失敗
                // エラーメッセージは、上記メソッド内で表示
                return;
            }

            // 接続
            try
            {
                serialPort.Open();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            // 取得した情報を初期化する
            this.ClearSerialPortLines();

            this.receiveSerialPortThread = new Thread(new ThreadStart(this.ReceiveSerialPortThreadStart));
            this.receiveSerialPortThread.Start();
        }

        /// <summary>
        /// シリアルポートに情報を設定する
        /// </summary>
        /// <returns></returns>
        private bool SetSerialPortConfig()
        {
            // ポート名
            string portName = this.comboBoxSerialPortList.SelectedValue as string;

            // ポートの情報が取得できた場合
            if (portName != null)
            {
                this.serialPort.PortName = portName;
            }

            else
            {
                MessageBox.Show(
                    this,
                    "接続するポートが選択されていません。ポート一覧にポートが存在しない場合は、機器が認識されていない可能性があります。",
                    "ポート未選択エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                return false;
            }

            // ボーレート
            string boudRateString = Properties.Settings.Default.SerialBoudRate;
            int boudRate;

            // ボーレートの数値への変換に成功
            if(int.TryParse(boudRateString, out boudRate)){
                this.serialPort.BaudRate = boudRate;
            }
            else
            {
                MessageBox.Show(
                    this,
                    "ボーレートの設定に失敗しました。ボーレートを数値に変換できません。",
                    "ボーレートの設定エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                return false;
            }


            return true;
        }

        private void StopReceiveSerialPortThread()
        {
            if (this.receiveSerialPortThread != null)
            {
                this.receiveSerialPortThread.Abort();
                this.receiveSerialPortThread.Join();
                this.receiveSerialPortThread = null;
            }
        }

        private void ReceiveSerialPortThreadStart()
        {
            // スレッドを中断可能にするため、タイムアウトを設定する
            this.serialPort.ReadTimeout = 0;

            // 無限ループ
            while (true)
            {
                try
                {
                    if (!this.receiveBufferStop)
                    {
                        var line = this.serialPort.ReadLine();

                        this.receiveLines.Add(line);
                        this.receiveTimes.Add(DateTime.Now.Ticks);
                    }
                }
                catch (TimeoutException) { }
                catch (InvalidOperationException) { }
            }
        }

        private void ClearSerialPortLines()
        {
            // データをクリア
            this.receiveLines.Clear();
            this.receiveTimes.Clear();

            // バッファ関係
            this.labelBufferLineCount.Text = "0行";

            // 生データ関係をクリア
            this.rawDataLastCount = 0;
            this.textBoxRawData.Clear();

            // テキストデータをクリア
            this.textBoxTextData.Clear();
            this.labelTextDataLineCount.Text = "0行";

            // CSV 関係をクリア
            this.dataGridViewCsv.Columns.Clear();
        }

        /// <summary>
        /// 生データを追加する
        /// </summary>
        private void AppendRawData()
        {
            if (this.receiveLines.Count > this.rawDataLastCount)
            {
                // 最終行を取得する
                var lastLine = this.receiveLines.Last();

                // 最終行が存在する場合
                if (lastLine != null)
                {
                    // 全行数を取得
                    this.rawDataLastCount = this.receiveLines.Count;

                    // 全行数を表示
                    this.labelBufferLineCount.Text = this.rawDataLastCount + "行";

                    // データを追加
                    this.textBoxRawData.AppendText(lastLine);
                    this.textBoxRawData.AppendText(Environment.NewLine);
                }
            }
        }

        private Tuple<List<string>, List<long>> GetData(int limit)
        {
            // 現在の個数を取得
            var count = this.receiveLines.Count;
            var start = count - limit;

            if (start < 0)
            {
                start = 0;
                limit = count;
            }

            var lines = this.receiveLines.GetRange(start, limit);
            var times = this.receiveTimes.GetRange(start, limit);

            return new Tuple<List<string>, List<long>>(lines, times);
        }

        private Task<Tuple<List<string>, List<long>>> GetDataAsync(int limit)
        {
            return Task.Run<Tuple<List<string>, List<long>>>(() => this.GetData(limit));
        }

        /// <summary>
        /// 取得した情報をテキストデータとして取得する
        /// </summary>
        private Tuple<string, int> GetTextData(int limit)
        {
            // データを取得
            var result = this.GetData(limit);

            return new Tuple<string, int>(
                string.Join(Environment.NewLine, result.Item1), // 改行で連結
                result.Item1.Count // データの個数
                );
        }

        private Task<Tuple<string, int>> GetTextDataAsync(int limit)
        {
            return Task.Run<Tuple<string, int>>(() => this.GetTextData(limit));
        }

        /// <summary>
        /// 取得した情報を CSV データとして取得する
        /// </summary>
        /// <param name="limit">取得する最大データ数</param>
        /// <returns></returns>
        private async Task<DataTable> GetCsvDataAsync(int limit = int.MaxValue)
        {
            // データを取得
            var dataResult = await this.GetDataAsync(limit);
            var lines = dataResult.Item1;
            var times = dataResult.Item2;

            // CSV 解析する
            var csvResult = this.ParseCsv(lines);
            var csvLines = csvResult.Item1;
            var maxColumnCount = csvResult.Item2;

            // データテーブル
            var dataTable = new DataTable();

            // データテーブルのカラムを追加
            dataTable.Columns.Add("番号", typeof(int));
            dataTable.Columns.Add("時刻", typeof(DateTime));

            // 現在のカラム数を取得
            var constColumnCount = dataTable.Columns.Count;

            for (int i = 0; i < maxColumnCount; ++i)
            {
                dataTable.Columns.Add("項目" + (i + 1), typeof(string));
            }

            for (int i = 0; i < lines.Count; ++i)
            {
                var row = dataTable.NewRow();

                row["番号"] = i;
                row["時刻"] = new DateTime(times[i]);

                for(int j = 0; j < csvLines[i].Length; ++j){
                    row[j + constColumnCount] = csvLines[i][j];
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private Tuple<List<string[]>, int> ParseCsv(List<string> lines){
            var csvLines = new List<string[]>();

            int maxColumnCount = 0;

            foreach (var line in lines)
            {
               
                // CSV ファイルとして解析
                var fields = line.Split(',');

                // 空白を削除
                for (var i = 0; i < fields.Length; ++i)
                {
                    fields[i] = fields[i].Trim();
                }

                // 項目一覧を保存
                csvLines.Add(fields);

                // 最大カラム数を更新
                maxColumnCount = Math.Max(maxColumnCount, fields.Length);
            }

            return new Tuple<List<string[]>, int>(csvLines, maxColumnCount);
        }

        /// <summary>
        /// 取得したデータをテキストデータとして表示する
        /// </summary>
        /// <param name="limit">表示するデータの個数</param>
        private async void DrawTextData(int limit = int.MaxValue)
        {
            var result = await this.GetTextDataAsync(limit);

            this.textBoxTextData.Text = result.Item1;
            this.textBoxTextData.FocusWithoutSelecting();
            this.labelTextDataLineCount.Text = result.Item2 + "行";
        }

        /// <summary>
        /// 取得したデータを CSV データとして表示する
        /// </summary>
        /// <param name="limit">表示するデータの個数</param>
        private async void DrawCsvData(int limit = int.MaxValue)
        {
            var result = await this.GetCsvDataAsync(limit);

            this.dataGridViewCsv.DataSource = result;
            this.labelCsvDataLineCount.Text = result.Rows.Count + "行";
            this.dataGridViewCsv.Focus();
        }


        private void SaveTextData()
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "テキストファイル (*.txt)|*.txt|すべてのファイル (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = dialog.OpenFile())
                    {

                        if (stream != null)
                        {
                            using (var sw = new StreamWriter(stream))
                            {
                                sw.Write(this.textBoxTextData.Text);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CSV 形式のデータを保存する
        /// </summary>
        private void SaveCsvData()
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV ファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = dialog.OpenFile())
                    {

                        if (stream != null)
                        {
                            using (var sw = new StreamWriter(stream))
                            {
                                for(int i = 0; i < this.dataGridViewCsv.Rows.Count; ++i)
                                {
                                    for (int j = 0; j < this.dataGridViewCsv.Columns.Count; ++j)
                                    {
                                        if (j > 0)
                                        {
                                            sw.Write(',');
                                        }

                                        var cell = this.dataGridViewCsv.Rows[i].Cells[j];
                                        var formattedValue = cell.FormattedValue;

                                        sw.Write(formattedValue);
                                    }

                                    sw.Write(Environment.NewLine);
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// バッファを開始、もしくは停止する
        /// </summary>
        private void BuffereStopOrStart()
        {
            if (this.receiveBufferStop)
            {
                this.receiveBufferStop = false;
                this.buttonBufferStopOrStart.Text = "中断";
            }

            else
            {
                this.receiveBufferStop = true;
                this.buttonBufferStopOrStart.Text = "再開";
            }
        }
        
        /// <summary>
        /// 設定画面を表示する
        /// </summary>
        private void ShowConfigForm()
        {
            using (var form = new ConfigForm())
            {
                form.ShowDialog(this);
            }

        }

        private void buttonSerialPortListUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateSerialPortList();
        }

        private void buttonConnectSerialPort_Click(object sender, EventArgs e)
        {
            this.ConnectSerialPort();
        }

        private void timerRawData_Tick(object sender, EventArgs e)
        {
            this.AppendRawData();
        }

        private void buttonGetAllTextData_Click(object sender, EventArgs e)
        {
            this.DrawTextData();
        }

        private void buttonGetTextData100_Click(object sender, EventArgs e)
        {
            this.DrawTextData(100);
        }

        /// <summary>
        /// すべての CSV データを表示するボタンのイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetAllCsvData_Click(object sender, EventArgs e)
        {
            this.DrawCsvData();
        }

        private void buttonGetCsvData100_Click(object sender, EventArgs e)
        {
            this.DrawCsvData(100);
        }

        private void dataGridViewCsv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name == "時刻")
            {
                e.CellStyle.Format = "yyyy/MM/dd hh:mm:ss.ff";
            }
        }



        private void buttonBufferClear_Click(object sender, EventArgs e)
        {
            this.ClearSerialPortLines();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // スレッドを停止する
            this.StopReceiveSerialPortThread();
        }

        private void comboBoxSerialPortList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var serialPortName = this.comboBoxSerialPortList.SelectedValue;

            if (serialPortName is string)
            {
                ThreadPool.QueueUserWorkItem((WaitCallback)delegate(object o)
                {
                    Properties.Settings.Default.SerialPortName = (string)serialPortName;
                    Properties.Settings.Default.Save();
                });
            }
        }

        private void buttonBufferStopOrStart_Click(object sender, EventArgs e)
        {
            this.BuffereStopOrStart();
        }

        /// <summary>
        /// テキストデータを保存するボタンのイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveTextData_Click(object sender, EventArgs e)
        {
            this.SaveTextData();
        }

        /// <summary>
        /// CSV データを保存するボタンのイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveCsvData_Click(object sender, EventArgs e)
        {
            this.SaveCsvData();
        }

        /// <summary>
        /// 設定ボタンがクリックされた時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfig_Click(object sender, EventArgs e)
        {
            // 設定画面を表示する
            this.ShowConfigForm();
        }
    }
}
