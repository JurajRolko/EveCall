namespace EveCall
{
    partial class formItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formItem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxtitle = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWebhookSlack = new System.Windows.Forms.TextBox();
            this.checkBoxSlackActive = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBoxCharacterName = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWebhookDiscord = new System.Windows.Forms.TextBox();
            this.checkBoxDiscordActive = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxtitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(319, 30);
            this.panel1.TabIndex = 0;
            // 
            // textBoxtitle
            // 
            this.textBoxtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxtitle.Location = new System.Drawing.Point(5, 5);
            this.textBoxtitle.Name = "textBoxtitle";
            this.textBoxtitle.Size = new System.Drawing.Size(309, 20);
            this.textBoxtitle.TabIndex = 6;
            this.textBoxtitle.Text = "Title";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 291);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(319, 47);
            this.panel4.TabIndex = 20;
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(232, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.textBoxWebhookSlack);
            this.panel3.Controls.Add(this.checkBoxSlackActive);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(319, 70);
            this.panel3.TabIndex = 21;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(5, 42);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(309, 23);
            this.panel7.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(265, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "Define a special slack url provided by a channel owner";
            // 
            // textBoxWebhookSlack
            // 
            this.textBoxWebhookSlack.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxWebhookSlack.Location = new System.Drawing.Point(5, 22);
            this.textBoxWebhookSlack.Name = "textBoxWebhookSlack";
            this.textBoxWebhookSlack.Size = new System.Drawing.Size(309, 20);
            this.textBoxWebhookSlack.TabIndex = 8;
            this.textBoxWebhookSlack.Text = "Slack webhook url";
            // 
            // checkBoxSlackActive
            // 
            this.checkBoxSlackActive.AutoSize = true;
            this.checkBoxSlackActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxSlackActive.Location = new System.Drawing.Point(5, 5);
            this.checkBoxSlackActive.Name = "checkBoxSlackActive";
            this.checkBoxSlackActive.Size = new System.Drawing.Size(309, 17);
            this.checkBoxSlackActive.TabIndex = 7;
            this.checkBoxSlackActive.Text = "Broadcast to Slack";
            this.checkBoxSlackActive.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 100);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5);
            this.panel5.Size = new System.Drawing.Size(319, 191);
            this.panel5.TabIndex = 22;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.comboBoxCharacterName);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(5, 75);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(309, 111);
            this.panel8.TabIndex = 22;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.richTextBox1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 21);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(309, 90);
            this.panel9.TabIndex = 29;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(309, 90);
            this.richTextBox1.TabIndex = 31;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // comboBoxCharacterName
            // 
            this.comboBoxCharacterName.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCharacterName.FormattingEnabled = true;
            this.comboBoxCharacterName.Location = new System.Drawing.Point(0, 0);
            this.comboBoxCharacterName.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxCharacterName.Name = "comboBoxCharacterName";
            this.comboBoxCharacterName.Size = new System.Drawing.Size(309, 21);
            this.comboBoxCharacterName.TabIndex = 28;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.textBoxWebhookDiscord);
            this.panel6.Controls.Add(this.checkBoxDiscordActive);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(5, 5);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(309, 70);
            this.panel6.TabIndex = 23;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label3);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 37);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(309, 33);
            this.panel10.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(274, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Define a special discord url provided by a channel owner";
            // 
            // textBoxWebhookDiscord
            // 
            this.textBoxWebhookDiscord.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxWebhookDiscord.Location = new System.Drawing.Point(0, 17);
            this.textBoxWebhookDiscord.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxWebhookDiscord.Name = "textBoxWebhookDiscord";
            this.textBoxWebhookDiscord.Size = new System.Drawing.Size(309, 20);
            this.textBoxWebhookDiscord.TabIndex = 8;
            this.textBoxWebhookDiscord.Text = "Discord webhook url";
            // 
            // checkBoxDiscordActive
            // 
            this.checkBoxDiscordActive.AutoSize = true;
            this.checkBoxDiscordActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxDiscordActive.Location = new System.Drawing.Point(0, 0);
            this.checkBoxDiscordActive.Name = "checkBoxDiscordActive";
            this.checkBoxDiscordActive.Size = new System.Drawing.Size(309, 17);
            this.checkBoxDiscordActive.TabIndex = 7;
            this.checkBoxDiscordActive.Text = "Broadcast to Discord";
            this.checkBoxDiscordActive.UseVisualStyleBackColor = true;
            // 
            // formItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 338);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Details";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.formNewItem_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxtitle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox textBoxWebhookSlack;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox comboBoxCharacterName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxSlackActive;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWebhookDiscord;
        private System.Windows.Forms.CheckBox checkBoxDiscordActive;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}