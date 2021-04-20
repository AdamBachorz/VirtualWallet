using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DesktopApp.Classes
{
    public class UserContainer : IUserContainer
    {
        private static UserContainer _instance;
        private User _currentUser;
        private string _reference;

        public static UserContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserContainer();
                }

                return _instance;
            }
        }

        public NetworkCredential Credential()
        {
           if (_currentUser == null)
           {
               return new NetworkCredential();
           }
           return new NetworkCredential(_currentUser.UserName, _reference);
        }

        public User GetCurrent()
        {
            return _currentUser;
        }

        public void SignIn(User user, string reference)
        {
            _currentUser = user;
            _reference = reference;
        }
    }
}
