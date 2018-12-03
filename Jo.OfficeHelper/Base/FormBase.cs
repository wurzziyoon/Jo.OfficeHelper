using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using static Jo.OfficeHelper.Business.CommonBiz;
using Jo.OfficeHelper.Business;
//using MaterialSkin;
//using MaterialSkin.Controls;

namespace Jo.OfficeHelper.Base
{
    //public class FormBase: MaterialForm
    public class FormBase : Form
    {
        private Form m_from { get; set; }
        //private readonly MaterialSkinManager m_materialSkinManager;

        public FormBase()
        {
            //m_materialSkinManager = MaterialSkinManager.Instance;
        }
        public void Init(Form frm)
        {
            this.m_from = frm;
            ReleaseEmbeddedResource("Jo.OfficeHelper.Resources.Icon.ico", Environment.CurrentDirectory + @"\Icon.ico");
            this.m_from.Icon = new System.Drawing.Icon(Environment.CurrentDirectory + @"\Icon.ico");

            //ReleaseEmbeddedResource("Jo.OfficeHelper.Resources.MaterialSkin.dll", Environment.CurrentDirectory + @"\MaterialSkin.dll");
            //m_materialSkinManager.AddFormToManage(this);
            //m_materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //m_materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        
    }
}
