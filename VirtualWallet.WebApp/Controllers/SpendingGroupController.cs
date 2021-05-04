using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.WebApp.Controllers
{
    public class SpendingGroupController : BaseController
    {
        private readonly ISpendingGroupApiConsumer _spendingGroupApiConsumer;

        public SpendingGroupController(IUserContainer userContainer, IUserApiConsumer userApiConsumer, 
            ISpendingGroupApiConsumer spendingGroupApiConsumer) : base(userContainer, userApiConsumer)
        {
            _spendingGroupApiConsumer = spendingGroupApiConsumer;
        }

        // GET: UserSpendingGroupController
        public ActionResult Index(User user)
        {
            var spendingGroups = _spendingGroupApiConsumer.GetForUser(user.Id);
            return View(spendingGroups);
        }

        public ActionResult Pick(int spendingGroupId)
        {
            // TODO: Make sure that picked sepnding group is for current user
            var pickedSpendingGroup = _spendingGroupApiConsumer.GetOneById(spendingGroupId);
            _userContainer.SetSpendingGroup(pickedSpendingGroup);
            return RedirectToAction("Index", "Home");
        }

        // GET: UserSpendingGroupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserSpendingGroupController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserSpendingGroupController/Create
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

        // GET: UserSpendingGroupController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserSpendingGroupController/Edit/5
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

        // GET: UserSpendingGroupController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserSpendingGroupController/Delete/5
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
