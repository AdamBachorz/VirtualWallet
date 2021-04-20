using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer.Interfaces
{
    public interface IBaseApiConsumer<E> where E : Entity
    {
        void SetAuthorization(NetworkCredential networkCredential);
        E GetOneById(int id);
        E GetLatest();
        IList<E> GetAll();
        E Insert(E entity);
        void Update(E entity);
        void Delete(int id);
    }
}
