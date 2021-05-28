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
        public virtual decimal PreviousMonthlySpendingSummaryBilance { get; set; }
        public virtual IList<Spending> Spendings { get; set; }
        public virtual SpendingGroup SpendingGroup { get; set; }


        public virtual int Month => CreationDate?.Month ?? 0;

        public virtual int Year => CreationDate?.Year ?? 0;

        public virtual string Title => $"{CreationDate?.GetMonthName()} {Year}";

        public virtual decimal SpendingSummary => Spendings?.Sum(s => s.Value) ?? 0;

        public virtual decimal SummaryBilance
            => this is null ? 0
            : Budget - SpendingSummary + PreviousMonthlySpendingSummaryBilance;


        public static MonthlySpending New(SpendingGroup spendingGroup, MonthlySpending previousMonthlySpending, User user, DateTime creationDate)
            => new MonthlySpending
            {
                Budget = spendingGroup.Budget,
                SpendingGroup = spendingGroup,
                PreviousMonthlySpendingSummaryBilance = previousMonthlySpending?.SummaryBilance ?? 0,
                CreationDate = creationDate,
                Spendings = spendingGroup.ConstantSpendings.Select(cs  => cs.ToSpending(previousMonthlySpending, user)).ToList()
            };
    }
}
