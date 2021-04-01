using VirtualWallet.DAL.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VirtualWallet.DAL.Daos.Interfaces
{
    public interface IBaseDao<E>
    {
        E GetOneById(int id);
        E GetLatest();
        IList<E> GetAll();
        IQueryable<E> GetAllLazy();
        E Insert(E entity);
        void Update(int id, E entity);
        void Update(E entity);
        void Delete(int id);
    }
}
