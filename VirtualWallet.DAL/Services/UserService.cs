using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.DAL.Services
{
    public class UserService : IUserService
    {
        public bool IsValidUser(string username, string password)
        {
            var correct = new
            {
                Username = "test",
                Password = "test123"
            };

            return username.Equals(correct.Username) && password.Equals(correct.Password);
        }
    }
}
