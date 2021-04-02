using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace VirtualWallet.ApiConsumer.Utils
{
    public class InvokeResult
    {
        public string ResponseString { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public InvokeResult(string responseString, HttpStatusCode httpStatusCode)
        {
            ResponseString = responseString;
            HttpStatusCode = httpStatusCode;
        }

        public override string ToString() => $"{ResponseString} ({HttpStatusCode})";
    }
}
