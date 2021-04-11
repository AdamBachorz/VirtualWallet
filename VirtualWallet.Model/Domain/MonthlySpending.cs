using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain
{
    public class MonthlySpending : Entity
    {
        public virtual decimal Budget { get; set; }
        public virtual DateTime? CreationDate { get; set; }
        public virtual MonthlySpending PreviousMonthlySpending { get; set; }
        public virtual IEnumerable<Spending> Spendings { get; set; }
    }
}
