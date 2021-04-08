using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain
{
    public class ConstantSpending : Entity
    {
        public virtual string Name { get; set; }
        public virtual decimal Value { get; set; }
        public virtual SpendingGroup SpendingGroup { get; set; }
    }
}
