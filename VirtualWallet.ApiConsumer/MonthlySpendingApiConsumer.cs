using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.ApiConsumer.Utils;
using VirtualWallet.Common;
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

        public MonthlySpending GetNext(DateTime? currentMonthlySpendingDate, int spendingGroupId, int userId, bool forward)
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<MonthlySpending>
                {
                    MethodName = $"{ControllerSimpleName}/next/{currentMonthlySpendingDate?.ToString("yyyy-MM-dd")}/{spendingGroupId}/{userId}/{forward}",
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

        public MonthlySpending GetByMonthAndYear(int spendingGroupId, int month, int year)
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<MonthlySpending>
                {
                    MethodName = $"{ControllerSimpleName}/bymonthandyear/{spendingGroupId}/{month}/{year}",
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

        public IList<MonthlySpending> GetCurrentAndFurtherThan(DateTime? dateTime, int spendingGroupId)
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<IList<MonthlySpending>>
                {
                    MethodName = $"{ControllerSimpleName}/getcurrentandfurtherthan/{dateTime}/{spendingGroupId}",
                    MethodType = MethodType.Get,
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<IList<MonthlySpending>>(jsonResult)
                });

                return apiResponse.Response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public MonthlySpending Add(int spendingGroupId, int userId, int year, int month)
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<MonthlySpending>
                {
                    MethodName = $"{ControllerSimpleName}/add/{spendingGroupId}/{userId}/{year}/{month}",
                    MethodType = MethodType.Post,
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
