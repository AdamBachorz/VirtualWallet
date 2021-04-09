using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Classes.Extensions;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Services
{
    public class UserService : IUserService
    {
        private static User _correct = new User
        {
            UserName = "test",
            PasswordHash = "test123"
        };

        public bool IsValidUser(string username, string password)
        {
            // TBE - user verify 

            return username.Equals(_correct.UserName) && password.Equals(_correct.PasswordHash);
        }

        public NetworkCredential UserCredential()
        {
            if (IsValidUser(_correct.UserName, _correct.PasswordHash))
            {
                return _correct.ToNetworkCredential();
            }
            else 
            {
                throw new UnauthorizedAccessException();
            }
        }

    }
}
