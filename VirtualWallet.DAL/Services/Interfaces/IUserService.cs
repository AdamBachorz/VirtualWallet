using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VirtualWallet.DAL.Services.Interfaces
{
    public interface IUserService
    {
        bool IsValidUser(string username, string password);
        NetworkCredential UserCredential();
    }
}
