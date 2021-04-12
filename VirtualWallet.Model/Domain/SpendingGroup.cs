using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain
{
    public class SpendingGroup : Entity
    {
        public virtual string Name { get; set; }
        public virtual decimal Budget { get; set; }
        public virtual IEnumerable<ConstantSpending> ConstantSpendings { get; set; }
        public virtual IEnumerable<MonthlySpending> MonthlySpendings { get; set; }
    }
}
