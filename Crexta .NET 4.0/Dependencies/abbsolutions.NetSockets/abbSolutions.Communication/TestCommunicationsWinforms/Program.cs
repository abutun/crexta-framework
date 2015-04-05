using System;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using abbSolutions.Communication.Interfaces;
using abbSolutions.Communication.ThreadSafeObjects;
using abbSolutions.Communication;

namespace abbSolutions
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
			Application.Run(new CommunicationsTest());
		}
	}
}
