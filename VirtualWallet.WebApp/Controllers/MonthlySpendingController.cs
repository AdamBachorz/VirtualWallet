using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.DAL.Services.Interfaces;

namespace VirtualWallet.WebApp.Controllers
{
    public class MonthlySpendingController : BaseController
    {
        private readonly IMonthlySpendingApiConsumer _monthlySpendingApiConsumer;

        public MonthlySpendingController(IUserContainer userContainer, IUserApiConsumer userApiConsumer, 
            IMonthlySpendingApiConsumer monthlySpendingApiConsumer) : base(userContainer, userApiConsumer)
        {
            _monthlySpendingApiConsumer = monthlySpendingApiConsumer;
        }

        // GET: MonthlySpendingController
        public ActionResult Current()
        {
            var currentSpendingGroup = _userContainer.GetCurrentSpendingGroup();

            if (currentSpendingGroup is null)
            {
                return Home();
            }

            var now = DateTime.Now.AddMonths(-1); // TODO:L Remove later
            var monthlySpending = _monthlySpendingApiConsumer.GetByMonthAndYear(currentSpendingGroup.Id, now.Month, now.Year);
            return View(monthlySpending);
        }

        // GET: MonthlySpendingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MonthlySpendingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonthlySpendingController/Create
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

        // GET: MonthlySpendingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonthlySpendingController/Edit/5
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

        // GET: MonthlySpendingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonthlySpendingController/Delete/5
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
