using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Daos
{
    public class UserRoleDao : BaseDao<UserRole>, IUserRoleDao
    {
        public UserRoleDao(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
