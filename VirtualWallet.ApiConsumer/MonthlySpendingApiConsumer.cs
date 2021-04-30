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
    public class MonthlySpendingApiConsumer : BaseApiConsumer<MonthlySpending>, IMonthlySpendingApiConsumer
    {
        public MonthlySpendingApiConsumer(ICustomConfig customConfig, IUserContainer userContainer) : base(customConfig, userContainer)
        {
        }

        public MonthlySpending GetByMonthAndYear(int month, int year)
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<MonthlySpending>
                {
                    MethodName = $"{ControllerSimpleName}/bymonthandyear/{month}/{year}",
                    MethodType = MethodType.Get,
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<MonthlySpending>(jsonResult)
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
