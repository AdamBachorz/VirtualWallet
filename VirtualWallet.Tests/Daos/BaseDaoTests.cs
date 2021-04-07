using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.Tests.Daos
{
    [TestFixture]
    public class BaseDaoTests<E> where E : Entity
    {
        protected IBaseDao<E> _baseDao;

        public BaseDaoTests()
        {

        }

        public BaseDaoTests(IBaseDao<E> baseDao)
        {
            _baseDao = baseDao;
        }

        [Test]
        public void ShouldNotThrow_SelectAll()
        {
            Assert.DoesNotThrow(() => _baseDao.GetAll());
        }
    }
}
