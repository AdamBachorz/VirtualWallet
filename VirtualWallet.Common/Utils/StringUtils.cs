using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace VirtualWallet.Common.Utils
{
    public static class StringUtils
    {
        public static NetworkCredential DecodeBaseToken(string token)
        {
            if (token != null)
            {
                var authHeaderValue = AuthenticationHeaderValue.Parse(token);
                if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    var credentials = Encoding.UTF8
                                        .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
                                        .Split(new[] { ':' }, 2);
                    if (credentials.Length == 2)
                    {
                        return new NetworkCredential(credentials[0], credentials[1]);
                    }
                    else
                    {
                        throw new ArgumentException("Base token in invalid");
                    }
                }
                else
                {
                    throw new ArgumentException("Base token in invalid");
                }
            }
            else
            {
                return new NetworkCredential();
            }

        }
    }
}
