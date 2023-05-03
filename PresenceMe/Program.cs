using PresenceMe.forms;
using PresenceMe.src;
using System;
using System.Windows.Forms;

namespace PresenceMe
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Database waterfalls = new Database();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
