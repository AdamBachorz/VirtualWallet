using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Classes
{
    public enum IdentityStrategy
    {
        Sequance,
        Guid
    }

    public enum UserRole
    {
        Administrator = 1,
        User = 2,
    }
}
