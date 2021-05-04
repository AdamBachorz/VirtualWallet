using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Domain;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.Common.Extensions;
using System.Net;

namespace VirtualWallet.WebApp.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUserContainer userContainer, IUserApiConsumer userApiConsumer) : base(userContainer, userApiConsumer)
        {
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Login()
        {
            return View();
        }
        // POST: UserController/Create
        [HttpPost]
        public ActionResult Login(User user)
        {
            var userFromDb = _userApiConsumer.GetByToken(new NetworkCredential(user.UserName, user.PasswordHash).BuildBase64Token());

            if (userFromDb != null)
            {
                _userContainer.SignIn(userFromDb, user.PasswordHash);
                return RedirectToAction("Index", "SpendingGroup", new { Id = userFromDb.Id });
            }
            else
            {
                ModelState.AddModelError("1", "Błędny login lub hasło !");
                return RedirectToAction("Login", "User");
            }
        }

        // GET: UserController/Create

        public ActionResult Logout()
        {
            _userContainer.SignOut();
            return RedirectToAction("Index", "Home");
        }
        // GET: UserController/Create

        public ActionResult Register()
        {
            return View();
        }


        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
