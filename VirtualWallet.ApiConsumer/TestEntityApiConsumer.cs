using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer
{
    public class TestEntityApiConsumer : BaseApiConsumer<TestEntity>, ITestEntityApiConsumer
    {
        public TestEntityApiConsumer(ICustomConfig customConfig, IUserService userService) : base(customConfig, userService)
        {
        }

        public override string ControllerSimpleName => "testentity";
    }
}
