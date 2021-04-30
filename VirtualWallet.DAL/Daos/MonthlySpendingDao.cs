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

        public MonthlySpending GetByMonthAndYear(int month, int year)
        {
            return Invoke(session => session.Query<MonthlySpending>()
            .FirstOrDefault(ms => ms.CreationDate.Value.Month == month && ms.CreationDate.Value.Year == year));
        }
    }
}
