using System;
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
	/// <summary>
	/// A simple hello message to demonstrate how to transmit objects to/from client and server
	/// </summary>
	[Serializable]
	public class HelloMessage
	{
		public string Message { get; set; }

		public HelloMessage() { }
		public HelloMessage(string message) { Message = message; }
	}
}


