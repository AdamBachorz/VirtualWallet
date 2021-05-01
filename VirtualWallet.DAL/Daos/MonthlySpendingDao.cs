using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Daos
{
    public class MonthlySpendingDao : BaseDao<MonthlySpending>, IMonthlySpendingDao
    {
        public MonthlySpendingDao(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }

        public MonthlySpending GetByMonthAndYear(int month, int year) // add user or spending group Id
        {
            return Invoke(session => session.Query<MonthlySpending>()
            .FirstOrDefault(ms => ms.CreationDate.Value.Month == month && ms.CreationDate.Value.Year == year));
        }

        public IList<MonthlySpending> GetCurrentAndFurtherThan(DateTime? dateTime, int spendingGroupId)
        {
            return Invoke(session => session.Query<MonthlySpending>()
            .Where(ms => ms.SpendingGroup.Id == spendingGroupId && ms.CreationDate >= dateTime).ToList());
        }
    }
}
