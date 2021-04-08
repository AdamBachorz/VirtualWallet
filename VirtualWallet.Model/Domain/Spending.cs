using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain
{
    public class Spending : Entity
    {
        public virtual string Name { get; set; }
        public virtual decimal Budget { get; set; }
        public virtual User User { get; set; }
        //public virtual MonthlySpending MonthlySpending { get; set; }
    }
}
