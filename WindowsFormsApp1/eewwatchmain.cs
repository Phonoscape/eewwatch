using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;
using Newtonsoft.Json;
using System.Speech.Synthesis;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Text;

using Bouyomi;

namespace eewwatch
{
    public partial class eewwatchmain : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int VkKeyScan(char ch);

        //       static String URI = "http://www.kmoni.bosai.go.jp/new/webservice/hypo/eew/";
        static String URI = "http://www.kmoni.bosai.go.jp/webservice/hypo/eew/";
        Task<String> msg;
        Eew eew;

        HttpClient web;

        int warn;
        int interval;

        string Message;
        string Report_time;
        string Region_name;
        string Longitude;
        string Depth;
        string Latitude;
        string Magunitude;
        string Calcintensity;
        int Report_num;
        string Report_id;
        string Report_id_old = "";
        bool Is_cancel;
        bool Is_final;
        bool Is_training;
        string Alertflg;

        private string outputPath; 

        private Point normalLocation;
        private Size normalSize;

        System.Diagnostics.Process TvtestProcess;
        System.Diagnostics.Process BouyomiProcess;

        SpeechSynthesizer sss = null;

        static int WM_KEYDOWN = 0x0100;
        static int WM_KEYUP = 0x0101;
        static int WM_SYSKEYDOWN = 0x0104;
        static int WM_COMMAND = 0x0111;

        static int VK_SHIFT = 0x10;
        static int VK_CONTROL = 0x11;
        static int VK_MENU = 0x12;
        static int VK_SPACE = 0x20;

        static int CM_RECORD = 150;
        static int CM_RECORD_START = 151;
        static int CM_RECORD_STOP = 152;
        static int CM_RECORD_PAUSE = 153;
        static int CM_RECORDOPTION = 154;
        static int CM_RECORDEVENT = 155;

        static int INTERVAL_WAIT = 2000;
        static int INTERVAL_ACTIVE = 1000;
        static int INTERVAL_CHANGE_RECMODE = 10;
        //static int INTERVAL_CHANGE_RECMODE = 10000;

        public eewwatchmain()
        {
            InitializeComponent();

            warn = 0;
            interval = INTERVAL_WAIT;

            statusStrip1.Items.Add("");
            statusStrip1.Items[0].Width = 30;
            statusStrip1.Items.Add("");
            statusStrip1.Items[1].Width = 30;

            listView1.Columns.Add("Report_id", "レポートID");
            listView1.Columns.Add("Report_time", "日時");
            listView1.Columns.Add("Report_num", "レポート番号");
            listView1.Columns.Add("Alertflg", "情報種");
            listView1.Columns.Add("Is_final", "終了");
            listView1.Columns.Add("Region_name", "地域");
            listView1.Columns.Add("Magunitude", "マグニチュード");
            listView1.Columns.Add("Depth", "深さ");
            listView1.Columns.Add("Calcintensity", "予想最大震度");
            listView1.Columns.Add("Longitude", "経度");
            listView1.Columns.Add("Latitude", "緯度");

            this.Location = EEWWatch.Properties.Settings.Default.Form_Location;
            this.Size = EEWWatch.Properties.Settings.Default.Form_Size;

            this.splitContainer1.SplitterDistance = EEWWatch.Properties.Settings.Default.Splitter_Distance;

            listView1.Columns[0].Width = EEWWatch.Properties.Settings.Default.Column1;
            listView1.Columns[1].Width = EEWWatch.Properties.Settings.Default.Column2;
            listView1.Columns[2].Width = EEWWatch.Properties.Settings.Default.Column3;
            listView1.Columns[3].Width = EEWWatch.Properties.Settings.Default.Column4;
            listView1.Columns[4].Width = EEWWatch.Properties.Settings.Default.Column5;
            listView1.Columns[5].Width = EEWWatch.Properties.Settings.Default.Column6;
            listView1.Columns[6].Width = EEWWatch.Properties.Settings.Default.Column7;
            listView1.Columns[7].Width = EEWWatch.Properties.Settings.Default.Column8;
            listView1.Columns[8].Width = EEWWatch.Properties.Settings.Default.Column9;
            listView1.Columns[9].Width = EEWWatch.Properties.Settings.Default.Column10;
            listView1.Columns[10].Width = EEWWatch.Properties.Settings.Default.Column11;

            outputPath = Application.StartupPath;

            //            if (sss != null)
            //            {
            //                sss.SpeakAsyncCancelAll();
            //sss = null;
            //}

            //sss.SpeakAsyncCancelAll();

            //sss = new SpeechSynthesizer();

            //sss.SelectVoiceByHints(VoiceGender.Female);
            //sss.Rate = 2;

            web = new HttpClient();

            talk("緊急地震速報の受信を開始しました。");

            timer1.Interval = interval;
            timer1.Start();
            recModeTimer.Stop();

            //Test
            //recTv();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            var date = System.DateTime.Now;

            String filename;

            filename = String.Format(
                "{0}{1:00}{2:00}{3:00}{4:00}{5:00}{6:00}.json",
                URI,
                date.Year,
                date.Month,
                date.Day,
                date.Hour,
                date.Minute,
                date.Second);
       
/*            filename = String.Format(
                "{0}{1:00}{2:00}{3:00}{4:00}{5:00}{6:00}.json",
                URI,
                2021,
                2,
                13,
                23,
                8,
                0);
*/
            var res = GetWebAsync(filename);

            textBox1.Clear();

            if (res)
            {
                textBox1.Text = msg.Result.ToString();

                if (Report_id != "")
                {
                    addList();
                    Report_id_old = Report_id;
                }
                else if (Report_id_old != "")
                {
                    talk("緊急地震速報の通知が終了しました");
                    Report_id_old = "";
                }
            }

            statusStrip1.Items[0].Text = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}",
                date.Year,
                date.Month,
                date.Day,
                date.Hour,
                date.Minute,
                date.Second);

            statusStrip1.Items[1].Text = warn > 0 ? "入電中" : "待機中";

            timer1.Interval = interval;
            timer1.Start();
        }

        private Boolean GetWebAsync(string filename)
        {
            try
            {
                msg = web.GetStringAsync(filename);
            }
            catch (HttpRequestException e)
            {
                Message = "データがありません";
                return false;
            }

            try
            {
                if (msg.Result != null)
                {
                    eew = JsonConvert.DeserializeObject<Eew>(msg.Result.ToString());

                    Message = eew.Result.Message;
                    Report_time = eew.Report_time;
                    Region_name = eew.Region_name;
                    Longitude = eew.Longitude;
                    Depth = eew.Depth;
                    Latitude = eew.Latitude;
                    Magunitude = eew.Magunitude;
                    Calcintensity = eew.Calcintensity;
                    Report_num = eew.Report_num == "" ? 0 : int.Parse(eew.Report_num);
                    Report_id = eew.Report_id;
                    Is_cancel = eew.Is_cancel == "" ? false : bool.Parse(eew.Is_cancel);
                    Is_final = eew.Is_final == "" ? false : bool.Parse(eew.Is_final);
                    Alertflg = eew.Alertflg;
                    Is_training = eew.Is_training == "" ? false : bool.Parse(eew.Is_training);
                }
                else
                {
                    Message = "データがありません";
                    return false;
                }
            }
            catch(Exception e)
            {
                Message = "データ取得エラー";
                //Message = "データがありません";
                return false;
            }

            return true;
        }

        private void addList()
        {
            string[] val = new string[11];
            val[0] = Report_id;
            val[1] = Report_time;
            val[2] = Report_num.ToString();
            val[3] = Alertflg;
            val[4] = Is_final == true ? "解除" : "継続";
            val[5] = Region_name;
            val[6] = Magunitude;
            val[7] = Depth;
            val[8] = Calcintensity;
            val[9] = Longitude;
            val[10] = Latitude;

            for (int i=0;i<listView1.Items.Count;i++)
            {
                if ( listView1.Items[i].Text == Report_id )
                {
                    if (listView1.Items[i].SubItems[3].Text != Alertflg)
                    {
                        if (Alertflg == "警報" )
                        {
                            recTv();
                        }

                        talk("緊急地震速報が" + Alertflg + "、になりました。");
                    }

                    if (listView1.Items[i].SubItems[6].Text != Magunitude && Convert.ToDouble(listView1.Items[i].SubItems[6].Text) < 5.0 && Convert.ToDouble(Magunitude) >= 5.0)
                    {
                        talk("マグニチュードが、5.0、を超えました");
                    }

                    if (listView1.Items[i].SubItems[4].Text == "継続" && Is_final)
                    {
                        //warn--;
                        //if ( warn <= 0 )
                        //{
                            warn = 0;
                            interval = INTERVAL_WAIT;
                        //}
                        //talk("緊急地震速報が解除されました。");
                        talk("最終報が通知されました。");
                    }

                    if (listView1.Items[i].SubItems[2].Text != Report_num.ToString())
                    {
//                       if ( !Directory.Exists(outputPath+"\\log"))
//                       {
//                           Directory.CreateDirectory(outputPath + "\\log");
//                       }

                        Encoding enc2 = Encoding.UTF8;
                        StreamWriter writer2 = new StreamWriter(outputPath + "\\log\\" + Report_id.ToString() + ".txt", true, enc2);
//                        writer2.WriteLine(msg.Result.ToString() + Environment.NewLine);
                        writer2.WriteLine(msg.Result.ToString());
                        writer2.Close();
                    }

                    listView1.Items[i].SubItems[0].Text = Report_id;
                    listView1.Items[i].SubItems[1].Text = Report_time;
                    listView1.Items[i].SubItems[2].Text = Report_num.ToString();

                    if (Is_training)
                    {
                        listView1.Items[i].SubItems[3].Text = "訓練";
                    }
                    else
                    {
                        listView1.Items[i].SubItems[3].Text = Alertflg;
                    }

                    if (Is_cancel)
                    {
                        if (listView1.Items[i].SubItems[4].Text != "キャンセル" )
                        {
                            talk("緊急地震速報が、キャンセルされました。");
                        }
                        listView1.Items[i].SubItems[4].Text = "キャンセル";
                    }
                    else
                    {
                        listView1.Items[i].SubItems[4].Text = Is_final == true ? "解除" : "継続";
                    }

                    listView1.Items[i].SubItems[5].Text = Region_name;
                    listView1.Items[i].SubItems[6].Text = Magunitude;
                    listView1.Items[i].SubItems[7].Text = Depth;
                    listView1.Items[i].SubItems[8].Text = Calcintensity;
                    listView1.Items[i].SubItems[9].Text = Longitude;
                    listView1.Items[i].SubItems[10].Text = Latitude;

                    return;
                }
            }

            // 初報登録
            if (!Directory.Exists(outputPath + "\\log"))
            {
                Directory.CreateDirectory(outputPath + "\\log");
            }

            Encoding enc = Encoding.UTF8;
            StreamWriter writer = new StreamWriter(outputPath + "\\log\\" + Report_id.ToString() + ".txt", true, enc);
//            writer.WriteLine(msg.Result.ToString() + Environment.NewLine);
            writer.WriteLine(msg.Result.ToString());
            writer.Close();

            // listView1.Items.Add(new ListViewItem(val));
            listView1.Items.Insert(0, new ListViewItem(val));

            if (Is_training)
            {
                talk(Region_name + "訓練の緊急地震速報、" + Alertflg + "、が発表されました。");
            }
            else
            {
                talk(Region_name + "でマグニチュード" + Magunitude + "、予想最大震度" + Calcintensity + "の" + Alertflg + "が発表されました。");

                if (Alertflg == "警報")
                {
                    recTv();
                }
            }

            if (!Is_final)
            {
                warn = 1;
                interval = INTERVAL_ACTIVE;
            }
        }

        private void talk(string text)
        {
            BouyomiProcess = null;

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                Console.WriteLine(p.ProcessName);
                //メインウィンドウのタイトルがある時だけ列挙する
                if (p.ProcessName == "BouyomiChan")
                {
                    BouyomiProcess = p;
                    break;
                }
            }

            if (BouyomiProcess == null)
            {
                sss = new SpeechSynthesizer();

                sss.SelectVoiceByHints(VoiceGender.Female);
                sss.Rate = 2;

                sss.SpeakAsync(text);
            } else
            {
                Bouyomi.Bouyomi bouyomi = new Bouyomi.Bouyomi();
                bouyomi.Talk(text);
            }
        }

        private void recTv()
        {
            // ウィンドウを探す
            TvtestProcess = null;

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                //メインウィンドウのタイトルがある時だけ列挙する
                if (p.ProcessName == "TVTest")
                {
                    TvtestProcess = p;
                    break;
                }
            }

            if (TvtestProcess == null) return;
            IntPtr hwnd = TvtestProcess.MainWindowHandle;

            // 録画ボタンの押下を送信
            //PostMessage(hwnd, WM_KEYDOWN, 0x11, 0);
            //PostMessage(hwnd, WM_KEYDOWN, VkKeyScan('r'), 0);
            SendMessage(hwnd, WM_COMMAND, CM_RECORD, 0);

            talk("録画を開始しました");
            Task.Factory.StartNew(() => MessageBox.Show("録画を開始しました。"));

            recModeTimer.Interval = INTERVAL_CHANGE_RECMODE * 60 * 1000;
            recModeTimer.Start();
        }

        private void recModeTimer_Tick(object sender, EventArgs e)
        {
            recModeTimer.Stop();

            if (TvtestProcess == null) return;
            IntPtr hwnd = TvtestProcess.MainWindowHandle;

            // 録画ボタンの押下を送信
            SendMessage(hwnd, WM_COMMAND, CM_RECORDEVENT, 0);
            
            talk("録画を番組の終了までにしました");
            Task.Factory.StartNew(() => MessageBox.Show("録画を番組の終了までにしました。"));
        }

        private void eewwatchmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                EEWWatch.Properties.Settings.Default.Form_Location = this.Location;
                EEWWatch.Properties.Settings.Default.Form_Size = this.Size;
            }
            else
            {
                EEWWatch.Properties.Settings.Default.Form_Location = this.RestoreBounds.Location;
                EEWWatch.Properties.Settings.Default.Form_Size = this.RestoreBounds.Size;
            }

            EEWWatch.Properties.Settings.Default.Splitter_Distance = this.splitContainer1.SplitterDistance;

            EEWWatch.Properties.Settings.Default.Column1 = listView1.Columns[0].Width;
            EEWWatch.Properties.Settings.Default.Column2 = listView1.Columns[1].Width;
            EEWWatch.Properties.Settings.Default.Column3 = listView1.Columns[2].Width;
            EEWWatch.Properties.Settings.Default.Column4 = listView1.Columns[3].Width;
            EEWWatch.Properties.Settings.Default.Column5 = listView1.Columns[4].Width;
            EEWWatch.Properties.Settings.Default.Column6 = listView1.Columns[5].Width;
            EEWWatch.Properties.Settings.Default.Column7 = listView1.Columns[6].Width;
            EEWWatch.Properties.Settings.Default.Column8 = listView1.Columns[7].Width;
            EEWWatch.Properties.Settings.Default.Column9 = listView1.Columns[8].Width;
            EEWWatch.Properties.Settings.Default.Column10 = listView1.Columns[9].Width;
            EEWWatch.Properties.Settings.Default.Column11 = listView1.Columns[10].Width;

            EEWWatch.Properties.Settings.Default.Save();
        }

        private void eewwatchmain_Load(object sender, EventArgs e)
        {
            //normalLocation = this.Location;
            //normalSize = this.Size;
        }

        private void eewwatchmain_StyleChanged(object sender, EventArgs e)
        {

        }

        private void eewwatchmain_Resize(object sender, EventArgs e)
        {

        }

        private void eewwatchmain_Move(object sender, EventArgs e)
        {

        }

        private void eewwatchmain_LocationChanged(object sender, EventArgs e)
        {

        }

        private void eewwatchmain_SizeChanged(object sender, EventArgs e)
        {

        }

    }
}
