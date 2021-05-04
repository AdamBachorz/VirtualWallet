using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.Common.Extensions;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Services
{
    public class UserContainer : IUserContainer
    {
        private readonly IUserDao _userDao;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContainer(IUserDao userDao, IHttpContextAccessor httpContextAccessor)
        {
            _userDao = userDao;
            _httpContextAccessor = httpContextAccessor;
        }

        public NetworkCredential Credential()
        {
            var current = GetCurrent();
            _httpContextAccessor.HttpContext.Session.TryGetValue("reference", out var referenceByteArray);
            return current != null ? new NetworkCredential(current.UserName, referenceByteArray.FromByteArray<string>()) : null; 
        }

        public User GetCurrent()
        {
            var userIsLoggedIn =_httpContextAccessor.HttpContext.Session.TryGetValue("user", out var userByteArray);

            return userIsLoggedIn ? userByteArray.FromByteArray<User>() : null;
        }

        public void SignIn(User user, string reference)
        {
            _httpContextAccessor.HttpContext.Session.Set("user", user.ToByteArray());
            _httpContextAccessor.HttpContext.Session.Set("referecne", reference.ToByteArray());
        }

        public void SignOut()
        {
            _httpContextAccessor.HttpContext.Session.Remove("user");
            _httpContextAccessor.HttpContext.Session.Remove("referecne");
        }
    }
}
