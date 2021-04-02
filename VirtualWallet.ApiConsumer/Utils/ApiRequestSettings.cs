using VirtualWallet.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualWallet.ApiConsumer.Utils
{
    public class ApiRequestSettings<T> where T : class
    {
        public string MethodName { get; set; }
        public MethodType MethodType { get; set; }
        public ContentType ContentType { get; set; } = ContentType.json;
        public string InputBody { get; set; }
        public string UrlConnector { get; set; } = "/";
        public Func<string, T> ResultDataInterpreter { get; set; }
        public IDictionary<string, string> AdditionalHeaders { get; set; }
        public InvokeResult MockResponse { get; set; }

        public bool IsMock => MockResponse?.ResponseString?.HasValue() ?? false;
    }
}
