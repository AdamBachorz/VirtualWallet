using VirtualWallet.Common.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;

namespace VirtualWallet.ApiConsumer.Utils
{
    public class ApiConnection
    {
        public string WareHouseName { get; set; } = string.Empty;
        public string Host { get; set; }
        public AuthenticationType AuthenticationType { get; set; } = AuthenticationType.BasicAuth;
        public string Token { get; set; }
        public NetworkCredential Credential { get; set; }
        public bool UseSSL { get; set; } = true;
        public bool UseMock { get; set; } = false;

        public ApiResponse<T> Invoke<T>(ApiRequestSettings<T> settings) where T : class
        {
            var response = new ApiResponse<T>
            {
                Status = ApiResponseStatus.TechnicalError
            };

            if (!UseMock)
            {
                var invokeResult = InvokeAndGetResult(settings);
                response.ResponseString = invokeResult.ResponseString;
                response.HttpStatusCode = invokeResult.HttpStatusCode;
            }
            else
            {
                response.ResponseString = settings.MockResponse.ResponseString;
                response.HttpStatusCode = settings.MockResponse.HttpStatusCode;
            }

            //response.Status = ApiResponseStatus.ValidationError;
            //validator?.VerifyErrorListFromString(resultData);
            //response.Status = ApiResponseStatus.TechnicalError;
            
            T result = null;

            if (response.HttpStatusCode != HttpStatusCode.Conflict)
            {
                if (settings.ResultDataInterpreter == null)
                {
                    // log
                }
                else
                {
                    try
                    {
                        result = settings.ResultDataInterpreter(response.ResponseString);
                        response.Status = ApiResponseStatus.Success;
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            //response.Status = ApiResponseStatus.ValidationError;
            //validator?.VerifyErrorList(result);
            response.Response = result;
            return response;
        }

        protected InvokeResult InvokeAndGetResult<T>(ApiRequestSettings<T> settings) where T : class
        {
            HttpWebResponse response = null;
            try
            {
                var url = FixAndBuildFullUrl(settings.MethodName, settings.UrlConnector);

                #region Skip SSL certification
                if (!UseSSL)
                {
                    ServicePointManager.Expect100Continue = true;
                    const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
                    const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
                    ServicePointManager.SecurityProtocol = Tls12;
                    ServicePointManager.ServerCertificateValidationCallback +=
                        (sender, cert, chain, sslPolicyErrors) => { return true; };
                }
                #endregion

                var request = WebRequest.Create(url) as HttpWebRequest;

                PerformAuthentication(request);

                request.Method = settings.MethodType.ToString().ToUpper();
                request.ContentType = settings.ContentType.Description();

                if (settings.InputBody.HasValue())
                {
                    byte[] data = Encoding.UTF8.GetBytes(settings.InputBody);
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }

                if (settings.AdditionalHeaders.IsNotNullOrEmpty())
                {
                    settings.AdditionalHeaders.ForEach(x => request.Headers.Add(x.Key, x.Value));
                }

                response = request.GetResponse() as HttpWebResponse;
                var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return new InvokeResult(result, response.StatusCode);
            }
            catch (Exception ex)
            {
                // log
                return new InvokeResult(ex.FullMessage(), response?.StatusCode ?? HttpStatusCode.Conflict);
            }
        }

        protected void PerformAuthentication(WebRequest request)
        {
            switch (AuthenticationType)
            {
                case AuthenticationType.NoAuth:
                    request.UseDefaultCredentials = true;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    break;
                case AuthenticationType.ApiKey:
                    if (Token.HasNotValue())
                    {
                        // log
                    }
                    break;
                case AuthenticationType.BearerToken:
                    break;
                case AuthenticationType.BasicAuth:
                    Token = Credential.BuildBase64Token();
                    request.PreAuthenticate = true;
                    request.Credentials = Credential;
                    break;
                case AuthenticationType.DigestAuth:
                    break;
                case AuthenticationType.OAuth1:
                    break;
                case AuthenticationType.OAuth2:
                    break;
                case AuthenticationType.HawkAuthentication:
                    break;
                case AuthenticationType.AwsSignature:
                    break;
                case AuthenticationType.NtlmAuthentication:
                    break;
                case AuthenticationType.AkamaiEdgeGrid:
                    break;
            }

            if (Token.HasValue())
            {
                request.Headers[HttpRequestHeader.Authorization] = Token;
            }
        }

        protected string FixAndBuildFullUrl(string methodName, string connector = "/")
        {
            if (methodName.HasNotValue())
            {
                return Host;
            }

            if (!Host.EndsWith(connector))
            {
                Host += connector;
            }

            return $"{Host}{(methodName.EndsWith(connector) ? methodName.Substring(1) : methodName)}";
        }

        public static Func<string, string> DefaultStringToStringInterpreter => stringResult => stringResult;

        public static ApiConnection TestConnection()
        {
            var regularHost = "https://localhost:5001/api/";
            var sslHost = "https://localhost:44316/api/";
            var productionHost = "https://restapiinmoto.herokuapp.com/api/";

            return new ApiConnection
            {
                WareHouseName = "Połączenie testowe",
                Host = productionHost,
                Credential = new NetworkCredential("test", "test123"),
                AuthenticationType = AuthenticationType.BasicAuth,
                UseSSL = true,
            };

            //var testApiResponse = ApiConnectionV2.TestConnection().Invoke(new ApiRequestSettings<JArray>
            //{
            //    MethodName = "myentity",
            //    MethodType = MethodType.Get,
            //    ContentType = ContentType.json,
            //    ResultDataInterpreter = result => JArray.Parse(result),
            //});
        }
        //
    }
}
