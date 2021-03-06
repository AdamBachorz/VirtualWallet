using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWallet.API.Config
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthAttribute : TypeFilterAttribute
    {
        public BasicAuthAttribute(bool userAccess = false, string realm = @"My Realm") : base(typeof(BasicAuthFilter))
        {
            Arguments = new object[] { userAccess, realm };
        }
    }
}
