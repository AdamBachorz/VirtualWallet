using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.WebApp.Models;
using VirtualWallet.Model.Domain;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.Common.Extensions;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Classes;
using System.Net;

namespace VirtualWallet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserContainer _userContainer;
        private readonly IUserApiConsumer _userApiConsumer;
        private readonly ISpendingGroupApiConsumer _spendingGroupApiConsumer;


        public HomeController(ILogger<HomeController> logger, 
            IUserContainer userContainer, IUserApiConsumer userApiConsumer, ISpendingGroupApiConsumer spendingGroupApiConsumer)
        {
            _logger = logger;
            _userContainer = userContainer;
            _userApiConsumer = userApiConsumer;
            _spendingGroupApiConsumer = spendingGroupApiConsumer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult QuickLog()
        {
            var credential = new NetworkCredential("admin", "admintest");
            _userApiConsumer.SetAuthorization(credential);
            _spendingGroupApiConsumer.SetAuthorization(credential);
            var user = _userApiConsumer.GetByToken(credential.BuildBase64Token());
            _userContainer.SignIn(user, "admintest");
            _userContainer.SetSpendingGroup(_spendingGroupApiConsumer.GetForUser(user.Id).First());
            return RedirectToAction("Current", "MonthlySpending");
        }
    }
}
