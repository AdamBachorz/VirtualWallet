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
    public class SpendingGroupApiConsumer : BaseApiConsumer<SpendingGroup>, ISpendingGroupApiConsumer
    {
        public SpendingGroupApiConsumer(ICustomConfig customConfig, IUserContainer userContainer) : base(customConfig, userContainer)
        {
        }

        public IList<SpendingGroup> GetForUser(int userId)
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<List<SpendingGroup>>
                {
                    MethodName = $"{ControllerSimpleName}/foruser/{userId}",
                    MethodType = MethodType.Get,
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<List<SpendingGroup>>(jsonResult)
                });

                return apiResponse.Response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
