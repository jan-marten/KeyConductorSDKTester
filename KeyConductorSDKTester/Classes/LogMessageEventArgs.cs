using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyConductorSDKTester.Classes
{
    public class LogMessageEventArgs : EventArgs
    {
        public string Message { get; set; }

        public LogMessageEventArgs(string message)
        {
            Message = message;

        }

    }
}
