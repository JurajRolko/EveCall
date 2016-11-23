namespace EveCall
{
    partial class formMain
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
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonToggleActive = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkedListBoxItems = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelPathInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonSetPath = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEditItem = new System.Windows.Forms.Button();
            this.buttonDeleteItem = new System.Windows.Forms.Button();
            this.buttonNewItem = new System.Windows.Forms.Button();
            this.buttonCloneItem = new System.Windows.Forms.Button();
            this.buttonMoveItemUp = new System.Windows.Forms.Button();
            this.buttonMoveItemDown = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerCombatLog = new System.Windows.Forms.Timer(this.components);
            this.timerLogFilesUpdate = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemToolStripMenuItemToggleActive = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStripNotifyIcon;
            this.notifyIcon1.Text = "EveCall";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonToggleActive);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 60);
            this.panel1.TabIndex = 14;
            // 
            // buttonToggleActive
            // 
            this.buttonToggleActive.BackColor = System.Drawing.Color.Crimson;
            this.buttonToggleActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonToggleActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonToggleActive.ForeColor = System.Drawing.Color.White;
            this.buttonToggleActive.Location = new System.Drawing.Point(0, 0);
            this.buttonToggleActive.Name = "buttonToggleActive";
            this.buttonToggleActive.Size = new System.Drawing.Size(304, 60);
            this.buttonToggleActive.TabIndex = 9;
            this.buttonToggleActive.Text = "NOT ACTIVE - click to enable";
            this.buttonToggleActive.UseVisualStyleBackColor = false;
            this.buttonToggleActive.Click += new System.EventHandler(this.button9_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 84);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panel3.Size = new System.Drawing.Size(304, 214);
            this.panel3.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkedListBoxItems);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2, 5, 2, 0);
            this.panel2.Size = new System.Drawing.Size(294, 184);
            this.panel2.TabIndex = 20;
            // 
            // checkedListBoxItems
            // 
            this.checkedListBoxItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxItems.FormattingEnabled = true;
            this.checkedListBoxItems.Location = new System.Drawing.Point(2, 60);
            this.checkedListBoxItems.Name = "checkedListBoxItems";
            this.checkedListBoxItems.Size = new System.Drawing.Size(290, 124);
            this.checkedListBoxItems.TabIndex = 15;
            this.checkedListBoxItems.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxItems_ItemCheck);
            this.checkedListBoxItems.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxItems_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelPathInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(2, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(290, 25);
            this.panel4.TabIndex = 18;
            // 
            // labelPathInfo
            // 
            this.labelPathInfo.AutoSize = true;
            this.labelPathInfo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelPathInfo.Location = new System.Drawing.Point(7, 4);
            this.labelPathInfo.Name = "labelPathInfo";
            this.labelPathInfo.Size = new System.Drawing.Size(149, 13);
            this.labelPathInfo.TabIndex = 8;
            this.labelPathInfo.Text = "⚠ directory path is not defined";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxPath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetPath, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 30);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxPath.Location = new System.Drawing.Point(5, 5);
            this.textBoxPath.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(238, 20);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.Text = "Path to your Eve online combat log directory";
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            // 
            // buttonSetPath
            // 
            this.buttonSetPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSetPath.Location = new System.Drawing.Point(251, 5);
            this.buttonSetPath.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSetPath.Name = "buttonSetPath";
            this.buttonSetPath.Size = new System.Drawing.Size(34, 20);
            this.buttonSetPath.TabIndex = 2;
            this.buttonSetPath.Text = "...";
            this.buttonSetPath.UseVisualStyleBackColor = true;
            this.buttonSetPath.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.buttonEditItem, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonDeleteItem, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonNewItem, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonCloneItem, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonMoveItemUp, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonMoveItemDown, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 184);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(294, 25);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // buttonEditItem
            // 
            this.buttonEditItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditItem.Enabled = false;
            this.buttonEditItem.Location = new System.Drawing.Point(116, 0);
            this.buttonEditItem.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditItem.Name = "buttonEditItem";
            this.buttonEditItem.Size = new System.Drawing.Size(58, 25);
            this.buttonEditItem.TabIndex = 19;
            this.buttonEditItem.Text = "edit";
            this.buttonEditItem.UseVisualStyleBackColor = true;
            this.buttonEditItem.Click += new System.EventHandler(this.buttonEditItem_Click);
            // 
            // buttonDeleteItem
            // 
            this.buttonDeleteItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteItem.Enabled = false;
            this.buttonDeleteItem.Location = new System.Drawing.Point(174, 0);
            this.buttonDeleteItem.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDeleteItem.Name = "buttonDeleteItem";
            this.buttonDeleteItem.Size = new System.Drawing.Size(58, 25);
            this.buttonDeleteItem.TabIndex = 18;
            this.buttonDeleteItem.Text = "delete";
            this.buttonDeleteItem.UseVisualStyleBackColor = true;
            this.buttonDeleteItem.Click += new System.EventHandler(this.buttonDeleteItem_Click);
            // 
            // buttonNewItem
            // 
            this.buttonNewItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewItem.Enabled = false;
            this.buttonNewItem.Location = new System.Drawing.Point(0, 0);
            this.buttonNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNewItem.Name = "buttonNewItem";
            this.buttonNewItem.Size = new System.Drawing.Size(58, 25);
            this.buttonNewItem.TabIndex = 17;
            this.buttonNewItem.Text = "new";
            this.buttonNewItem.UseVisualStyleBackColor = true;
            this.buttonNewItem.Click += new System.EventHandler(this.buttonNewCharacter_Click);
            // 
            // buttonCloneItem
            // 
            this.buttonCloneItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCloneItem.Enabled = false;
            this.buttonCloneItem.Location = new System.Drawing.Point(58, 0);
            this.buttonCloneItem.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCloneItem.Name = "buttonCloneItem";
            this.buttonCloneItem.Size = new System.Drawing.Size(58, 25);
            this.buttonCloneItem.TabIndex = 16;
            this.buttonCloneItem.Text = "clone";
            this.buttonCloneItem.UseVisualStyleBackColor = true;
            this.buttonCloneItem.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonMoveItemUp
            // 
            this.buttonMoveItemUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMoveItemUp.Enabled = false;
            this.buttonMoveItemUp.Location = new System.Drawing.Point(232, 0);
            this.buttonMoveItemUp.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMoveItemUp.Name = "buttonMoveItemUp";
            this.buttonMoveItemUp.Size = new System.Drawing.Size(29, 25);
            this.buttonMoveItemUp.TabIndex = 20;
            this.buttonMoveItemUp.Text = "▲";
            this.buttonMoveItemUp.UseVisualStyleBackColor = true;
            this.buttonMoveItemUp.Click += new System.EventHandler(this.buttonMoveItemUp_Click);
            // 
            // buttonMoveItemDown
            // 
            this.buttonMoveItemDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMoveItemDown.Enabled = false;
            this.buttonMoveItemDown.Location = new System.Drawing.Point(261, 0);
            this.buttonMoveItemDown.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMoveItemDown.Name = "buttonMoveItemDown";
            this.buttonMoveItemDown.Size = new System.Drawing.Size(33, 25);
            this.buttonMoveItemDown.TabIndex = 21;
            this.buttonMoveItemDown.Text = "▼";
            this.buttonMoveItemDown.UseVisualStyleBackColor = true;
            this.buttonMoveItemDown.Click += new System.EventHandler(this.buttonMoveItemDown_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(304, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timerCombatLog
            // 
            this.timerCombatLog.Interval = 5000;
            this.timerCombatLog.Tick += new System.EventHandler(this.timerCombatLog_Tick);
            // 
            // timerLogFilesUpdate
            // 
            this.timerLogFilesUpdate.Interval = 30000;
            this.timerLogFilesUpdate.Tick += new System.EventHandler(this.timerLogFilesUpdate_Tick);
            // 
            // contextMenuStripNotifyIcon
            // 
            this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemToolStripMenuItemShow,
            this.itemToolStripMenuItemToggleActive,
            this.itemToolStripMenuItemExit});
            this.contextMenuStripNotifyIcon.Name = "contextMenuStripNotifyIcon";
            this.contextMenuStripNotifyIcon.Size = new System.Drawing.Size(118, 70);
            // 
            // itemToolStripMenuItemToggleActive
            // 
            this.itemToolStripMenuItemToggleActive.Name = "itemToolStripMenuItemToggleActive";
            this.itemToolStripMenuItemToggleActive.Size = new System.Drawing.Size(152, 22);
            this.itemToolStripMenuItemToggleActive.Text = "Activate";
            this.itemToolStripMenuItemToggleActive.Click += new System.EventHandler(this.itemToolStripMenuItemToggleActive_Click);
            // 
            // itemToolStripMenuItemShow
            // 
            this.itemToolStripMenuItemShow.Name = "itemToolStripMenuItemShow";
            this.itemToolStripMenuItemShow.Size = new System.Drawing.Size(152, 22);
            this.itemToolStripMenuItemShow.Text = "Show";
            this.itemToolStripMenuItemShow.Click += new System.EventHandler(this.itemToolStripMenuItemShow_Click);
            // 
            // itemToolStripMenuItemExit
            // 
            this.itemToolStripMenuItemExit.Name = "itemToolStripMenuItemExit";
            this.itemToolStripMenuItemExit.Size = new System.Drawing.Size(152, 22);
            this.itemToolStripMenuItemExit.Text = "Exit";
            this.itemToolStripMenuItemExit.Click += new System.EventHandler(this.itemToolStripMenuItemExit_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 298);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EveCall";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Shown += new System.EventHandler(this.formMain_Shown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonToggleActive;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonEditItem;
        private System.Windows.Forms.Button buttonDeleteItem;
        private System.Windows.Forms.Button buttonNewItem;
        private System.Windows.Forms.Button buttonCloneItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox checkedListBoxItems;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button buttonMoveItemDown;
        private System.Windows.Forms.Button buttonMoveItemUp;
        private System.Windows.Forms.Timer timerCombatLog;
        private System.Windows.Forms.Timer timerLogFilesUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonSetPath;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelPathInfo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItemToggleActive;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItemShow;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
    }
}

