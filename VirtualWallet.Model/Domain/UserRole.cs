using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain
{
    public class UserRole : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<User> Users { get; set; }
    }
}
