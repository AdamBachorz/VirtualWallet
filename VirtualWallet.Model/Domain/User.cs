using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.Model.Classes;

namespace VirtualWallet.Model.Domain
{
    public class User : Entity
    {
        public virtual string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string Email { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
