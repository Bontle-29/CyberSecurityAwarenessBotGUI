using System;
using System.Windows.Forms;
using CyberSecurityAwarenessBotGUI.Forms;

namespace CyberSecurityAwarenessBotGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
