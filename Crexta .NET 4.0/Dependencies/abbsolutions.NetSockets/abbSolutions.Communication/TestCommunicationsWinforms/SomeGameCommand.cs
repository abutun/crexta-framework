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
	/// A dummy class to demonstrate how game commands might be transmitted from client to server
	/// </summary>
	[Serializable]
	public class SomeGameCommand
	{
		public int CommandNumber { get; set; }
		public string Message { get; set; }
		public List<SomeGameCommandParameters> AdditionalParameters { get; set; }

		public SomeGameCommand()
		{
			AdditionalParameters = new List<SomeGameCommandParameters>();
		}

		public SomeGameCommand(string message, int commandNumber, params SomeGameCommandParameters[] additionalParams)
		{
			AdditionalParameters = new List<SomeGameCommandParameters>(additionalParams);
			Message = message;
			CommandNumber = commandNumber;
		}
	}

	/// <summary>
	/// A dummy class to demonstrate nested additional parameters
	/// </summary>
	[Serializable]
	public class SomeGameCommandParameters
	{
		public int ParameterId { get; set; }
		public string Parameter { get; set; }
		public int SomeOtherField { get; set; }

		public SomeGameCommandParameters() { }

		public SomeGameCommandParameters(int parameterId, string parameter, int otherField)
		{
			ParameterId = parameterId;
			Parameter = parameter;
			SomeOtherField = otherField;
		}
	}
}


