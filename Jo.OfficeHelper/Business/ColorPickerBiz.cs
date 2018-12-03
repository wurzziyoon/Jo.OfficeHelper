using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Jo.OfficeHelper.Business
{
    public class ColorPickerBiz : IDisposable
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32", EntryPoint = "GetCursorPos")]
        private static extern int GetCursorPos(
                ref POINTAPI lpPoint
        );

        [DllImport("user32", EntryPoint = "GetDC")]
        private static extern int GetDC(
                int hwnd
        );
        [DllImport("gdi32", EntryPoint = "GetPixel")]
        private static extern int GetPixel(
               int hdc,
               int x,
               int y
       );

        private static ColorPickerBiz m_instance;
        private static object m_lockObj = new object();
        private static System.Timers.Timer m_timer;
        private Task m_getColorTask;
        public event Action<Color> OnGetColorFinished;

        private ColorPickerBiz()
        {

        }

        public static ColorPickerBiz GetInstance()
        {
            if (m_instance == null)
            {
                lock (m_lockObj)
                {
                    if (m_instance == null)
                    {
                        m_instance = new ColorPickerBiz();
                    }
                }
            }
            return m_instance;
        }

        public void Start()
        {
            if (m_getColorTask == null)
            {
                Action getColorAction = () =>
                 {
                     m_timer = new System.Timers.Timer(200);
                     m_timer.Elapsed += (sender, e) =>
                     {
                         Color color = GetColorByMousePos();
                         if (OnGetColorFinished != null)
                         {
                             OnGetColorFinished.Invoke(color);
                         }
                     };
                     m_timer.Start();
                 };
                m_getColorTask = new Task(getColorAction);
                m_getColorTask.Start();
            }
        }

        private static Color GetColorByMousePos()
        {
            POINTAPI pos = new POINTAPI();
            GetCursorPos(ref pos);
            int dc = GetDC(0);
            int intColor = GetPixel(dc, pos.x, pos.y);
            int b = intColor / (256 * 256);
            int g = (intColor - b * 256 * 256) / 256;
            int r = (intColor - b * 256 * 256 - g * 256);
            return Color.FromArgb(r, g, b);

        }


        #region IDisposable Support
        // 要检测冗余调用
        private bool disposedValue
        {
            get
            {
                if (m_getColorTask == null && (m_timer!=null && m_timer.Enabled==false))
                {
                    return true;
                }
                return false;
            }
        }

        
       
        public void Dispose()
        {
            if (!disposedValue)
            {
                if (m_timer != null)
                {
                    m_timer.Stop();
                    m_timer.Dispose();
                }
                m_getColorTask = null;
                GC.SuppressFinalize(this);
            } 
        }
        #endregion

    }
}
