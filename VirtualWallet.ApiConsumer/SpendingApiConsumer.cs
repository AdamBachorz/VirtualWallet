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
    public class SpendingApiConsumer : BaseApiConsumer<Spending>, ISpendingApiConsumer
    {
        public SpendingApiConsumer(ICustomConfig customConfig, IUserContainer userContainer) : base(customConfig, userContainer)
        {
        }

        public IEnumerable<Spending> GetSpendingsForMonthlySpending(int monthlySpendingId)
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<List<Spending>>
                {
                    MethodName = $"{ControllerSimpleName}/formonthlyspending/{monthlySpendingId}",
                    MethodType = MethodType.Get,
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<List<Spending>>(jsonResult)
                });

                return apiResponse.Response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
