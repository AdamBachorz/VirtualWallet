using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.Common.Extensions;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Classes;
using VirtualWallet.Model.Classes.Extensions;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Services
{
    public class UserService : IUserService
    {
        private IUserDao _userDao;

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public bool IsValidUser(NetworkCredential credential)
        {
            var user = _userDao.GetByCredential(credential);

            if (user is null)
            {
                return false;
            }

            var userIsValid = credential.UserName.Equals(user.UserName)
                && credential.Password.Encrypt().Equals(user.PasswordHash);

            return userIsValid || IsAdmin(credential);
        }

        public bool IsAdmin(NetworkCredential credential)
        {
            var user = _userDao.GetByCredential(credential);

            if (user is null)
            {
                return false;
            }

            return credential.UserName.Equals(user.UserName)
                && credential.Password.Encrypt().Equals(user.PasswordHash) 
                && user.UserRole == UserRole.Administrator;
        }

    }
}
