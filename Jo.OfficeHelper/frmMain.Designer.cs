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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblColorReview = new System.Windows.Forms.Label();
            this.lblColorRGB = new System.Windows.Forms.Label();
            this.lblColorHEX = new System.Windows.Forms.Label();
            this.btnPickColorState = new System.Windows.Forms.Button();
            this.cbxKeepAwake = new System.Windows.Forms.CheckBox();
            this.tab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabQuickHidePage);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Location = new System.Drawing.Point(0, -3);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(608, 402);
            this.tab.TabIndex = 0;
            // 
            // tabQuickHidePage
            // 
            this.tabQuickHidePage.AutoScroll = true;
            this.tabQuickHidePage.Location = new System.Drawing.Point(4, 22);
            this.tabQuickHidePage.Name = "tabQuickHidePage";
            this.tabQuickHidePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuickHidePage.Size = new System.Drawing.Size(600, 376);
            this.tabQuickHidePage.TabIndex = 0;
            this.tabQuickHidePage.Text = "Quick Hide";
            this.tabQuickHidePage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnPickColorState);
            this.tabPage2.Controls.Add(this.lblColorHEX);
            this.tabPage2.Controls.Add(this.lblColorRGB);
            this.tabPage2.Controls.Add(this.lblColorReview);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(600, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Color Picker";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbxKeepAwake);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(600, 376);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "OfficeHelper";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color:";
            // 
            // lblColorReview
            // 
            this.lblColorReview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColorReview.Location = new System.Drawing.Point(259, 52);
            this.lblColorReview.Name = "lblColorReview";
            this.lblColorReview.Size = new System.Drawing.Size(110, 29);
            this.lblColorReview.TabIndex = 1;
            // 
            // lblColorRGB
            // 
            this.lblColorRGB.AutoSize = true;
            this.lblColorRGB.Location = new System.Drawing.Point(205, 105);
            this.lblColorRGB.Name = "lblColorRGB";
            this.lblColorRGB.Size = new System.Drawing.Size(29, 12);
            this.lblColorRGB.TabIndex = 2;
            this.lblColorRGB.Text = "RGB:";
            // 
            // lblColorHEX
            // 
            this.lblColorHEX.AutoSize = true;
            this.lblColorHEX.Location = new System.Drawing.Point(205, 155);
            this.lblColorHEX.Name = "lblColorHEX";
            this.lblColorHEX.Size = new System.Drawing.Size(29, 12);
            this.lblColorHEX.TabIndex = 3;
            this.lblColorHEX.Text = "HEX:";
            // 
            // btnPickColorState
            // 
            this.btnPickColorState.Location = new System.Drawing.Point(259, 234);
            this.btnPickColorState.Name = "btnPickColorState";
            this.btnPickColorState.Size = new System.Drawing.Size(75, 23);
            this.btnPickColorState.TabIndex = 4;
            this.btnPickColorState.Text = "开始";
            this.btnPickColorState.UseVisualStyleBackColor = true;
            this.btnPickColorState.Click += new System.EventHandler(this.btnPickColorState_Click);
            // 
            // cbxKeepAwake
            // 
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 396);
            this.Controls.Add(this.tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "OfficeHelper - 你的划水神器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.tab.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabQuickHidePage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnPickColorState;
        private System.Windows.Forms.Label lblColorHEX;
        private System.Windows.Forms.Label lblColorRGB;
        private System.Windows.Forms.Label lblColorReview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxKeepAwake;
    }
}