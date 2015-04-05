using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WatiN.Core;

namespace TestProject
{
    [TestClass]
    public class UnitTest 
    {
        private static IEStaticInstanceHelper ieStaticInstanceHelper;
        private static int _ieThread;

        [ClassInitialize]
        [STAThread]
        public static void testInit(TestContext testContext)
        {
            ieStaticInstanceHelper = new IEStaticInstanceHelper();
            Settings.AutoStartDialogWatcher = false;
            ieStaticInstanceHelper.IE = new IE("http://news.bbc.co.uk");
            _ieThread = Thread.CurrentThread.ManagedThreadId;
        }

        public IE IE
        {
            get { return ieStaticInstanceHelper.IE; }
            set { ieStaticInstanceHelper.IE = value; }
        }

        [ClassCleanup]
        [STAThread]
        public static void MyClassCleanup()
        {
            ieStaticInstanceHelper.IE.Close();
            ieStaticInstanceHelper = null;
        }

        [TestMethod]
        [STAThread]
        public void testOne()
        {
            lock (this)
            {
                Assert.AreEqual(_ieThread, Thread.CurrentThread.ManagedThreadId);
                Assert.IsTrue(IE.ContainsText("Low graphics"));
            }
        }

        [TestMethod]
        [STAThread]
        public void testTwo()
        {
            lock (this)
            {
                Assert.AreNotEqual(_ieThread, Thread.CurrentThread.ManagedThreadId);
                Assert.IsTrue(IE.ContainsText("Low graphics"));
            }
        }
        [TestMethod]
        [STAThread]
        public void testThree()
        {
            lock (this)
            {
                Assert.AreNotEqual(_ieThread, Thread.CurrentThread.ManagedThreadId);
                Assert.IsTrue(IE.ContainsText("Low graphics"));
            }
        }
    }
}
