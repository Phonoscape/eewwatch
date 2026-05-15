namespace UserSetting
{
    partial class UserSettingsForm
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
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            buttonCancel = new System.Windows.Forms.Button();
            buttonOk = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            userSettingDiscord1 = new UserSettingDiscord();
            tabPageDiscord = new System.Windows.Forms.TabPage();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageDiscord.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 389);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(557, 31);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonCancel);
            panel2.Controls.Add(buttonOk);
            panel2.Dock = System.Windows.Forms.DockStyle.Right;
            panel2.Location = new System.Drawing.Point(390, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(167, 31);
            panel2.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.Location = new System.Drawing.Point(84, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonOk.Location = new System.Drawing.Point(3, 3);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(75, 23);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageDiscord);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(557, 389);
            tabControl1.TabIndex = 2;
            // 
            // userSettingDiscord1
            // 
            userSettingDiscord1.Dock = System.Windows.Forms.DockStyle.Fill;
            userSettingDiscord1.Location = new System.Drawing.Point(3, 3);
            userSettingDiscord1.Name = "userSettingDiscord1";
            userSettingDiscord1.Size = new System.Drawing.Size(543, 355);
            userSettingDiscord1.TabIndex = 0;
            // 
            // tabPageDiscord
            // 
            tabPageDiscord.Controls.Add(userSettingDiscord1);
            tabPageDiscord.Location = new System.Drawing.Point(4, 24);
            tabPageDiscord.Name = "tabPageDiscord";
            tabPageDiscord.Padding = new System.Windows.Forms.Padding(3);
            tabPageDiscord.Size = new System.Drawing.Size(549, 361);
            tabPageDiscord.TabIndex = 0;
            tabPageDiscord.Text = "Discord";
            tabPageDiscord.UseVisualStyleBackColor = true;
            // 
            // UserSettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(557, 420);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "UserSettingsForm";
            Text = "SettingForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageDiscord.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDiscord;
        private UserSettingDiscord userSettingDiscord1;
    }
}