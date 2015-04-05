using System;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Text;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication
{
	public delegate T TDelegate<T>(DateTime dt) where T : class;
	public delegate void VoidDelegate();
	public delegate int TDelegateGeneralInt<T>(T item);
	public delegate bool TDelegateGeneralBool<T>(T item);
	public delegate bool TDelegateGeneralBool<T, T2>(T item, T2 additional);
	public delegate void TDelegateGeneral<T>(T item);
	public delegate bool TDidSomethingDelegateGeneral<T1, T2>(T1 item, out T2 outItem);
	public delegate double TDelegateGeneralDouble<T>(T item);
	public delegate T2 TDelegatePlain<T, T2>(T item) where T : class;
	public delegate T1 TPopulate<T1>();
	public delegate string TDelegateGeneralString<T>(T item);

	public static class Extensions
	{
		public static Thread CreateAndRunThread(this ThreadStart ts) { Thread t = CreateThread(ts); t.Start(); return t; }

		public static Thread CreateThread(this ThreadStart ts)
		{
			Thread t = new Thread(ts);
			t.TrySetApartmentState(ApartmentState.MTA);
			t.Priority = ThreadPriority.Normal;
			t.IsBackground = true;
			return t;
		}
	}
}

