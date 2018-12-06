namespace Jo.OfficeHelper
{
    partial class frmMain
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
            this.tab = new System.Windows.Forms.TabControl();
            this.tabQuickHidePage = new System.Windows.Forms.TabPage();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabColorPicker = new System.Windows.Forms.TabPage();
            this.btnPickColorState = new System.Windows.Forms.Button();
            this.lblColorHEX = new System.Windows.Forms.Label();
            this.lblColorRGB = new System.Windows.Forms.Label();
            this.lblColorReview = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabConfigUpdater = new System.Windows.Forms.TabPage();
            this.richTextLog = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.cbxKeepAwake = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tab.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.tabColorPicker.SuspendLayout();
            this.tabConfigUpdater.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabQuickHidePage);
            this.tab.Controls.Add(this.tabColorPicker);
            this.tab.Controls.Add(this.tabConfigUpdater);
            this.tab.Controls.Add(this.tabSettings);
            this.tab.Location = new System.Drawing.Point(0, -3);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(457, 402);
            this.tab.TabIndex = 0;
            // 
            // tabQuickHidePage
            // 
            this.tabQuickHidePage.AutoScroll = true;
            this.tabQuickHidePage.ContextMenuStrip = this.contextMenuStrip;
            this.tabQuickHidePage.Location = new System.Drawing.Point(4, 22);
            this.tabQuickHidePage.Name = "tabQuickHidePage";
            this.tabQuickHidePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuickHidePage.Size = new System.Drawing.Size(449, 376);
            this.tabQuickHidePage.TabIndex = 0;
            this.tabQuickHidePage.Text = "Quick Hide";
            this.tabQuickHidePage.UseVisualStyleBackColor = true;
            this.tabQuickHidePage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabQuickHidePage_MouseUp);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRefresh});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(121, 26);
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
            // 
            // menuItemRefresh
            // 
            this.menuItemRefresh.Name = "menuItemRefresh";
            this.menuItemRefresh.Size = new System.Drawing.Size(120, 22);
            this.menuItemRefresh.Text = "Refresh";
            // 
            // tabColorPicker
            // 
            this.tabColorPicker.Controls.Add(this.btnPickColorState);
            this.tabColorPicker.Controls.Add(this.lblColorHEX);
            this.tabColorPicker.Controls.Add(this.lblColorRGB);
            this.tabColorPicker.Controls.Add(this.lblColorReview);
            this.tabColorPicker.Controls.Add(this.label1);
            this.tabColorPicker.Location = new System.Drawing.Point(4, 22);
            this.tabColorPicker.Name = "tabColorPicker";
            this.tabColorPicker.Padding = new System.Windows.Forms.Padding(3);
            this.tabColorPicker.Size = new System.Drawing.Size(449, 376);
            this.tabColorPicker.TabIndex = 1;
            this.tabColorPicker.Text = "Color Picker";
            this.tabColorPicker.UseVisualStyleBackColor = true;
            // 
            // btnPickColorState
            // 
            this.btnPickColorState.Location = new System.Drawing.Point(189, 241);
            this.btnPickColorState.Name = "btnPickColorState";
            this.btnPickColorState.Size = new System.Drawing.Size(75, 23);
            this.btnPickColorState.TabIndex = 4;
            this.btnPickColorState.Text = "Start";
            this.btnPickColorState.UseVisualStyleBackColor = true;
            this.btnPickColorState.Click += new System.EventHandler(this.btnPickColorState_Click);
            // 
            // lblColorHEX
            // 
            this.lblColorHEX.AutoSize = true;
            this.lblColorHEX.Location = new System.Drawing.Point(161, 162);
            this.lblColorHEX.Name = "lblColorHEX";
            this.lblColorHEX.Size = new System.Drawing.Size(29, 12);
            this.lblColorHEX.TabIndex = 3;
            this.lblColorHEX.Text = "HEX:";
            // 
            // lblColorRGB
            // 
            this.lblColorRGB.AutoSize = true;
            this.lblColorRGB.Location = new System.Drawing.Point(161, 112);
            this.lblColorRGB.Name = "lblColorRGB";
            this.lblColorRGB.Size = new System.Drawing.Size(29, 12);
            this.lblColorRGB.TabIndex = 2;
            this.lblColorRGB.Text = "RGB:";
            // 
            // lblColorReview
            // 
            this.lblColorReview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColorReview.Location = new System.Drawing.Point(215, 59);
            this.lblColorReview.Name = "lblColorReview";
            this.lblColorReview.Size = new System.Drawing.Size(110, 29);
            this.lblColorReview.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color Perview:";
            // 
            // tabConfigUpdater
            // 
            this.tabConfigUpdater.Controls.Add(this.richTextLog);
            this.tabConfigUpdater.Controls.Add(this.button1);
            this.tabConfigUpdater.Location = new System.Drawing.Point(4, 22);
            this.tabConfigUpdater.Name = "tabConfigUpdater";
            this.tabConfigUpdater.Size = new System.Drawing.Size(449, 376);
            this.tabConfigUpdater.TabIndex = 3;
            this.tabConfigUpdater.Text = "Config Updater";
            this.tabConfigUpdater.UseVisualStyleBackColor = true;
            // 
            // richTextLog
            // 
            this.richTextLog.Location = new System.Drawing.Point(18, 14);
            this.richTextLog.Name = "richTextLog";
            this.richTextLog.ReadOnly = true;
            this.richTextLog.Size = new System.Drawing.Size(420, 287);
            this.richTextLog.TabIndex = 1;
            this.richTextLog.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Invoke";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.cbxKeepAwake);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(449, 376);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // cbxKeepAwake
            // 
            this.cbxKeepAwake.AccessibleDescription = "";
            this.cbxKeepAwake.AccessibleName = "";
            this.cbxKeepAwake.Checked = true;
            this.cbxKeepAwake.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxKeepAwake.Location = new System.Drawing.Point(20, 16);
            this.cbxKeepAwake.Name = "cbxKeepAwake";
            this.cbxKeepAwake.Size = new System.Drawing.Size(104, 24);
            this.cbxKeepAwake.TabIndex = 0;
            this.cbxKeepAwake.Text = "Keep Awake";
            this.cbxKeepAwake.UseVisualStyleBackColor = true;
            this.cbxKeepAwake.CheckedChanged += new System.EventHandler(this.cbxKeepAwake_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "OfficeHelper";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 396);
            this.Controls.Add(this.tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OfficeHelper - 你的划水神器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.tab.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.tabColorPicker.ResumeLayout(false);
            this.tabColorPicker.PerformLayout();
            this.tabConfigUpdater.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabQuickHidePage;
        private System.Windows.Forms.TabPage tabColorPicker;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Button btnPickColorState;
        private System.Windows.Forms.Label lblColorHEX;
        private System.Windows.Forms.Label lblColorRGB;
        private System.Windows.Forms.Label lblColorReview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxKeepAwake;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
        private System.Windows.Forms.TabPage tabConfigUpdater;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextLog;
    }
}