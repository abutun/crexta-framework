using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crexta.Common.Crextor;

namespace Crexta.Client.Events
{
    public class CrextorChangedEventArgs : EventArgs
    {
        public int WorkerID { get; internal set; }

        public CrextorInfo CrextorInfo { get; internal set; }

        public CrextorChangedEventArgs(int workerID, CrextorInfo crextorInfo)
        {
            this.WorkerID = workerID;
            this.CrextorInfo = crextorInfo;
        }
    }
}
