﻿namespace eewwatch
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.recModeTimer = new System.Windows.Forms.Timer(this.components);
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.talkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpeechSynthesizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BouyomichanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VoiceVoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VvFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VvSlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.VvVoiceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AivisSpeechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AsFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AsSlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.AsVoiceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 15, 0);
            this.statusStrip1.Size = new System.Drawing.Size(963, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 516);
            this.panel1.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::EEWWatch.Properties.Settings.Default, "Splitter_Distance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(963, 516);
            this.splitContainer1.SplitterDistance = global::EEWWatch.Properties.Settings.Default.Splitter_Distance;
            this.splitContainer1.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(963, 487);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(963, 25);
            this.textBox1.TabIndex = 1;
            // 
            // recModeTimer
            // 
            this.recModeTimer.Tick += new System.EventHandler(this.recModeTimer_Tick);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.talkToolStripMenuItem,
            this.recToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.mainMenuStrip.Size = new System.Drawing.Size(963, 24);
            this.mainMenuStrip.TabIndex = 5;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.fileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "終了(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // talkToolStripMenuItem
            // 
            this.talkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SpeechSynthesizerToolStripMenuItem,
            this.BouyomichanToolStripMenuItem,
            this.VoiceVoxToolStripMenuItem,
            this.AivisSpeechToolStripMenuItem});
            this.talkToolStripMenuItem.Name = "talkToolStripMenuItem";
            this.talkToolStripMenuItem.Size = new System.Drawing.Size(39, 22);
            this.talkToolStripMenuItem.Text = "Talk";
            // 
            // SpeechSynthesizerToolStripMenuItem
            // 
            this.SpeechSynthesizerToolStripMenuItem.Name = "SpeechSynthesizerToolStripMenuItem";
            this.SpeechSynthesizerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SpeechSynthesizerToolStripMenuItem.Text = "SpeechSynthesizer";
            this.SpeechSynthesizerToolStripMenuItem.Click += new System.EventHandler(this.speechSynthesizerToolStripMenuItem_Click);
            // 
            // BouyomichanToolStripMenuItem
            // 
            this.BouyomichanToolStripMenuItem.Name = "BouyomichanToolStripMenuItem";
            this.BouyomichanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.BouyomichanToolStripMenuItem.Text = "Bouyomi-chan";
            this.BouyomichanToolStripMenuItem.Click += new System.EventHandler(this.bouyomichanToolStripMenuItem_Click);
            // 
            // VoiceVoxToolStripMenuItem
            // 
            this.VoiceVoxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VvFastToolStripMenuItem,
            this.VvSlowToolStripMenuItem,
            this.toolStripMenuItem2,
            this.VvVoiceListToolStripMenuItem});
            this.VoiceVoxToolStripMenuItem.Name = "VoiceVoxToolStripMenuItem";
            this.VoiceVoxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.VoiceVoxToolStripMenuItem.Text = "VoiceVox";
            this.VoiceVoxToolStripMenuItem.Click += new System.EventHandler(this.voicevoxToolStripMenuItem_Click);
            // 
            // VvFastToolStripMenuItem
            // 
            this.VvFastToolStripMenuItem.Name = "VvFastToolStripMenuItem";
            this.VvFastToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.VvFastToolStripMenuItem.Text = "早め";
            this.VvFastToolStripMenuItem.Click += new System.EventHandler(this.VvSpeedToolStripMenuItem_Click);
            // 
            // VvSlowToolStripMenuItem
            // 
            this.VvSlowToolStripMenuItem.Name = "VvSlowToolStripMenuItem";
            this.VvSlowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.VvSlowToolStripMenuItem.Text = "遅め";
            this.VvSlowToolStripMenuItem.Click += new System.EventHandler(this.VvSpeedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // VvVoiceListToolStripMenuItem
            // 
            this.VvVoiceListToolStripMenuItem.Name = "VvVoiceListToolStripMenuItem";
            this.VvVoiceListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.VvVoiceListToolStripMenuItem.Text = "VoiceList";
            this.VvVoiceListToolStripMenuItem.Click += new System.EventHandler(this.VvVoiceListToolStripMenuItem_Click);
            // 
            // AivisSpeechToolStripMenuItem
            // 
            this.AivisSpeechToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AsFastToolStripMenuItem,
            this.AsSlowToolStripMenuItem,
            this.toolStripMenuItem3,
            this.AsVoiceListToolStripMenuItem});
            this.AivisSpeechToolStripMenuItem.Name = "AivisSpeechToolStripMenuItem";
            this.AivisSpeechToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AivisSpeechToolStripMenuItem.Text = "AivisSpeech";
            this.AivisSpeechToolStripMenuItem.Click += new System.EventHandler(this.AivisSpeechToolStripMenuItem_Click);
            // 
            // AsFastToolStripMenuItem
            // 
            this.AsFastToolStripMenuItem.Name = "AsFastToolStripMenuItem";
            this.AsFastToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AsFastToolStripMenuItem.Text = "早め";
            this.AsFastToolStripMenuItem.Click += new System.EventHandler(this.AsSpeedToolStripMenuItem_Click);
            // 
            // AsSlowToolStripMenuItem
            // 
            this.AsSlowToolStripMenuItem.Name = "AsSlowToolStripMenuItem";
            this.AsSlowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AsSlowToolStripMenuItem.Text = "遅め";
            this.AsSlowToolStripMenuItem.Click += new System.EventHandler(this.AsSpeedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // AsVoiceListToolStripMenuItem
            // 
            this.AsVoiceListToolStripMenuItem.Name = "AsVoiceListToolStripMenuItem";
            this.AsVoiceListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AsVoiceListToolStripMenuItem.Text = "VoiceList";
            this.AsVoiceListToolStripMenuItem.Click += new System.EventHandler(this.AsVoiceListToolStripMenuItem_Click);
            // 
            // recToolStripMenuItem
            // 
            this.recToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tvTestToolStripMenuItem,
            this.contEndToolStripMenuItem});
            this.recToolStripMenuItem.Name = "recToolStripMenuItem";
            this.recToolStripMenuItem.Size = new System.Drawing.Size(38, 22);
            this.recToolStripMenuItem.Text = "Rec";
            // 
            // tvTestToolStripMenuItem
            // 
            this.tvTestToolStripMenuItem.Name = "tvTestToolStripMenuItem";
            this.tvTestToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.tvTestToolStripMenuItem.Text = "TvTest";
            this.tvTestToolStripMenuItem.Click += new System.EventHandler(this.TvTestToolStripMenuItem_Click);
            // 
            // contEndToolStripMenuItem
            // 
            this.contEndToolStripMenuItem.Name = "contEndToolStripMenuItem";
            this.contEndToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.contEndToolStripMenuItem.Text = "番組の終了まで録画を有効にする";
            this.contEndToolStripMenuItem.Click += new System.EventHandler(this.ContEndToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // eewwatchmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(963, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenuStrip);
            this.Location = new System.Drawing.Point(0, 17);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "eewwatchmain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EewWatch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.eewwatchmain_FormClosing);
            this.Load += new System.EventHandler(this.eewwatchmain_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

