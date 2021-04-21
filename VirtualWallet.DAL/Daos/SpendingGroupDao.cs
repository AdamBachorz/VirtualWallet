using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Daos
{
    public class SpendingGroupDao : BaseDao<SpendingGroup>, ISpendingGroupDao
    {
        public SpendingGroupDao(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }

        public IList<SpendingGroup> GetForUser(int userId)
        {
            return Invoke(session => 
                session.Query<UserSpendingGroup>()
                    .Where(usg => usg.User.Id == userId)
                    .Select(usg => usg.SpendingGroup)
                    .ToList()
            );
        }
    }
}
