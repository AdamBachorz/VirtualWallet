using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
