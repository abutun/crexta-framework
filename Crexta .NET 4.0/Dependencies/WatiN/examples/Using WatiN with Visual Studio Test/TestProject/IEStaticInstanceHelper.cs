using System;
using System.Threading;
using WatiN.Core;

namespace TestProject
{
    public class IEStaticInstanceHelper
    {
        private IE _ie;
        private int _ieThread;
        private string _ieHwnd;

        public IEStaticInstanceHelper()
        {
            Console.WriteLine("created");
        }
        public IE IE
        {
            get
            {
                var currentThreadId = GetCurrentThreadId();
                Console.WriteLine(currentThreadId + ", was:" + _ieThread);
                if (currentThreadId != _ieThread)
                {
                    _ie = IE.AttachTo<IE>(Find.By("hwnd", _ieHwnd));
                    _ieThread = currentThreadId;
                }
                return _ie;
            }
            set
            {
                _ie = value;
                _ieHwnd = _ie.hWnd.ToString();
                _ieThread = GetCurrentThreadId();                   
            }
        }

        private int GetCurrentThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}