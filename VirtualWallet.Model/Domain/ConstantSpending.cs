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

        public Spending ToSpending(MonthlySpending monthlySpending, User user)
        {
            return new Spending
            {
                Name = this.Name,
                Value = this.Value,
                MonthlySpending = monthlySpending,
                User = user
            };
        }
    }
}
