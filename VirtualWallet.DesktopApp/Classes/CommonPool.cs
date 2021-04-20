using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.Model.Classes;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DesktopApp.Classes
{
    public static class CommonPool
    {
        public static NetworkCredential Credential { get; set; }
        public static User CurrentUser { get; set; }
        public static SpendingGroup SpendingGroup { get; set; }

        public static void DisposeUser()
        {
            Credential = null;
            CurrentUser = null;
            SpendingGroup = null;
        }

        public static bool UserIsLoggedIn => CurrentUser != null;
        public static bool UserIsAdmin => UserIsLoggedIn ? CurrentUser?.UserRole == UserRole.Administrator : false;
    }
}
