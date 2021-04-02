using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer.Interfaces
{
    public interface IBaseApiConsumer<E> where E : Entity
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
