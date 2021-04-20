using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Daos.Interfaces
{
    public interface IUserDao : IBaseDao<User>
    {
        User GetByCredential(NetworkCredential credential);
    }
}
