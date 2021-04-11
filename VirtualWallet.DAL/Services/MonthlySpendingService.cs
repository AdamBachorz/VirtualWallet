using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Services
{
    public class MonthlySpendingService : IMonthlySpendingService
    {
        private readonly IMonthlySpendingDao _monthlySpendingDao;

        public MonthlySpendingService(IMonthlySpendingDao monthlySpendingDao)
        {
            _monthlySpendingDao = monthlySpendingDao;
        }

        public IEnumerable<MonthlySpending> AddInMonthRange(int year, decimal budget, int startMonth, int endMonth)
        {
            var previousMonthlySpending = _monthlySpendingDao.GetLatest();

            for (int m = startMonth; m <= endMonth; m++)
            {
                var justAdded = _monthlySpendingDao.Insert(MonthlySpending.New(budget, year, m, previousMonthlySpending));

                previousMonthlySpending = justAdded;

                yield return justAdded;
            }
                
        }

    }
}
