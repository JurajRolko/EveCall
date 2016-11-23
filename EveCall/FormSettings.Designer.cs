namespace EveCall
{
    partial class formSettings
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
            this.numericCombatLogEntryInterval = new System.Windows.Forms.NumericUpDown();
            this.numericCombatLogFileInterval = new System.Windows.Forms.NumericUpDown();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.numericCombatBroadcastDelay = new System.Windows.Forms.NumericUpDown();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.numericFileCountWarning = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericCombatLogEntryInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCombatLogFileInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCombatBroadcastDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFileCountWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // numericCombatLogEntryInterval
            // 
            this.numericCombatLogEntryInterval.Location = new System.Drawing.Point(12, 12);
            this.numericCombatLogEntryInterval.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericCombatLogEntryInterval.Name = "numericCombatLogEntryInterval";
            this.numericCombatLogEntryInterval.Size = new System.Drawing.Size(52, 20);
            this.numericCombatLogEntryInterval.TabIndex = 0;
            this.numericCombatLogEntryInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericCombatLogFileInterval
            // 
            this.numericCombatLogFileInterval.Location = new System.Drawing.Point(12, 62);
            this.numericCombatLogFileInterval.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericCombatLogFileInterval.Name = "numericCombatLogFileInterval";
            this.numericCombatLogFileInterval.Size = new System.Drawing.Size(52, 20);
            this.numericCombatLogFileInterval.TabIndex = 1;
            this.numericCombatLogFileInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(70, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(218, 44);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "Interval for detecting changes in your combat log files. Recommended value 5-10 s" +
    "econds. ";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(70, 62);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(218, 44);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "Interval for detecting new combat log files. Recommended value 60 seconds. ";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Location = new System.Drawing.Point(70, 112);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(218, 44);
            this.richTextBox3.TabIndex = 9;
            this.richTextBox3.Text = "Interval for broadcasting a new intel if the attack occurs in the same system. Re" +
    "commended value 300 seconds. ";
            // 
            // numericCombatBroadcastDelay
            // 
            this.numericCombatBroadcastDelay.Location = new System.Drawing.Point(12, 112);
            this.numericCombatBroadcastDelay.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericCombatBroadcastDelay.Name = "numericCombatBroadcastDelay";
            this.numericCombatBroadcastDelay.Size = new System.Drawing.Size(52, 20);
            this.numericCombatBroadcastDelay.TabIndex = 8;
            this.numericCombatBroadcastDelay.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Location = new System.Drawing.Point(70, 162);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(218, 68);
            this.richTextBox4.TabIndex = 11;
            this.richTextBox4.Text = "A large number of files limit. Warning dialog appears if the total number of file" +
    "s in your combat log directory exceeds the speciefied limit. Recommended value 2" +
    "000.";
            // 
            // numericFileCountWarning
            // 
            this.numericFileCountWarning.Location = new System.Drawing.Point(12, 162);
            this.numericFileCountWarning.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericFileCountWarning.Name = "numericFileCountWarning";
            this.numericFileCountWarning.Size = new System.Drawing.Size(52, 20);
            this.numericFileCountWarning.TabIndex = 10;
            this.numericFileCountWarning.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(119, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 284);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.numericFileCountWarning);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.numericCombatBroadcastDelay);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.numericCombatLogFileInterval);
            this.Controls.Add(this.numericCombatLogEntryInterval);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.formSettings_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericCombatLogEntryInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCombatLogFileInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCombatBroadcastDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFileCountWarning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericCombatLogEntryInterval;
        private System.Windows.Forms.NumericUpDown numericCombatLogFileInterval;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.NumericUpDown numericCombatBroadcastDelay;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.NumericUpDown numericFileCountWarning;
        private System.Windows.Forms.Button button1;
    }
}