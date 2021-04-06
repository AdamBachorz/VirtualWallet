using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualWallet.DesktopApp.Classes.Config;

namespace VirtualWallet.DesktopApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        
        private static readonly MySimpleInjector _simpleInjector = new MySimpleInjector();

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _simpleInjector.RegisterSingleton();
            _simpleInjector.Register();
            Application.Run(_simpleInjector.MainViewInstance);
        }
    }
}
