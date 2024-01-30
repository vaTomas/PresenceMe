using PresenceMe.forms;
using System;
using System.Windows.Forms;

namespace PresenceMe
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
