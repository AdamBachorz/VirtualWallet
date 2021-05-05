using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.Common;
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
            if (!IsUserLoggedIn(out var current))
            {
                return null;
            }
            _httpContextAccessor.HttpContext.Session.TryGetValue(Codes.SessionKeys.Reference, out var referenceByteArray);
            return new NetworkCredential(current.UserName, referenceByteArray.FromByteArray<string>()); 
        }

        public User GetCurrentUser()
        {
            var userIsLoggedIn =_httpContextAccessor.HttpContext.Session.TryGetValue(Codes.SessionKeys.User, out var userByteArray);

            return userIsLoggedIn ? userByteArray.FromByteArray<User>() : null;
        }

        public SpendingGroup GetCurrentSpendingGroup()
        {
            var spendingGroupPicked = _httpContextAccessor.HttpContext.Session.TryGetValue(Codes.SessionKeys.SpendingGroup, out var spendingGroupByteArray);

            return spendingGroupPicked ? spendingGroupByteArray.FromByteArray<SpendingGroup>() : null;
        }

        public void SetSpendingGroup(SpendingGroup spendingGroup)
        {
            _httpContextAccessor.HttpContext.Session.Set(Codes.SessionKeys.SpendingGroup, spendingGroup.ToByteArray());
        }

        public void SignIn(User user, string reference)
        {
            _httpContextAccessor.HttpContext.Session.Set(Codes.SessionKeys.User, user.ToByteArray());
            _httpContextAccessor.HttpContext.Session.Set(Codes.SessionKeys.Reference, reference.ToByteArray());
        }

        public void SignOut()
        {
            _httpContextAccessor.HttpContext.Session.Remove(Codes.SessionKeys.User);
            _httpContextAccessor.HttpContext.Session.Remove(Codes.SessionKeys.Reference);
            _httpContextAccessor.HttpContext.Session.Remove(Codes.SessionKeys.SpendingGroup);
        }

        public bool IsUserLoggedIn() => GetCurrentUser() != null;
        public bool IsUserLoggedIn(out User currentUser)
        {
            currentUser = GetCurrentUser();
            return currentUser != null;
        }
    }
}
