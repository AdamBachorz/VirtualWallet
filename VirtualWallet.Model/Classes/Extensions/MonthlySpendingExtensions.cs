using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.Model.Classes.Extensions
{
    public static class MonthlySpendingExtensions
    {
        public static int Month(this MonthlySpending monthlySpending)
            => monthlySpending.CreationDate?.Month ?? 0;

        public static int Year(this MonthlySpending monthlySpending)
            => monthlySpending.CreationDate?.Year ?? 0;

        public static decimal SpendingSummary(this MonthlySpending monthlySpending)
            => monthlySpending.Spendings?.Sum(s => s.Value) ?? 0;

        public static decimal SummaryBilance(this MonthlySpending monthlySpending)
            => monthlySpending is null ? 0 
            : monthlySpending.Budget - SpendingSummary(monthlySpending) + (monthlySpending.PreviousMonthlySpending?.SummaryBilance() ?? 0);
    }
}
