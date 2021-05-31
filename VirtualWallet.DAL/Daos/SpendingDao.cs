using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualWallet.Common.Extensions;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Daos
{
    public class SpendingDao : BaseDao<Spending>, ISpendingDao
    {
        public SpendingDao(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }

        public IList<Spending> AddMany(IList<Spending> spendings)
        {
            var result = new List<Spending>();
            spendings.ForEach(s => result.Add(Insert(s)));
            return result;
        }

        public IList<Spending> GetSpendingsForMonthlySpending(int monthlySpendingId)
        {
            return Invoke(session => session.Query<Spending>().Where(s => s.MonthlySpending.Id == monthlySpendingId).ToList());
        }
    }
}
