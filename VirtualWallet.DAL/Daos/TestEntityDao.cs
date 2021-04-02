using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Daos
{
    public class TestEntityDao : BaseDao<TestEntity>, ITestEntityDao
    {
        public TestEntityDao(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }

        public IEnumerable<TestEntity> GetTestAllLazy()
        {
            return Enumerable.Range(1, 100).Select(n => new TestEntity { Id = n, Text = "T" + n, Value = n + 0.54m });
        }
    }
}
