using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.ApiConsumer.Utils;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Classes.Utils;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer
{
    public abstract class BaseApiConsumer<E> : IBaseApiConsumer<E> where E : Entity
    {
        public const string ApiPrefix = "api";

        protected readonly ICustomConfig _customConfig;
        protected readonly IUserService _userService;

        private ApiConnection _apiConnection;

        public BaseApiConsumer(ICustomConfig customConfig, IUserService userService)
        {
            _customConfig = customConfig;
            _userService = userService;

            _apiConnection = new ApiConnection
            {
                Host = _customConfig.IsProduction ? RemoteHostUrl : TestHostUrl,
                UseSSL = _customConfig.IsProduction,
                AuthenticationType = AuthenticationType.BasicAuth,
                Credential = new NetworkCredential("test", "test123"), // TBE - UserService
                EntityName = typeof(E).Name
            };
        }

        public string TestHostUrl { get; } = "https://localhost:5001/api";
        public string TestSslHostUrl { get; } = "https://localhost:44367/api";
        public string RemoteHostUrl { get; } = ""; // TBE

        public string ApiMethodName => $"{ApiPrefix}/{ControllerSimpleName}"; 

        public IList<E> GetAll()
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<List<E>>
                {
                    MethodName = ApiMethodName,
                    MethodType = MethodType.Get,
                    InputBody = null,
                    ContentType = ContentType.json,
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<List<E>>(jsonResult)
                });

                return apiResponse.Response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<E> GetAllLazy()
        {
            throw new NotImplementedException();
        }

        public E GetLatest()
        {
            throw new NotImplementedException();
        }

        public E GetOneById(int id)
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<E>
                {
                    MethodName = $"{ApiMethodName}/{id}",
                    MethodType = MethodType.Get,
                    InputBody = null,
                    ContentType = ContentType.json,
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<E>(jsonResult)
                });

                return apiResponse.Response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public E Insert(E entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, E entity)
        {
            throw new NotImplementedException();
        }

        public void Update(E entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public abstract string ControllerSimpleName { get; }

        #region Invokers
        //

        protected ApiResponse<T> Invoke<T>(ApiRequestSettings<T> requestSettings) where T : class
        {
            return _apiConnection.Invoke(requestSettings);
        }

        //
        #endregion

    }
}
