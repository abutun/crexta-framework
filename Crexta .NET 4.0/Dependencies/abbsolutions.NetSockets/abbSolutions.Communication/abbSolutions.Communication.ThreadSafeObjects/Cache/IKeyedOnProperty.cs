using System;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using abbSolutions.Communication.ThreadSafeObjects;
using abbSolutions.Communication.HyperTypeDescriptor;

namespace abbSolutions.Communication.ThreadSafeObjects
{		
	public interface IKeyedOnProperty<T>
	{
		T Key { get; }
	}
}
