using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace Jo.OfficeHelper.Business
{

    public static class CommonBiz
    {
        [DllImport("advapi32.dll", EntryPoint = "RegOpenKey")]
        private static extern int RegOpenKey(
                uint hKey,
                string lpSubKey,
                ref int phkResult
        );
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern uint RegSetValueEx(
      UIntPtr hKey,
      [MarshalAs(UnmanagedType.LPStr)]
     string lpValueName,
      int Reserved,
      int dwType,
      IntPtr lpData,
      int cbData);
        [DllImport("advapi32.dll", EntryPoint = "RegCloseKey")]
        private static extern int RegCloseKey(
                int hKey
        );
        [DllImport("advapi32.dll", EntryPoint = "RegDeleteKey")]
        private static extern int RegDeleteKey(
        int hKey,
        string lpSubKey
        );
        [DllImport("advapi32.dll", EntryPoint = "RegCreateKey")]
        private static extern int RegCreateKey(
        int hKey,
        string lpSubKey,
        ref int phkResult
        );
        [DllImport("user32", EntryPoint = "SystemParametersInfo")]
        private static extern int SystemParametersInfo(
        int uAction,
        int uParam,
        ref int lpvParam,
        int fuWinIni
        );
        [DllImport("Kernel32", EntryPoint = "SetThreadExecutionState")]
        private static extern uint SetThreadExecutionState(
        ExecutionFlag esFlags
        );
        [Flags]
        enum ExecutionFlag : uint
        {
            ES_SYSTEM_REQUIRED = 0x00000001,//通过重置系统空闲计时器强制系统处于工作状态。
            ES_DISPLAY_REQUIRED = 0x00000002, //通过重置显示空闲计时器来强制显示处于打开状态
            ES_CONTINUOUS = 0x80000000, //设置的状态应该保持有效，直到下一次调用 无需使用timer重复执行
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_USER_PRESENT = 0x00000004
        }
        private const int SPI_GETSCREENSAVEACTIVE = 16;
        private const int SPI_SETSCREENSAVEACTIVE = 17;
        public static void ReleaseEmbeddedResource(string strNamespace, string strReleasePath)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(strNamespace))
            {
                if (stream != null)
                {
                    if (!File.Exists(strReleasePath))
                    {
                        using (FileStream fs = new FileStream(strReleasePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                        {
                            int content;
                            while ((content = stream.ReadByte()) != -1)
                            {
                                fs.WriteByte((byte)content);
                            }
                        }
                    }
                }

            }
        }

        public static void KeepAwake()
        {
            int flag = 0;
            SystemParametersInfo(SPI_GETSCREENSAVEACTIVE, 0, ref flag, 0);
            if (flag > 0)
            {
                flag = 0;
                SystemParametersInfo(SPI_SETSCREENSAVEACTIVE, 0, ref flag, 0);
            }
            uint res = SetThreadExecutionState(ExecutionFlag.ES_CONTINUOUS | ExecutionFlag.ES_SYSTEM_REQUIRED | ExecutionFlag.ES_DISPLAY_REQUIRED);
            if (res > 0)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }

        public static void CancelKeepAwake()
        {
            int flag = 0;
            SystemParametersInfo(SPI_SETSCREENSAVEACTIVE, 1, ref flag, 0);
            SetThreadExecutionState(ExecutionFlag.ES_CONTINUOUS);
        }

        public static string ToString(this string str, Encoding toEncoding, Encoding fromEncoding = null)
        {
            if (toEncoding == null)
            {
                return null;
            }
            fromEncoding = fromEncoding ?? Encoding.UTF8;
            byte[] strBytes = fromEncoding.GetBytes(str);
            byte[] resultStrBytes = Encoding.Convert(fromEncoding, toEncoding, strBytes);
            char[] resultStrChars = new char[toEncoding.GetCharCount(resultStrBytes)];
            toEncoding.GetChars(resultStrBytes, 0, resultStrChars.Length);
            return new string(resultStrChars);
        }
    }
}
