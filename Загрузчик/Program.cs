using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Загрузчик
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Environment.OSVersion.Version.Major >= 6) // Для Windows 7 и выше
                SetProcessDPIAware();


            Application.Run(new Form1());
        }
    }
}
