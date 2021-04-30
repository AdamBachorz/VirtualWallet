using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualWallet.Common.Extensions;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Services
{
    public class MonthlySpendingService : IMonthlySpendingService
    {
        private readonly IMonthlySpendingDao _monthlySpendingDao;
        private readonly ISpendingDao _spendingDao;

        public MonthlySpendingService(IMonthlySpendingDao monthlySpendingDao, ISpendingDao spendingDao)
        {
            _monthlySpendingDao = monthlySpendingDao;
            _spendingDao = spendingDao;
        }

        public IEnumerable<MonthlySpending> AddForWholeYear(int year, decimal budget, SpendingGroup spendingGroup, User user)
        {
            return AddInMonthRange(year, budget, 1, 12, spendingGroup, user);
        }

        public IEnumerable<MonthlySpending> AddInMonthRange(int year, decimal budget, int startMonth, int endMonth, SpendingGroup spendingGroup, User user)
        {
            var previousMonthlySpending = _monthlySpendingDao.GetLatest();

            for (int m = startMonth; m <= endMonth; m++)
            {
                var monthlySpending = MonthlySpending.New(budget, year, m, spendingGroup, previousMonthlySpending);

                spendingGroup.ConstantSpendings.ForEach(cs => 
                {
                    var newSpendingFromConstantSpending = cs.ToSpending(monthlySpending, user);
                    var justAddedSpending = _spendingDao.Insert(newSpendingFromConstantSpending);
                    monthlySpending.Spendings.Add(justAddedSpending);
                }); 

                var justAddedMonthlySpending = _monthlySpendingDao.Insert(monthlySpending);
                justAddedMonthlySpending.Spendings.ForEach(s => s.MonthlySpending = justAddedMonthlySpending);
                _monthlySpendingDao.Update(justAddedMonthlySpending);
                

                previousMonthlySpending = justAddedMonthlySpending;

                yield return justAddedMonthlySpending;
            }
                
        }

    }
}
