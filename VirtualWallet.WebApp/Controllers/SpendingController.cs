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
    public class SpendingController : BaseController
    {
        private readonly ISpendingApiConsumer _spendingApiConsumer;
        private readonly IMonthlySpendingApiConsumer _monthlySpendingApiConsumer;
        public SpendingController(IUserContainer userContainer, IUserApiConsumer userApiConsumer,
            ISpendingApiConsumer spendingApiConsumer, IMonthlySpendingApiConsumer monthlySpendingApiConsumer) : base(userContainer, userApiConsumer)
        {
            _spendingApiConsumer = spendingApiConsumer;
            _monthlySpendingApiConsumer = monthlySpendingApiConsumer;
        }

        // GET: SpendingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SpendingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpendingController/Create
        public ActionResult Create(int month, int year)
        {
            ViewBag.Month = month;
            ViewBag.Year = year;
            return View();
        }

        // POST: SpendingController/Create
        [HttpPost]
        public ActionResult Create(Spending spending)
        {
            // TODO: Add validation
            var currentUser = _userContainer.GetCurrent();
            var currentSpendingGroup = _userContainer.GetCurrentSpendingGroup();

            spending.User = currentUser;
            spending.CreationDate ??= DateTime.Now;

            var month = spending.CreationDate.Value.Month;
            var year = spending.CreationDate.Value.Year;
            var currentMonthlySpending = _monthlySpendingApiConsumer.GetByMonthAndYear(currentSpendingGroup.Id, month, year);
            spending.MonthlySpending = currentMonthlySpending;
            var justAddedSpending = _spendingApiConsumer.Insert(spending);

            return RedirectToAction("Current", "MonthlySpending" , new { dateTime = new DateTime(year, month, 1) });
        }

        // POST: SpendingController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: SpendingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpendingController/Edit/5
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

        // GET: SpendingController/Delete/5
        public ActionResult Delete(int id, int month, int year)
        {
            _spendingApiConsumer.Delete(id);
            return RedirectToAction("Current", "MonthlySpending", new { dateTime = new DateTime(year, month, 1) });
        }

    }
}
