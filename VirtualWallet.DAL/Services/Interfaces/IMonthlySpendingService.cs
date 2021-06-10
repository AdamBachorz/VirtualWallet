using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Services.Interfaces
{
    public interface IMonthlySpendingService
    {
        IEnumerable<MonthlySpending> AddInMonthRange(int year, decimal budget, int startMonth, int endMonth, int spendingGroupId, int userId);
        IEnumerable<MonthlySpending> AddInMonthRangeV2(int year, decimal budget, int startMonth, int endMonth, int spendingGroupId, int userId);
        IEnumerable<MonthlySpending> AddForWholeYear(int year, decimal budget, int spendingGroupId, int userId);
        IEnumerable<MonthlySpending> AddForWholeYearV2(int year, decimal budget, int spendingGroupId, int userId);
        MonthlySpending AddNew(int spendingGroupId, int userId, int year, int month);
        MonthlySpending Next(DateTime? currentMonthlySpendingDate, int spendingGroupId, int userId, bool forward);
    }
}
