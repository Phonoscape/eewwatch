namespace eewwatch
{
    partial class eewwatchmain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eewwatchmain));
            timer1 = new System.Windows.Forms.Timer(components);
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            panel1 = new System.Windows.Forms.Panel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            listView1 = new System.Windows.Forms.ListView();
            textBox1 = new System.Windows.Forms.TextBox();
            recModeTimer = new System.Windows.Forms.Timer(components);
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            talkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SpeechSynthesizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            BouyomichanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            VoiceVoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            VvFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            VvSlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            VvVoiceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            AivisSpeechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            AsFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            AsSlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            AsVoiceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            recToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tvTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            TopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            testRecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
            notifyIconContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            mainMenuStrip.SuspendLayout();
            notifyIconContextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            statusStrip1.Location = new System.Drawing.Point(0, 821);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 22, 0);
            statusStrip1.Size = new System.Drawing.Size(1444, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 33);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1444, 788);
            panel1.TabIndex = 4;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Size = new System.Drawing.Size(1444, 788);
            splitContainer1.SplitterDistance = 99;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 2;
            // 
            // listView1
            // 
            listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listView1.Location = new System.Drawing.Point(0, 0);
            listView1.Margin = new System.Windows.Forms.Padding(4);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(1444, 99);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // textBox1
            // 
            textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox1.Location = new System.Drawing.Point(0, 0);
            textBox1.Margin = new System.Windows.Forms.Padding(4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(1444, 683);
            textBox1.TabIndex = 1;
            // 
            // recModeTimer
            // 
            recModeTimer.Tick += recModeTimer_Tick;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, talkToolStripMenuItem, recToolStripMenuItem, actionToolStripMenuItem });
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new System.Drawing.Size(1444, 33);
            mainMenuStrip.TabIndex = 5;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            fileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(171, 34);
            exitToolStripMenuItem.Text = "終了(&X)";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // talkToolStripMenuItem
            // 
            talkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { SpeechSynthesizerToolStripMenuItem, BouyomichanToolStripMenuItem, VoiceVoxToolStripMenuItem, AivisSpeechToolStripMenuItem });
            talkToolStripMenuItem.Name = "talkToolStripMenuItem";
            talkToolStripMenuItem.Size = new System.Drawing.Size(57, 29);
            talkToolStripMenuItem.Text = "Talk";
            // 
            // SpeechSynthesizerToolStripMenuItem
            // 
            SpeechSynthesizerToolStripMenuItem.Name = "SpeechSynthesizerToolStripMenuItem";
            SpeechSynthesizerToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            SpeechSynthesizerToolStripMenuItem.Text = "SpeechSynthesizer";
            SpeechSynthesizerToolStripMenuItem.Click += speechSynthesizerToolStripMenuItem_Click;
            // 
            // BouyomichanToolStripMenuItem
            // 
            BouyomichanToolStripMenuItem.Name = "BouyomichanToolStripMenuItem";
            BouyomichanToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            BouyomichanToolStripMenuItem.Text = "Bouyomi-chan";
            BouyomichanToolStripMenuItem.Click += bouyomichanToolStripMenuItem_Click;
            // 
            // VoiceVoxToolStripMenuItem
            // 
            VoiceVoxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { VvFastToolStripMenuItem, VvSlowToolStripMenuItem, toolStripMenuItem2, VvVoiceListToolStripMenuItem });
            VoiceVoxToolStripMenuItem.Name = "VoiceVoxToolStripMenuItem";
            VoiceVoxToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            VoiceVoxToolStripMenuItem.Text = "VoiceVox";
            VoiceVoxToolStripMenuItem.Click += voicevoxToolStripMenuItem_Click;
            // 
            // VvFastToolStripMenuItem
            // 
            VvFastToolStripMenuItem.Name = "VvFastToolStripMenuItem";
            VvFastToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            VvFastToolStripMenuItem.Text = "早め";
            VvFastToolStripMenuItem.Click += VvSpeedToolStripMenuItem_Click;
            // 
            // VvSlowToolStripMenuItem
            // 
            VvSlowToolStripMenuItem.Name = "VvSlowToolStripMenuItem";
            VvSlowToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            VvSlowToolStripMenuItem.Text = "遅め";
            VvSlowToolStripMenuItem.Click += VvSpeedToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(179, 6);
            // 
            // VvVoiceListToolStripMenuItem
            // 
            VvVoiceListToolStripMenuItem.Name = "VvVoiceListToolStripMenuItem";
            VvVoiceListToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            VvVoiceListToolStripMenuItem.Text = "VoiceList";
            VvVoiceListToolStripMenuItem.Click += VvVoiceListToolStripMenuItem_Click;
            // 
            // AivisSpeechToolStripMenuItem
            // 
            AivisSpeechToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { AsFastToolStripMenuItem, AsSlowToolStripMenuItem, toolStripMenuItem3, AsVoiceListToolStripMenuItem });
            AivisSpeechToolStripMenuItem.Name = "AivisSpeechToolStripMenuItem";
            AivisSpeechToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            AivisSpeechToolStripMenuItem.Text = "AivisSpeech";
            AivisSpeechToolStripMenuItem.Click += AivisSpeechToolStripMenuItem_Click;
            // 
            // AsFastToolStripMenuItem
            // 
            AsFastToolStripMenuItem.Name = "AsFastToolStripMenuItem";
            AsFastToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            AsFastToolStripMenuItem.Text = "早め";
            AsFastToolStripMenuItem.Click += AsSpeedToolStripMenuItem_Click;
            // 
            // AsSlowToolStripMenuItem
            // 
            AsSlowToolStripMenuItem.Name = "AsSlowToolStripMenuItem";
            AsSlowToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            AsSlowToolStripMenuItem.Text = "遅め";
            AsSlowToolStripMenuItem.Click += AsSpeedToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(179, 6);
            // 
            // AsVoiceListToolStripMenuItem
            // 
            AsVoiceListToolStripMenuItem.Name = "AsVoiceListToolStripMenuItem";
            AsVoiceListToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            AsVoiceListToolStripMenuItem.Text = "VoiceList";
            AsVoiceListToolStripMenuItem.Click += AsVoiceListToolStripMenuItem_Click;
            // 
            // recToolStripMenuItem
            // 
            recToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tvTestToolStripMenuItem, contEndToolStripMenuItem });
            recToolStripMenuItem.Name = "recToolStripMenuItem";
            recToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            recToolStripMenuItem.Text = "Rec";
            // 
            // tvTestToolStripMenuItem
            // 
            tvTestToolStripMenuItem.Name = "tvTestToolStripMenuItem";
            tvTestToolStripMenuItem.Size = new System.Drawing.Size(358, 34);
            tvTestToolStripMenuItem.Text = "TvTest";
            tvTestToolStripMenuItem.Click += TvTestToolStripMenuItem_Click;
            // 
            // contEndToolStripMenuItem
            // 
            contEndToolStripMenuItem.Name = "contEndToolStripMenuItem";
            contEndToolStripMenuItem.Size = new System.Drawing.Size(358, 34);
            contEndToolStripMenuItem.Text = "番組の終了まで録画を有効にする";
            contEndToolStripMenuItem.Click += ContEndToolStripMenuItem_Click;
            // 
            // actionToolStripMenuItem
            // 
            actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TopToolStripMenuItem, toolStripMenuItem4, testRecToolStripMenuItem });
            actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            actionToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            actionToolStripMenuItem.Text = "Action";
            // 
            // TopToolStripMenuItem
            // 
            TopToolStripMenuItem.Name = "TopToolStripMenuItem";
            TopToolStripMenuItem.Size = new System.Drawing.Size(362, 34);
            TopToolStripMenuItem.Text = "発報があった場合、Topへ表示する";
            TopToolStripMenuItem.Click += topToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size(359, 6);
            // 
            // testRecToolStripMenuItem
            // 
            testRecToolStripMenuItem.Name = "testRecToolStripMenuItem";
            testRecToolStripMenuItem.Size = new System.Drawing.Size(362, 34);
            testRecToolStripMenuItem.Text = "テスト録画";
            testRecToolStripMenuItem.Click += testRecToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = notifyIconContextMenuStrip1;
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // notifyIconContextMenuStrip1
            // 
            notifyIconContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            notifyIconContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { endToolStripMenuItem });
            notifyIconContextMenuStrip1.Name = "notifyIconContextMenuStrip1";
            notifyIconContextMenuStrip1.Size = new System.Drawing.Size(121, 36);
            // 
            // endToolStripMenuItem
            // 
            endToolStripMenuItem.Name = "endToolStripMenuItem";
            endToolStripMenuItem.Size = new System.Drawing.Size(120, 32);
            endToolStripMenuItem.Text = "終了";
            endToolStripMenuItem.Click += endToolStripMenuItem_Click;
            // 
            // eewwatchmain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1444, 843);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(mainMenuStrip);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Location = new System.Drawing.Point(0, 17);
            MainMenuStrip = mainMenuStrip;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "eewwatchmain";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "EewWatch";
            FormClosing += eewwatchmain_FormClosing;
            Load += eewwatchmain_Load;
            Resize += eewwatchmain_Resize;
            StyleChanged += eewwatchmain_StyleChanged_1;
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            notifyIconContextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer recModeTimer;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem talkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BouyomichanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SpeechSynthesizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tvTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem VoiceVoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VvFastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VvSlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem VvVoiceListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AivisSpeechToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AsFastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AsSlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem AsVoiceListToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem testRecToolStripMenuItem;
    }
}

