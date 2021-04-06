using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.ApiConsumer.Utils;
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

        public IList<TestEntity> GetTest()
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<List<TestEntity>>
                {
                    MethodName = ControllerSimpleName + "/test",
                    MethodType = MethodType.Get,
                    InputBody = null,
                    ContentType = ContentType.json,
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<List<TestEntity>>(jsonResult)
                });

                return apiResponse.Response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override string ControllerSimpleName => "testentity";
    }
}
