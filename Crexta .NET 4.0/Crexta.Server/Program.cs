using System;
using System.Linq;
using System.Windows.Forms;

using Crexta.Common.Logging;
using Crexta.Common.Enums;

namespace Crexta.Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Server());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string message = "";

            Logger logger = new Logger("Server_Crash_" + DateTime.Now.ToFileTime() + ".log", typeof(Server));

            message = "An exception occurred:\r\nMessage: " + e.Exception.Message + "\r\nStack Trace: " +
                e.Exception.StackTrace + "\r\n";
            if (e.Exception.InnerException != null)
            {
                message += "Inner Exception Message: " + e.Exception.InnerException.Message +
                    "Inner Exception Stack Trace: " + e.Exception.InnerException.StackTrace;
            }

            logger.WriteLog(LogLevel.FATAL, message);

            MessageBox.Show(e.Exception.Message, "An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
