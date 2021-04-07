using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain
{
    public class UserSpendingGroup : Entity
    {
        public virtual User User { get; set; }
        public virtual SpendingGroup SpendingGroup { get; set; }
    }
}
