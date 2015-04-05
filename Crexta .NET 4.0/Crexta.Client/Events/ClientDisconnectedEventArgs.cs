using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crexta.Common.Crextor;

namespace Crexta.Client.Events
{
    public class ClientDisconnectedEventArgs : EventArgs
    {
        public int WorkerID { get; internal set; }

        public ClientDisconnectedEventArgs(int workerID)
        {
            this.WorkerID = workerID;
        }
    }
}
