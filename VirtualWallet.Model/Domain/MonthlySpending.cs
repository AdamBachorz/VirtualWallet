using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualWallet.Model.Domain
{
    public class MonthlySpending : Entity
    {
        public virtual decimal Budget { get; set; }
        public virtual DateTime? CreationDate { get; set; }
        public virtual MonthlySpending PreviousMonthlySpending { get; set; }
        public virtual IEnumerable<Spending> Spendings { get; set; }


        public virtual int Month => CreationDate?.Month ?? 0;

        public virtual  int Year => CreationDate?.Year ?? 0;

        public virtual decimal SpendingSummary => Spendings?.Sum(s => s.Value) ?? 0;

        public virtual decimal SummaryBilance
            => this is null ? 0
            : Budget - SpendingSummary + (PreviousMonthlySpending?.SummaryBilance ?? 0);


        public static MonthlySpending New(decimal budget, int year, int month, MonthlySpending previousMonthlySpending)
            => new MonthlySpending
            {
                Budget = budget,
                PreviousMonthlySpending = previousMonthlySpending,
                CreationDate = new DateTime(year, month, 1)
            };
    }
}
