using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace VirtualWallet.ApiConsumer.Utils
{
    public class ApiResponse<T> where T : class
    {
        public string ResponseString { get; set; }
        public T Response { get; set; }
        public ApiResponseStatus Status { get; set; } = ApiResponseStatus.None;
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
