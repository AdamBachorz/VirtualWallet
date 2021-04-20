
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.ApiConsumer.Utils;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer
{
    public class UserApiConsumer : BaseApiConsumer<User>, IUserApiConsumer
    {
        protected IUserDao _userDao;
        protected IUserService _userService;

        public UserApiConsumer(ICustomConfig customConfig, IUserContainer userContainer, IUserDao userDao, IUserService userService) : base(customConfig, userContainer)
        {
            _userDao = userDao;
            _userService = userService;
        }

        public User GetByCredentials(string login, string password)
        {
            try
            {
                _apiConnection.AuthenticationType = AuthenticationType.NoAuth;
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<User>
                {
                    MethodName = $"{ControllerSimpleName}/get/{login}/{password}",
                    MethodType = MethodType.Get,
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<User>(jsonResult)
                });

                return apiResponse.Response;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _apiConnection.AuthenticationType = AuthenticationType.BasicAuth;
            }
        }

    }
}
