using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace VirtualWallet.Common.Extensions
{
    public static class NetworkCredentialExtensions
    {
        public static string BuildBase64Token(this NetworkCredential credential)
            => "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{credential.UserName}:{credential.Password}"));
    }
}
