using NHibernate;
using NHibernate.Criterion;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace VirtualWallet.DAL.Daos
{
    public abstract class BaseDao<E> : IBaseDao<E> where E : Entity 
    {
        protected readonly INHibernateHelper _nHibernateHelper;

        public BaseDao(INHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public E GetOneById(int id) => Invoke(session => session.Get<E>(id));
        public E GetLatest() => Invoke(session => session.Query<E>().OrderByDescending(e => e.Id).FirstOrDefault());
        public IList<E> GetAll() => Invoke(session => session.Query<E>().ToList());
        public IQueryable<E> GetAllLazy() => Invoke(session => session.Query<E>());

        public E Insert(E entity)
        {
            return Invoke((session, transaction) => {
                var obj = session.Save(entity);
                transaction.Commit();
                entity.Id = Convert.ToInt32(obj);
                return entity;
            });
        }

        public void Update(int id, E entity)
        {
            Invoke((session, transaction) => {
                entity.Id = id;
                session.SaveOrUpdate(entity);
                transaction.Commit();
            });
        }
        public void Update(E entity) => Update(entity.Id, entity);

        public void Delete(int id)
        {
            Invoke((session, transaction) => {
                var entityToDelete = session.Get<E>(id);
                if (entityToDelete == null)
                {
                    return;
                }

                session.Delete(entityToDelete);
                transaction.Commit();
            });
        }


        #region Invokers
        protected R Invoke<R>(Func<ISession, R> func)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                try
                {
                    return func(session);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected R Invoke<R>(Func<ISession, ITransaction, R> func)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        return func(session, transaction);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        protected void Invoke(Action<ISession, ITransaction> action)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        action(session, transaction);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion

    }
}
