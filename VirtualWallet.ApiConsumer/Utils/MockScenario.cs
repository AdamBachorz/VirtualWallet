using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualWallet.ApiConsumer.Utils
{
    public class MockScenario
    {
        public InvokeResult Success { get; set; }
        public InvokeResult Error { get; set; }
        public InvokeResult Krzaki { get; set; }
        public InvokeResult Conflict { get; set; }
    }
}
