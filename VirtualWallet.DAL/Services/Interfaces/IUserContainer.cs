using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Services.Interfaces
{
    public interface IUserContainer
    {
        void SignIn(User user, string reference);
        bool IsUserLoggedIn();
        bool IsUserLoggedIn(out User currentUser);
        User GetCurrentUser();
        SpendingGroup GetCurrentSpendingGroup();
        NetworkCredential Credential();
        void SignOut();
        void SetSpendingGroup(SpendingGroup spendingGroup);
    }
}
