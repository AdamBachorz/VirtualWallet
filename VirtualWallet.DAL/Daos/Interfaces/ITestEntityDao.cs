using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Daos.Interfaces
{
    public interface ITestEntityDao : IBaseDao<TestEntity>
    {
        IEnumerable<TestEntity> GetTestAllLazy();
    }
}
