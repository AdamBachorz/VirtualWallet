using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using VirtualWallet.Common.Extensions;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Daos
{
    public class UserDao : BaseDao<User>, IUserDao
    {
        public UserDao(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }

        public User GetByCredential(NetworkCredential credential)
        {
            return Invoke(session => 
                session.Query<User>()
                .FirstOrDefault(x => x.UserName == credential.UserName && x.PasswordHash == credential.Password.Encrypt())
            );
        }
    }
}
