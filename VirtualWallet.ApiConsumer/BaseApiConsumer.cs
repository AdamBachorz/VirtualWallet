using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.ApiConsumer.Utils;
using VirtualWallet.DAL.Config;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer
{
    public class BaseApiConsumer<E> : IBaseApiConsumer<E> where E : Entity
    {
        private readonly ICustomConfig _customConfig;

        private ApiConnection _apiConnection;

        public BaseApiConsumer(ICustomConfig customConfig)
        {
            _customConfig = customConfig;
            _apiConnection = new ApiConnection
            {
                Host = _customConfig.IsProduction ? RemoteHostUrl : TestHostUrl,
                UseSSL = !_customConfig.IsProduction,
                AuthenticationType = AuthenticationType.BasicAuth,
                Credential = new NetworkCredential("test", "test123"), // TBE - UserService
                EntityName = typeof(E).Name
            };
        }

        public string TestHostUrl { get; } = "https://localhost:5001/api";
        public string TestSslHostUrl { get; } = "https://localhost:44367/api";
        public string RemoteHostUrl { get; } = ""; // TBE

        public IList<E> GetAll()
        {
            try
            {
                var apiResponse = _apiConnection.Invoke(new ApiRequestSettings<List<E>>
                {
                    MethodName = "",
                    MethodType = MethodType.Get,
                    InputBody = null,
                    ContentType = ContentType.json,
                    ResultDataInterpreter = result => new List<E>() // TBE - interpreter
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
            throw new NotImplementedException();
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
