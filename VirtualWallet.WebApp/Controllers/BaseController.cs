using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.DAL.Services.Interfaces;

namespace VirtualWallet.WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUserContainer _userContainer;
        protected readonly IUserApiConsumer _userApiConsumer;

        public BaseController(IUserContainer userContainer, IUserApiConsumer userApiConsumer)
        {
            _userContainer = userContainer;
            _userApiConsumer = userApiConsumer;
        }
    }
}
