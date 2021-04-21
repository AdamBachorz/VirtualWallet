using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer.Interfaces
{
    public interface IUserApiConsumer : IBaseApiConsumer<User>
    {
        User GetByToken(string token);
        //bool IsValidUser(NetworkCredential credential);
    }
}
