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
        private readonly ISpendingGroupDao _spendingGroupDao;
        private readonly IUserDao _userDao;

        public MonthlySpendingService(IMonthlySpendingDao monthlySpendingDao, ISpendingDao spendingDao, ISpendingGroupDao spendingGroupDao, IUserDao userDao)
        {
            _monthlySpendingDao = monthlySpendingDao;
            _spendingDao = spendingDao;
            _spendingGroupDao = spendingGroupDao;
            _userDao = userDao;
        }

        public IEnumerable<MonthlySpending> AddForWholeYear(int year, decimal budget, int spendingGroupId, int userId)
        {
            return AddInMonthRange(year, budget, 1, 12, spendingGroupId, userId);
        }

        public IEnumerable<MonthlySpending> AddForWholeYearV2(int year, decimal budget, int spendingGroupId, int userId)
        {
            return AddInMonthRangeV2(year, budget, 1, 12, spendingGroupId, userId);
        }

        public IEnumerable<MonthlySpending> AddInMonthRange(int year, decimal budget, int startMonth, int endMonth, int spendingGroupId, int userId)
        {
            var previousMonthlySpendingSummaryBilance = _monthlySpendingDao.GetLatest().SummaryBilance;
            var spendingGroup = _spendingGroupDao.GetOneById(spendingGroupId);
            var user = _userDao.GetOneById(userId);

            for (int m = startMonth; m <= endMonth; m++)
            {
                var creationDate = new DateTime(year, m, 1);
                var monthlySpending = MonthlySpending.New(spendingGroup, previousMonthlySpendingSummaryBilance, user, creationDate);

                spendingGroup.ConstantSpendings.ForEach(cs => 
                {
                    var newSpendingFromConstantSpending = cs.ToSpending(monthlySpending, user);
                    var justAddedSpending = _spendingDao.Insert(newSpendingFromConstantSpending);
                    monthlySpending.Spendings.Add(justAddedSpending);
                }); 

                var justAddedMonthlySpending = _monthlySpendingDao.Insert(monthlySpending);
                justAddedMonthlySpending.Spendings.ForEach(s => s.MonthlySpending = justAddedMonthlySpending);
                _monthlySpendingDao.Update(justAddedMonthlySpending);


                previousMonthlySpendingSummaryBilance = justAddedMonthlySpending.SummaryBilance;

                yield return justAddedMonthlySpending;
            }
                
        }

        public IEnumerable<MonthlySpending> AddInMonthRangeV2(int year, decimal budget, int startMonth, int endMonth, int spendingGroupId, int userId)
        {
            for (int month = startMonth; month <= endMonth; month++)
            {
                var justAddedMonthlySpending = AddNew(spendingGroupId, userId, year, month);
                yield return justAddedMonthlySpending;
            }
        }

        public MonthlySpending AddNew(int spendingGroupId, int userId, int year, int month)
        {
            var creationDate = new DateTime(year, month, 1);
            var spendingGroup = _spendingGroupDao.GetOneById(spendingGroupId);
            var user = _userDao.GetOneById(userId);
            var previousMonthlySpendingSummaryBilance = _monthlySpendingDao
                .GetByMonthAndYear(spendingGroupId, creationDate.AddMonths(-1).Month, creationDate.AddMonths(-1).Year)?.SummaryBilance ?? 0m;

            var monthlySpending = MonthlySpending.New(spendingGroup, previousMonthlySpendingSummaryBilance, user, creationDate);
            var newMonthlySpending = _monthlySpendingDao.Insert(monthlySpending);

            var convertedSpendings = spendingGroup.ConstantSpendings.Select(cs => cs.ToSpending(newMonthlySpending, user)).ToList();
            var newConvertedSpendings = _spendingDao.AddMany(convertedSpendings);
            newMonthlySpending.Spendings = newConvertedSpendings;
            _monthlySpendingDao.Update(newMonthlySpending);
            return newMonthlySpending;
        }

        public MonthlySpending Next(DateTime? currentMonthlySpendingDate, int spendingGroupId, int userId, bool forward)
        {
            var nextDate = currentMonthlySpendingDate?.AddMonths(forward ? 1 : -1);
            
            var nextMonthlySpending = _monthlySpendingDao.GetByDate(spendingGroupId, nextDate.Value);

            if (nextMonthlySpending == null)
            {
                var newNextMonthlySpending = AddNew(spendingGroupId, userId, nextDate.Value.Year, nextDate.Value.Month);
                return newNextMonthlySpending;
            }

            return nextMonthlySpending;
        }

    }
}
