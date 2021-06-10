using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer.Interfaces
{
    public interface IMonthlySpendingApiConsumer : IBaseApiConsumer<MonthlySpending>
    {
        MonthlySpending GetNext(DateTime? currentMonthlySpendingDate, int spendingGroupId, int userId, bool forward);
        MonthlySpending GetByMonthAndYear(int spendingGroupId, int month, int year);
        IList<MonthlySpending> GetCurrentAndFurtherThan(DateTime? dateTime, int spendingGroupId);
        MonthlySpending Add(int spendingGroupId, int userId, int year, int month);
    }
}
