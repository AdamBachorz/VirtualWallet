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
        protected readonly ICustomConfig _customConfig;
        protected readonly IUserContainer _userContainer;
        protected ApiConnection _apiConnection;

        public BaseApiConsumer(ICustomConfig customConfig, IUserContainer userContainer)
        {
            _customConfig = customConfig;
            _userContainer = userContainer;

            _apiConnection = new ApiConnection
            {
                Host = _customConfig.IsProduction ? RemoteHostUrl : TestSslHostUrl,
                UseSSL = _customConfig.IsProduction,
                Credential = _userContainer.Credential(),
                EntityName = typeof(E).Name
            };
        }

        public string TestHostUrl { get; } = "https://localhost:5001/api";
        public string TestSslHostUrl { get; } = "https://localhost:44367/api";
        public string RemoteHostUrl { get; } = "https://virtualwalletappapi.herokuapp.com/api";

        public void SetAuthorization(NetworkCredential networkCredential)
        {
            _apiConnection.Credential = networkCredential;
        }

        public IList<E> GetAll()
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<List<E>>
                {
                    MethodName = ControllerSimpleName,
                    MethodType = MethodType.Get,
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<List<E>>(jsonResult)
                });

                return apiResponse.Response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public E GetLatest()
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<E>
                {
                    MethodName = $"{ControllerSimpleName}/latest",
                    MethodType = MethodType.Get,
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<E>(jsonResult)
                });

                return apiResponse.Response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public E GetOneById(int id)
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<E>
                {
                    MethodName = $"{ControllerSimpleName}/{id}",
                    MethodType = MethodType.Get,
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
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<E>
                {
                    MethodName = ControllerSimpleName,
                    MethodType = MethodType.Post,
                    InputBody = JsonConvert.SerializeObject(entity),
                    ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<E>(jsonResult)
                });

                return apiResponse.Response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(E entity)
        {
            var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<E>
            {
                MethodName = $"{ControllerSimpleName}/{entity.Id}",
                MethodType = MethodType.Put,
                InputBody = JsonConvert.SerializeObject(entity),
                ResultDataInterpreter = jsonResult => JsonConvert.DeserializeObject<E>(jsonResult)
            });
        }

        public void Delete(int id)
        {
            var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<E>
            {
                MethodName = $"{ControllerSimpleName}/{id}",
                MethodType = MethodType.Delete,
                ContentType = ContentType.json
            });
        }

        public virtual string ControllerSimpleName => typeof(E).Name.ToLower();

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
