using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Services.Interfaces
{
    public interface IUserService
    {
        User GetByToken(string token);
        bool IsValidUser(NetworkCredential credential);
        bool IsAdmin(NetworkCredential credential);
    }
}
