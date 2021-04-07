using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.Tests.Daos
{
    public class UserRoleDaoTests : BaseDaoTests<UserRole>
    {
        private readonly IUserRoleDao _userRoleDao;

        public UserRoleDaoTests() : base()
        {

        }

        public UserRoleDaoTests(IBaseDao<UserRole> baseDao, IUserRoleDao userRoleDao) : base(baseDao)
        {
            _userRoleDao = userRoleDao;
        }
    }
}
