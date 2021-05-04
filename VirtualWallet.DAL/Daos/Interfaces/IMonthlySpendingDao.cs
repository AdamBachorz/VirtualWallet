using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Daos.Interfaces
{
    public interface IMonthlySpendingDao : IBaseDao<MonthlySpending>
    {
        MonthlySpending GetByMonthAndYear(int spendingGroupId, int month, int year);
        IList<MonthlySpending> GetCurrentAndFurtherThan(DateTime? dateTime, int spendingGroupId);
    }
}
