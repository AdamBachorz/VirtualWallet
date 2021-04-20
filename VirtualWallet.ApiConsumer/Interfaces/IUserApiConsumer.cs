using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer.Interfaces
{
    public interface IUserApiConsumer : IBaseApiConsumer<User>
    {
        User GetByCredentials(string login, string password);
        //bool IsValidUser(NetworkCredential credential);
    }
}
