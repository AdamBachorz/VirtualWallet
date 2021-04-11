using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Services.Interfaces
{
    public interface IMonthlySpendingService
    {
        IEnumerable<MonthlySpending> AddInMonthRange(int year, decimal budget, int startMonth, int endMonth);
    }
}
