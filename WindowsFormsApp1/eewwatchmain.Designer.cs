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
            this.speechSynthesizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bouyomichanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voiceVoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.voiceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 821);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 22, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1444, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1444, 788);
            this.panel1.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::EEWWatch.Properties.Settings.Default, "Splitter_Distance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.splitContainer1.Size = new System.Drawing.Size(1444, 788);
            this.splitContainer1.SplitterDistance = global::EEWWatch.Properties.Settings.Default.Splitter_Distance;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1444, 740);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1444, 42);
            this.textBox1.TabIndex = 1;
            // 
            // recModeTimer
            // 
            this.recModeTimer.Tick += new System.EventHandler(this.recModeTimer_Tick);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.talkToolStripMenuItem,
            this.recToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(1444, 33);
            this.mainMenuStrip.TabIndex = 5;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.fileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 34);
            this.exitToolStripMenuItem.Text = "終了(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // talkToolStripMenuItem
            // 
            this.talkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speechSynthesizerToolStripMenuItem,
            this.bouyomichanToolStripMenuItem,
            this.voiceVoxToolStripMenuItem});
            this.talkToolStripMenuItem.Name = "talkToolStripMenuItem";
            this.talkToolStripMenuItem.Size = new System.Drawing.Size(57, 29);
            this.talkToolStripMenuItem.Text = "Talk";
            // 
            // speechSynthesizerToolStripMenuItem
            // 
            this.speechSynthesizerToolStripMenuItem.Name = "speechSynthesizerToolStripMenuItem";
            this.speechSynthesizerToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            this.speechSynthesizerToolStripMenuItem.Text = "SpeechSynthesizer";
            this.speechSynthesizerToolStripMenuItem.Click += new System.EventHandler(this.speechSynthesizerToolStripMenuItem_Click);
            // 
            // bouyomichanToolStripMenuItem
            // 
            this.bouyomichanToolStripMenuItem.Name = "bouyomichanToolStripMenuItem";
            this.bouyomichanToolStripMenuItem.Size = new System.Drawing.Size(260, 34);
            this.bouyomichanToolStripMenuItem.Text = "Bouyomi-chan";
            this.bouyomichanToolStripMenuItem.Click += new System.EventHandler(this.bouyomichanToolStripMenuItem_Click);
            // 
            // voiceVoxToolStripMenuItem
            // 
            this.voiceVoxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FastToolStripMenuItem,
            this.SlowToolStripMenuItem,
            this.toolStripMenuItem2,
            this.voiceListToolStripMenuItem});
            this.voiceVoxToolStripMenuItem.Name = "voiceVoxToolStripMenuItem";
            this.voiceVoxToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.voiceVoxToolStripMenuItem.Text = "VoiceVox";
            this.voiceVoxToolStripMenuItem.Click += new System.EventHandler(this.voiceVoxToolStripMenuItem_Click_1);
            // 
            // FastToolStripMenuItem
            // 
            this.FastToolStripMenuItem.Name = "FastToolStripMenuItem";
            this.FastToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.FastToolStripMenuItem.Text = "早め";
            this.FastToolStripMenuItem.Click += new System.EventHandler(this.SpeedToolStripMenuItem_Click);
            // 
            // SlowToolStripMenuItem
            // 
            this.SlowToolStripMenuItem.Name = "SlowToolStripMenuItem";
            this.SlowToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.SlowToolStripMenuItem.Text = "遅め";
            this.SlowToolStripMenuItem.Click += new System.EventHandler(this.SpeedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(179, 6);
            // 
            // voiceListToolStripMenuItem
            // 
            this.voiceListToolStripMenuItem.Name = "voiceListToolStripMenuItem";
            this.voiceListToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.voiceListToolStripMenuItem.Text = "VoiceList";
            // 
            // recToolStripMenuItem
            // 
            this.recToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tvTestToolStripMenuItem,
            this.contEndToolStripMenuItem});
            this.recToolStripMenuItem.Name = "recToolStripMenuItem";
            this.recToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.recToolStripMenuItem.Text = "Rec";
            // 
            // tvTestToolStripMenuItem
            // 
            this.tvTestToolStripMenuItem.Name = "tvTestToolStripMenuItem";
            this.tvTestToolStripMenuItem.Size = new System.Drawing.Size(358, 34);
            this.tvTestToolStripMenuItem.Text = "TvTest";
            this.tvTestToolStripMenuItem.Click += new System.EventHandler(this.tvTestToolStripMenuItem_Click);
            // 
            // contEndToolStripMenuItem
            // 
            this.contEndToolStripMenuItem.Name = "contEndToolStripMenuItem";
            this.contEndToolStripMenuItem.Size = new System.Drawing.Size(358, 34);
            this.contEndToolStripMenuItem.Text = "番組の終了まで録画を有効にする";
            this.contEndToolStripMenuItem.Click += new System.EventHandler(this.contEndToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // eewwatchmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1444, 843);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenuStrip);
            this.Location = new System.Drawing.Point(0, 17);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.ToolStripMenuItem bouyomichanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speechSynthesizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tvTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem voiceVoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem voiceListToolStripMenuItem;
    }
}

