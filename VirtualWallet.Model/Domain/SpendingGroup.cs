using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VirtualWallet.Model.Domain
{
    [Serializable]
    public class SpendingGroup : Entity
    {
        [DisplayName("Nazwa")]
        public virtual string Name { get; set; }
        [DisplayName("Budżet")]
        public virtual decimal Budget { get; set; }
        public virtual IEnumerable<ConstantSpending> ConstantSpendings { get; set; }
        public virtual IEnumerable<MonthlySpending> MonthlySpendings { get; set; }
    }
}
