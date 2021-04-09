using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.Model.Classes.Extensions
{
    public static class UserExtensions
    {
        public static NetworkCredential ToNetworkCredential(this User user) 
            => new NetworkCredential(user.UserName, user.PasswordHash);
    }
}
