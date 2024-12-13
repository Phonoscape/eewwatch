using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Notifications;

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
        string msg;
        Eew eew;

        HttpClient web;

        int interval;

        public class EewValue
        {
            public string Message { get; set; }
            public string Report_time { get; set; }
            public string Region_name { get; set; }
            public string Longitude { get; set; }
            public string Depth { get; set; }
            public string Latitude { get; set; }
            public string Magunitude { get; set; }
            public string Calcintensity { get; set; }
            public int Report_num { get; set; }
            public string Report_id { get; set; }
            public bool Is_cancel { get; set; }
            public bool Is_final { get; set; }
            public bool Is_training { get; set; }
            public string Alertflg { get; set; }
            public double MaxCalcintensity { get; set; }
        }

        EewValue newValue, oldValue;

        Dictionary<string, EewValue> newValues;
        Dictionary<string, EewValue> oldValues;

        private string outputPath;
        private string logPath;

        private Point normalLocation;
        private Size normalSize;

        private string vvSpeaker;
        private int vvTalkSpeed;

        private string asSpeaker;
        private int asTalkSpeed;

        List<System.Diagnostics.Process> TvtestProcess;
        System.Diagnostics.Process BouyomiProcess;

        SpeechSynthesizer sss = null;

        private const int SSS_SpeechSynthesizer = 0;
        private const int SSS_Bouyomichan = 1;
        private const int SSS_VoiceVox = 2;
        private const int SSS_AivisSpeech = 3;

        private const int SSS_VV_Speed_Fast = 0;
        private const int SSS_VV_Speed_Slow = 1;

        private const int SSS_AS_Speed_Fast = 0;
        private const int SSS_AS_Speed_Slow = 1;

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
        static int CM_RECORD_SHIFT = 158;

        static int INTERVAL_WAIT = 2000;        // ms
        static int INTERVAL_ACTIVE = 1000;      // ms
        static int INTERVAL_CHANGE_RECMODE = 5; // min

        private int talktype = SSS_Bouyomichan;

        private int tvtest_Rec = 1;
        private int tvtest_recend = 1;

        //static int INTERVAL_CHANGE_RECMODE = 1;
        //static int INTERVAL_CHANGE_RECMODE = 10000;

        private bool _debug = false;

        private List<string> kinken = new List<string>() { 
            "宮城", 
            "山形", 
            "福島",
            "秋田",
            "岩手",
            "三陸"
        };

        private readonly string demoMsg = "緊急地震速報待機中";

        public eewwatchmain()
        {
            InitializeComponent();

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

            listView1.FullRowSelect = true;

            vvSpeaker = EEWWatch.Properties.Settings.Default.VvSpeaker;
            vvTalkSpeed = EEWWatch.Properties.Settings.Default.VvTalkSpeed;
            asSpeaker = EEWWatch.Properties.Settings.Default.AsSpeaker;
            asTalkSpeed = EEWWatch.Properties.Settings.Default.AsTalkSpeed;

            VvMakeVoiceList();
            SetVvTalkSpeedMenu(vvTalkSpeed);
            AsMakeVoiceList();
            SetAsTalkSpeedMenu(asTalkSpeed);

            talktype = EEWWatch.Properties.Settings.Default.Talk;
            SetTalkMenu(talktype);

            tvTestToolStripMenuItem.Checked = true;
            contEndToolStripMenuItem.Checked = true;

            outputPath = Application.StartupPath;
            logPath = outputPath + "\\log\\";

            newValue = null;
            oldValue = null;

            newValues = new Dictionary<string, EewValue>();
            oldValues = new Dictionary<string, EewValue>();

            //            if (sss != null)
            //            {
            //                sss.SpeakAsyncCancelAll();
            //sss = null;
            //}

            //sss.SpeakAsyncCancelAll();

            //sss = new SpeechSynthesizer();

            //sss.SelectVoiceByHints(VoiceGender.Female);
            //sss.Rate = 2;

            if (!_debug) LoadOldData();

            web = new HttpClient();

            talk("緊急地震速報の受信を開始しました");

            timer1.Interval = interval;
            timer1.Start();
            recModeTimer.Stop();

            //Test
            //recTv();
        }

        private void SetTalkMenu(int talktype)
        {
            this.talktype = talktype;

            SpeechSynthesizerToolStripMenuItem.Checked = false;
            BouyomichanToolStripMenuItem.Checked = false;
            VoiceVoxToolStripMenuItem.Checked = false;
            AivisSpeechToolStripMenuItem.Checked = false;

            switch (talktype)
            {
                case SSS_Bouyomichan:
                    BouyomichanToolStripMenuItem.Checked = true;
                    break;
                case SSS_VoiceVox:
                    VoiceVoxToolStripMenuItem.Checked = true;
                    break;
                case SSS_AivisSpeech:
                    AivisSpeechToolStripMenuItem.Checked= true;
                    break;
                default:
                case SSS_SpeechSynthesizer:
                    SpeechSynthesizerToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            var date = System.DateTime.Now;

            String filename;

            if (!_debug)
            {
                filename = String.Format(
                    "{0}{1:00}{2:00}{3:00}{4:00}{5:00}{6:00}.json",
                    URI,
                    date.Year,
                    date.Month,
                    date.Day,
                    date.Hour,
                    date.Minute,
                    date.Second);
            }
            else
            {
                filename = String.Format(
                    "{0}{1:00}{2:00}{3:00}{4:00}{5:00}{6:00}.json",
                    URI,
                    2024,
                    1,
                    19,
                    15,
                    49,
                    10);
            }

            statusStrip1.Items[0].Text = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}",
                date.Year,
                date.Month,
                date.Day,
                date.Hour,
                date.Minute,
                date.Second);

            var res = GetWeb(filename);
            if (res != string.Empty)
            {
                SetValue(res);

                textBox1.Clear();
                textBox1.Text = res;

                if (newValue.Report_id != "")
                {
                    oldValue = null;
                    if (oldValues.ContainsKey(newValue.Report_id))
                        oldValue = oldValues[newValue.Report_id];

                    CheckSpeak();
                    AddList();

                    if (!newValue.Is_final)
                    {
                        if (oldValues.ContainsKey(newValue.Report_id))
                        {
                            oldValues[newValue.Report_id] = newValue;
                        }
                        else
                        {
                            oldValues.Add(newValue.Report_id, newValue);
                        }
                    }
                    else
                    {
                        oldValues.Remove(newValue.Report_id);

                        if (oldValues.Count == 0)
                        {
                            {
                                talk("すべての緊急地震速報の通知が終了しました");
                                interval = INTERVAL_WAIT;
                            }
                        }
                    }
                }

                statusStrip1.Items[1].Text = oldValues.Count > 0 ? "入電中" : "待機中";
 
                timer1.Interval = interval;
                timer1.Start();
            }
            else
            {
                statusStrip1.Items[1].Text = "取得エラー";
            }
        }

        private string GetWeb(string filename)
        {
            try
            {
                msg = web.GetStringAsync(filename).Result;
            }
            catch (HttpRequestException e)
            {
                newValue.Message = "データがありません";
                msg = string.Empty;
            }
            catch
            {
                newValue.Message = "データがありません";
                msg = string.Empty;
            }
            return msg;
        }

        private void SetValue(string msg)
        {
            try
            {
                eew = JsonConvert.DeserializeObject<Eew>(msg);
            }
            catch {
                return;
            }

            newValue = new EewValue();

            newValue.Message = eew.Result.Message;
            newValue.Report_time = eew.Report_time;
            newValue.Region_name = eew.Region_name;
            newValue.Longitude = eew.Longitude;
            newValue.Depth = eew.Depth;
            newValue.Latitude = eew.Latitude;
            newValue.Magunitude = eew.Magunitude;
            newValue.Calcintensity = eew.Calcintensity;
            newValue.Report_num = eew.Report_num == "" ? 0 : int.Parse(eew.Report_num);
            newValue.Report_id = eew.Report_id;
            newValue.Is_cancel = eew.Is_cancel == "" ? false : bool.Parse(eew.Is_cancel);
            newValue.Is_final = eew.Is_final == "" ? false : bool.Parse(eew.Is_final);
            newValue.Alertflg = eew.Alertflg;
            newValue.Is_training = eew.Is_training == "" ? false : bool.Parse(eew.Is_training);

            if (newValue.Calcintensity != "")
            {
                newValue.MaxCalcintensity = int.Parse(newValue.Calcintensity.Substring(0, 1));
                if (newValue.MaxCalcintensity >= 5)
                {
                    if (newValue.Calcintensity.Substring(1, 1) == "強")
                    {
                        newValue.MaxCalcintensity += 0.5;
                    }
                }
            }
            else
            {
                // nothing
            }
        }

        private void CheckSpeak()
        {
            if (oldValue != null)
            {
                SpeakContinue();
            }
            else
            {
                if (!newValue.Is_final)
                {
                    SpeakNew();
                }
            }
        }

        private void SpeakContinue()
        {
            double calc = 0;

            if (oldValue.Alertflg != newValue.Alertflg)
            {
                if (newValue.Alertflg == "警報")
                {
                    recTv();
                }

                talk("緊急地震速報が" + newValue.Alertflg + "、になりました");
            }

            if (oldValue.Magunitude != newValue.Magunitude &&
                Convert.ToDouble(oldValue.Magunitude) < 5.0 &&
                Convert.ToDouble(newValue.Magunitude) >= 5.0)
            {
                talk("マグニチュードが、5.0、を超えました");
            }

            if (!oldValue.Is_final && newValue.Is_final)
            {
                //talk("緊急地震速報が解除されました。");
                talk("最終報が通知されました");
            }

            if (oldValue.Report_num != newValue.Report_num)
            {
                //                       if ( !Directory.Exists(outputPath+"\\log"))
                //                       {
                //                           Directory.CreateDirectory(outputPath + "\\log");
                //                       }

                Encoding enc2 = Encoding.UTF8;
                StreamWriter writer2 = new StreamWriter(logPath + newValue.Report_id.ToString() + ".txt", true, enc2);
                //                        writer2.WriteLine(msg.Result.ToString() + Environment.NewLine);
                writer2.WriteLine(msg);
                writer2.Close();
            }

            if (newValue.Is_cancel)
            {
                if (!oldValue.Is_cancel)
                {
                    talk("緊急地震速報が、キャンセルされました");
                }
            }

            if (newValue.Calcintensity != "")
            {
                calc = int.Parse(newValue.Calcintensity.Substring(0, 1));
                if (calc >= 5)
                {
                    if (newValue.Calcintensity.Substring(1, 1) == "強") calc += 0.5;
                }
            }

            if (calc > newValue.MaxCalcintensity)
            {
                talk("予想最大震度" + newValue.Calcintensity);
                newValue.MaxCalcintensity = calc;
            }
        }

        private void SpeakNew()
        {
            string talkmsg = string.Empty;

            // 初報登録
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            Encoding enc = Encoding.UTF8;
            StreamWriter writer = new StreamWriter(logPath + newValue.Report_id.ToString() + ".txt", true, enc);
            //            writer.WriteLine(msg.Result.ToString() + Environment.NewLine);
            writer.WriteLine(msg);
            writer.Close();

            if (newValue.Is_training)
            {
                talkmsg = newValue.Region_name + "訓練の緊急地震速報、" + newValue.Alertflg + "、が発表されました";
            }
            else
            {
                string msg = string.Empty;

                foreach (var reg in kinken)
                {
                    if (newValue.Region_name.Contains(reg))
                    {
                        msg = "揺れ注意。";
                    }
                }

                talkmsg = msg + newValue.Region_name + "でマグニチュード" + newValue.Magunitude + "、予想最大震度" + newValue.Calcintensity + "の" + newValue.Alertflg + "が発表されました";

                if (newValue.Alertflg == "警報")
                {
                    recTv();
                }
            }

            talk(talkmsg);
        }

        private void AddList()
        {
            bool flgFirst = true;
            ListViewItem list = null;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Text == newValue.Report_id)
                {
                    list = listView1.Items[i];
                    flgFirst = false;
                    break;
                }
            }

            if (flgFirst)
            {
                if (!newValue.Is_final)
                {
                    AddFirst();
                }
            }
            else
            {
                AddContinue(list);
            }
        }

        private void AddContinue(ListViewItem list)
        {
            double calc = 0;

            list.SubItems[0].Text = newValue.Report_id;
            list.SubItems[1].Text = newValue.Report_time;
            list.SubItems[2].Text = newValue.Report_num.ToString();

            if (newValue.Is_training)
            {
                list.SubItems[3].Text = "訓練";
            }
            else
            {
                list.SubItems[3].Text = newValue.Alertflg;
            }

            if (newValue.Is_cancel)
            {
                list.SubItems[4].Text = "キャンセル";
            }
            else
            {
                list.SubItems[4].Text = newValue.Is_final == true ? "最終" : "継続";
            }

            if (newValue.Calcintensity != "")
            {
                calc = int.Parse(newValue.Calcintensity.Substring(0, 1));
                if (calc >= 5)
                {
                    if (newValue.Calcintensity.Substring(1, 1) == "強") calc += 0.5;
                }
            }

            list.SubItems[5].Text = newValue.Region_name;
            list.SubItems[6].Text = newValue.Magunitude;
            list.SubItems[7].Text = newValue.Depth;
            list.SubItems[8].Text = newValue.Calcintensity;
            list.SubItems[9].Text = newValue.Longitude;
            list.SubItems[10].Text = newValue.Latitude;
        }

        private void AddFirst()
        {
            // 初報登録
            string[] val = new string[11];

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            val[0] = newValue.Report_id;
            val[1] = newValue.Report_time;
            val[2] = newValue.Report_num.ToString();
            val[3] = newValue.Alertflg;
            val[4] = newValue.Is_final == true ? "最終" : "継続";
            val[5] = newValue.Region_name;
            val[6] = newValue.Magunitude;
            val[7] = newValue.Depth;
            val[8] = newValue.Calcintensity;
            val[9] = newValue.Longitude;
            val[10] = newValue.Latitude;

            // listView1.Items.Add(new ListViewItem(val));
            ListViewItem item = listView1.Items.Insert(0, new ListViewItem(val));
        }

        private void talk(string text)
        {
            BouyomiProcess = null;

            Debug.WriteLine("TALK:" + text);

            ShowNotify(text);

            switch(talktype)
            {
                case SSS_SpeechSynthesizer:
                    sss = new SpeechSynthesizer();

                    sss.SelectVoiceByHints(VoiceGender.Female);
                    sss.Rate = 2;

                    sss.SpeakAsync(text);
                    break;

                case SSS_Bouyomichan:
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

                    Bouyomi.Bouyomi bouyomi = new Bouyomi.Bouyomi();
                    bouyomi.Talk(text);
                    break;

                case SSS_VoiceVox:
                    Voicevox.Voicevox vv = new Voicevox.Voicevox();
                    vv.Init(vvSpeaker, vvTalkSpeed);
                    vv.Talk(text);
                    break;

                case SSS_AivisSpeech:
                    AivisSpeech.AivisSpeech aivisSpeech = new AivisSpeech.AivisSpeech();
                    aivisSpeech.Init(vvSpeaker, vvTalkSpeed);
                    aivisSpeech.Talk(text);
                    break;
            }
        }

        private void recTv()
        {
            // ウィンドウを探す
            TvtestProcess = new List<System.Diagnostics.Process>();

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                //メインウィンドウのタイトルがある時だけ列挙する
                if (p.ProcessName == "TVTest")
                {
                    TvtestProcess.Add(p);
                }
            }

            if (TvtestProcess.Count == 0) return;

            foreach (var p in TvtestProcess)
            {
                IntPtr hwnd = p.MainWindowHandle;

                // 録画ボタンの押下を送信
                //PostMessage(hwnd, WM_KEYDOWN, 0x11, 0);
                //PostMessage(hwnd, WM_KEYDOWN, VkKeyScan('r'), 0);
                SendMessage(hwnd, WM_COMMAND, CM_RECORD_SHIFT, 0);
            }

            recModeTimer.Interval = INTERVAL_CHANGE_RECMODE * 60 * 1000;
            recModeTimer.Start();

            if (tvTestToolStripMenuItem.Checked)
            {
                talk("録画を開始しました");
                if (contEndToolStripMenuItem.Checked)
                {
                    Task.Factory.StartNew(() => MessageBox.Show("録画を開始しました。"));
                }
            }
        }

        /*
         * UI関連 
         */
        private void recModeTimer_Tick(object sender, EventArgs e)
        {
            recModeTimer.Stop();

            if (TvtestProcess.Count == 0) return;

            foreach (var p in TvtestProcess)
            {
                IntPtr hwnd = p.MainWindowHandle;

                // 録画ボタンの押下を送信
                SendMessage(hwnd, WM_COMMAND, CM_RECORDEVENT, 0);
            }

            talk("録画を番組の終了までにしました");
            Task.Factory.StartNew(() => MessageBox.Show("録画を番組の終了までにしました。"));

            TvtestProcess.Clear();
        }

        private void ShowNotify(String msg)
        {
            var tmpl = ToastTemplateType.ToastText01;
            var xml = ToastNotificationManager.GetTemplateContent(tmpl);

            /* ToastImageAndText02の場合
            <toast>
                <visual>
                    <binding template="ToastImageAndText02">
                        <image id="1" src=""/>
                        <text id="1"></text>
                        <text id="2"></text>
                    </binding>
                </visual>
            </toast>
            */

//            var images = xml.GetElementsByTagName("image");
//            var src = images[0].Attributes.GetNamedItem("src");
//            src.InnerText = "file:///" + Path.GetFullPath("images\\icon.png");

            var texts = xml.GetElementsByTagName("text");
            texts[0].AppendChild(xml.CreateTextNode(msg));

            var toast = new ToastNotification(xml);

            ToastNotificationManager.CreateToastNotifier("EEWWatch").Show(toast);
        }

        private void LoadOldData()
        {
            var lists = Directory.GetFiles(logPath);
            Array.Sort(lists, StringComparer.OrdinalIgnoreCase);

            var listCount = lists.Length;
            foreach (var list in lists)
            {
                if (listCount <= 10)
                {
                    Encoding enc = Encoding.UTF8;
                    StreamReader reader = new StreamReader(list, enc);

                    var msg = reader.ReadLine();
                    while(msg != null)
                    {
                        SetValue(msg);
                        AddList();
                        msg = reader.ReadLine();
                    }

                    reader.Close();
                }
                listCount--;
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var sels = ((ListView)sender).SelectedItems;
            var sel = sels[0];

            var filename = logPath + sel.SubItems[0].Text + ".txt";

            System.Diagnostics.Process.Start(filename);
        }

        private void eewwatchmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            web.Dispose();

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

            EEWWatch.Properties.Settings.Default.Talk = talktype;
            EEWWatch.Properties.Settings.Default.VvSpeaker = vvSpeaker;
            EEWWatch.Properties.Settings.Default.VvTalkSpeed = vvTalkSpeed;
            EEWWatch.Properties.Settings.Default.AsSpeaker = asSpeaker;
            EEWWatch.Properties.Settings.Default.AsTalkSpeed = asTalkSpeed;

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

        private void eewwatchmain_Activated(object sender, EventArgs e)
        {
            VvMakeVoiceList();
            AsMakeVoiceList();
        }

        private void speechSynthesizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTalkMenu(SSS_SpeechSynthesizer);
        }

        private void bouyomichanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTalkMenu(SSS_Bouyomichan);
        }

        private void voicevoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTalkMenu(SSS_VoiceVox);
        }

        private void AivisSpeechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTalkMenu(SSS_AivisSpeech);
        }

        private void TvTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvTestToolStripMenuItem.Checked = !tvTestToolStripMenuItem.Checked;
        }

        private void ContEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contEndToolStripMenuItem.Checked = !contEndToolStripMenuItem.Checked;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VvSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == VvFastToolStripMenuItem)
            {
                vvTalkSpeed = SSS_VV_Speed_Fast;
            }
            else
            {
                vvTalkSpeed = SSS_VV_Speed_Slow;
            }

            SetVvTalkSpeedMenu(vvTalkSpeed);

            talktype = SSS_VoiceVox;
            SetTalkMenu(talktype);

            Voicevox.Voicevox vv = new Voicevox.Voicevox();
            vv.Init(vvSpeaker, vvTalkSpeed);
            vv.Talk(demoMsg);
        }

        private void AsSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == AsFastToolStripMenuItem)
            {
                asTalkSpeed = SSS_AS_Speed_Fast;
            }
            else
            {
                asTalkSpeed = SSS_AS_Speed_Slow;
            }

            SetAsTalkSpeedMenu(asTalkSpeed);

            talktype = SSS_AivisSpeech;
            SetTalkMenu(talktype);

            AivisSpeech.AivisSpeech aivisSpeech = new AivisSpeech.AivisSpeech();
            aivisSpeech.Init(vvSpeaker, vvTalkSpeed);
            aivisSpeech.Talk(demoMsg);
        }

        private void SetVvTalkSpeedMenu(int vvTalkSpeed)
        {
            VvFastToolStripMenuItem.Checked = vvTalkSpeed == SSS_VV_Speed_Fast;
            VvSlowToolStripMenuItem.Checked = vvTalkSpeed == SSS_VV_Speed_Slow;
        }

        private void SetAsTalkSpeedMenu(int asTalkSpeed)
        {
            AsFastToolStripMenuItem.Checked = asTalkSpeed == SSS_AS_Speed_Fast;
            AsSlowToolStripMenuItem.Checked = asTalkSpeed == SSS_AS_Speed_Slow;
        }

        private void VvDditem_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            var owner = (ToolStripMenuItem)item.OwnerItem;

            foreach(ToolStripMenuItem itemAll in VvVoiceListToolStripMenuItem.DropDownItems)
            {
                itemAll.Checked = false;
                foreach (ToolStripMenuItem subItemAll in itemAll.DropDownItems)
                {
                    subItemAll.Checked = false;
                }
            }

            item.Checked = true;
            owner.Checked = true;

            vvSpeaker = (string)item.Tag;

            SetTalkMenu(SSS_VoiceVox);

            Voicevox.Voicevox vv = new Voicevox.Voicevox();
            vv.Init(vvSpeaker, vvTalkSpeed);
            vv.Talk(demoMsg);
        }

        private void AsDditem_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            var owner = (ToolStripMenuItem)item.OwnerItem;

            foreach (ToolStripMenuItem itemAll in VvVoiceListToolStripMenuItem.DropDownItems)
            {
                itemAll.Checked = false;
                foreach (ToolStripMenuItem subItemAll in itemAll.DropDownItems)
                {
                    subItemAll.Checked = false;
                }
            }

            item.Checked = true;
            owner.Checked = true;

            vvSpeaker = (string)item.Tag;

            SetTalkMenu(SSS_AivisSpeech);

            AivisSpeech.AivisSpeech aivisSpeech = new AivisSpeech.AivisSpeech();
            aivisSpeech.Init(vvSpeaker, vvTalkSpeed);
            aivisSpeech.Talk(demoMsg);
        }

        private void VvMakeVoiceList()
        {
            Voicevox.Voicevox vv = new Voicevox.Voicevox();
            vv.Init(vvSpeaker, vvTalkSpeed);
            var list = vv.ListSpeaker();

            if (vvSpeaker == null || vvSpeaker.Length == 0)
            {
                vvSpeaker = vv.defaultVoice;
            }

            VvVoiceListToolStripMenuItem.DropDownItems.Clear();
            foreach (var item in list)
            {
                var name = item.Key;
                var style = name.Split('_');

                ToolStripMenuItem toolStripMenuItem = null;
                foreach (ToolStripMenuItem ddItem in VvVoiceListToolStripMenuItem.DropDownItems)
                {
                    if (ddItem.Text == style[0])
                    {
                        toolStripMenuItem = ddItem;
                        break;
                    }
                }

                ToolStripMenuItem subItem = null;
                if (toolStripMenuItem != null)
                {
                    subItem = (ToolStripMenuItem)toolStripMenuItem.DropDownItems.Add(style[1]);
                    subItem.Click += VvDditem_Click;
                    subItem.Tag = name;
                }
                else
                {
                    var dditem = VvVoiceListToolStripMenuItem.DropDownItems;
                    var newItem = (ToolStripMenuItem)dditem.Add(style[0]);
                    subItem = (ToolStripMenuItem)newItem.DropDownItems.Add(style[1]);
                    subItem.Click += VvDditem_Click;
                    subItem.Tag = name;
                }

                if (name == vvSpeaker)
                {
                    ((ToolStripMenuItem)subItem.OwnerItem).Checked = true;
                    subItem.Checked = true;
                }
            }
        }

        private void AsMakeVoiceList()
        {
            AivisSpeech.AivisSpeech aivisSpeech = new AivisSpeech.AivisSpeech();
            aivisSpeech.Init(asSpeaker, asTalkSpeed);
            var list = aivisSpeech.ListSpeaker();

            if (asSpeaker == null || asSpeaker.Length == 0)
            {
                asSpeaker = aivisSpeech.defaultVoice;
            }

            AsVoiceListToolStripMenuItem.DropDownItems.Clear();
            foreach (var item in list)
            {
                var name = item.Key;
                var style = name.Split('_');

                ToolStripMenuItem toolStripMenuItem = null;
                foreach (ToolStripMenuItem ddItem in AsVoiceListToolStripMenuItem.DropDownItems)
                {
                    if (ddItem.Text == style[0])
                    {
                        toolStripMenuItem = ddItem;
                        break;
                    }
                }

                ToolStripMenuItem subItem = null;
                if (toolStripMenuItem != null)
                {
                    subItem = (ToolStripMenuItem)toolStripMenuItem.DropDownItems.Add(style[1]);
                    subItem.Click += AsDditem_Click;
                    subItem.Tag = name;
                }
                else
                {
                    var dditem = AsVoiceListToolStripMenuItem.DropDownItems;
                    var newItem = (ToolStripMenuItem)dditem.Add(style[0]);
                    subItem = (ToolStripMenuItem)newItem.DropDownItems.Add(style[1]);
                    subItem.Click += AsDditem_Click;
                    subItem.Tag = name;
                }

                if (name == asSpeaker)
                {
                    ((ToolStripMenuItem)subItem.OwnerItem).Checked = true;
                    subItem.Checked = true;
                }
            }
        }

        private void VvVoiceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VvMakeVoiceList();
        }

        private void AsVoiceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsMakeVoiceList();
        }
    }
}
