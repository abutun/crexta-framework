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
	/// Handles incoming messages received by the server
	/// </summary>
	public class ServerMessageHandler : IIncomingMessageHandler
	{
		public static int _messagesReceived = 0;

		public void HandleIncomingMessage(ICommIncomingConnection connection, ICommunicationsMessage message)
		{
			Interlocked.Increment(ref _messagesReceived);

			// We could also use the "type" parameter integer and avoid reflection/etc
			Type messageType = message.MessageContents.GetType();

			if (messageType == typeof(HelloMessage)) HandleHelloMessage(connection, message.MessageContents as HelloMessage);
			else if (messageType == typeof(SomeGameCommand)) HandleSomeGameCommand(message.MessageContents as SomeGameCommand);
			else { Console.WriteLine("Unknown command type: " + messageType.Name); }
		}

		public void HandleSomeGameCommand(SomeGameCommand command)
		{
			//Console.WriteLine(
			//       "Server received game command number " + command.CommandNumber.ToString() +
			//       " with message " + command.Message +
			//       " and " + command.AdditionalParameters.Count.ToString() +
			//       " additional parameters");
		}

		public void HandleHelloMessage(ICommIncomingConnection connection, HelloMessage hello)
		{
            connection.SendMessage("Ahmet" + connection.AssociatedID.ToString(), 1);
		}
	}	
}


