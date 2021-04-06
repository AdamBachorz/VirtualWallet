using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer.Interfaces
{
    public interface ITestEntityApiConsumer : IBaseApiConsumer<TestEntity>
    {
        IList<TestEntity> GetTest();
    }
}
