using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualWallet.Common.Extensions;

namespace VirtualWallet.Model.Domain
{
    [Serializable]
    public class MonthlySpending : Entity
    {
        public virtual decimal Budget { get; set; }
        public virtual DateTime? CreationDate { get; set; }
        public virtual MonthlySpending PreviousMonthlySpending { get; set; }
        public virtual IList<Spending> Spendings { get; set; }
        public virtual SpendingGroup SpendingGroup { get; set; }


        public virtual int Month => CreationDate?.Month ?? 0;

        public virtual int Year => CreationDate?.Year ?? 0;

        public virtual string Title => $"{CreationDate?.GetMonthName()} {Year}";

        public virtual decimal SpendingSummary => Spendings?.Sum(s => s.Value) ?? 0;
        public virtual decimal PreviousMonthlySpendingSummaryBilance => (PreviousMonthlySpending?.SummaryBilance ?? 0);

        public virtual decimal SummaryBilance
            => this is null ? 0
            : Budget - SpendingSummary + PreviousMonthlySpendingSummaryBilance;


        public static MonthlySpending New(decimal budget, int year, int month, SpendingGroup spendingGroup, MonthlySpending previousMonthlySpending)
            => new MonthlySpending
            {
                Budget = budget,
                SpendingGroup = spendingGroup,
                PreviousMonthlySpending = previousMonthlySpending,
                CreationDate = new DateTime(year, month, 1),
                Spendings = new List<Spending>() //spendingGroup.ConstantSpendings.Select(cs  => cs.ToSpending())
            };
    }
}
