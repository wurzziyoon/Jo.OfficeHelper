using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jo.OfficeHelper.Base;
using static Jo.OfficeHelper.Business.CommonBiz;
using System.Diagnostics;
using Jo.OfficeHelper.Business;
using System.Runtime.InteropServices;

namespace Jo.OfficeHelper
{
    public partial class frmMain : FormBase
    {
        [DllImport("user32", EntryPoint = "RegisterHotKey")]
        private static extern int RegisterHotKey(
                int hwnd,
                int id,
                int fsModifiers,
                int vk
        );
        [DllImport("user32", EntryPoint = "UnregisterHotKey")]
        private static extern int UnregisterHotKey(
                int hwnd,
                int id
        );

        private const int CONTROL_MARGIN = 10;
        public frmMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            base.Init(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {            
            InitQuickHide(CONTROL_MARGIN);
            notifyIcon.Icon = this.Icon;
            if (cbxKeepAwake.Checked)
            {
                KeepAwake();
            }
            else
            {
                CancelKeepAwake();
            }
        }

        private void InitQuickHide(int margin)
        {
            int height = margin;
            List<string> tmpProcess = new List<string>();
            foreach (Process p in Process.GetProcesses().OrderBy((t) => { return t.ProcessName; }))
            {
                CheckBox ckb = new CheckBox();
                if (!tmpProcess.Contains(p.ProcessName))
                {
                    tmpProcess.Add(p.ProcessName);
                    ckb.Name = p.ProcessName.ToString();
                    ckb.Text = p.ProcessName;
                    ckb.Left = margin;
                    ckb.Top = height;
                    ckb.Click += (ckbSender, ckbE) =>
                    {
                        CheckBox tmp = ckbSender as CheckBox;
                        ProcessHelper.GetInstance().AddProcess(tmp.Text);
                        //MessageBox.Show(tmp.Text);
                        //TODO:添加事件
                    };
                    ckb.Width = tabQuickHidePage.Width - margin * 4;
                    tabQuickHidePage.Controls.Add(ckb);
                    height += margin + ckb.Height;
                }
            }
        }

        private void btnPickColorState_Click(object sender, EventArgs e)
        {
            ColorPickerBiz biz = ColorPickerBiz.GetInstance();
            if (btnPickColorState.Text == "开始")
            {
                biz.OnGetColorFinished += (color) =>
                {
                    lblColorRGB.Text = "RGB:    (" + color.R.ToString() + "," + color.G.ToString() + "," + color.B.ToString() + ")";
                    lblColorHEX.Text = "HEX:    #" + color.R.ToString("X") + color.G.ToString("X") + color.B.ToString("X");
                    lblColorReview.BackColor = color;
                };
                biz.Start();
            }
            else
            {
                biz.Dispose();
                lblColorHEX.Text = "HEX:";
                lblColorRGB.Text = "RGB:";
                lblColorReview.BackColor = Color.Transparent;
            }
            btnPickColorState.Text = btnPickColorState.Text == "开始" ? "结束" : "开始";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ColorPickerBiz.GetInstance().Dispose();
            ProcessHelper.GetInstance().Dispose();
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            UnregisterHotKey((int)Process.GetCurrentProcess().MainWindowHandle, 0x23434);
        }

        private void cbxKeepAwake_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxKeepAwake.Checked)
            {
                KeepAwake();
            }
            else
            {
                CancelKeepAwake();
            }
        }

      
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x112)
            {
                if (m.WParam.ToInt32() == 0xF020)
                {
                    this.Visible = false;
                    return;
                }
            }
            else if (m.Msg == 0x0312)
            {
                if (m.WParam.ToInt32() == 0x23434)
                {
                    ProcessHelper.GetInstance().Toggle();
                }
            }
            base.WndProc(ref m);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            int i = RegisterHotKey((int)Process.GetCurrentProcess().MainWindowHandle, 0x23434, 2, 119);
        }
    }
}
