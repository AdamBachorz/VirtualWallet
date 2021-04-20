using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VirtualWallet.Common.Utils;
using VirtualWallet.DAL.Services.Interfaces;

namespace VirtualWallet.API.Config
{
    public class BasicAuthFilter : IAuthorizationFilter
    {
        private readonly bool _adminAccess;
        private readonly string _realm;

        public BasicAuthFilter(bool adminAccess, string realm)
        {
            _adminAccess = adminAccess;
            _realm = realm;
            if (string.IsNullOrWhiteSpace(_realm))
            {
                throw new ArgumentNullException(nameof(realm), @"Please provide a non-empty realm value.");
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var credential = StringUtils.DecodeBaseToken(context.HttpContext.Request.Headers["Authorization"]);

                if (IsAuthorized(context, credential, _adminAccess))
                {
                    return;
                }

                ReturnUnauthorizedResult(context);
            }
            catch (FormatException)
            {
                ReturnUnauthorizedResult(context);
            }
        }

        public bool IsAuthorized(AuthorizationFilterContext context, NetworkCredential credential, bool adminAccess)
        {
            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();

           if (adminAccess)
            {
                return userService.IsAdmin(credential);
            }

            return userService.IsValidUser(credential);
        }

        private void ReturnUnauthorizedResult(AuthorizationFilterContext context)
        {
            // Return 401 and a basic authentication challenge (causes browser to show login dialog)
            context.HttpContext.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"{_realm}\"";
            context.Result = new UnauthorizedResult();
        }
    }

}
