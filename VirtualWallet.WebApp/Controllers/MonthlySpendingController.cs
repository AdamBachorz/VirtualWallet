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
        public ActionResult Current(DateTime? dateTime)
        {
            var currentSpendingGroup = _userContainer.GetCurrentSpendingGroup();

            if (currentSpendingGroup is null)
            {
                return Home();
            }

            dateTime ??= DateTime.Now;
            var monthlySpending = _monthlySpendingApiConsumer.GetByMonthAndYear(currentSpendingGroup.Id, dateTime.Value.Month, dateTime.Value.Year);
            if (monthlySpending == null)
            {
                var user = _userContainer.GetCurrentUser();
                monthlySpending = _monthlySpendingApiConsumer.Add(currentSpendingGroup.Id, user.Id, dateTime.Value.Year, dateTime.Value.Month);
            }

            return View(monthlySpending);
        }

        public ActionResult Next(DateTime? currentMonthlySpendingDate, bool forward)
        {
            var currentSpendingGroupId = _userContainer.GetCurrentSpendingGroup().Id;
            var userId = _userContainer.GetCurrentUser().Id;

            var monthlyspending = _monthlySpendingApiConsumer.GetNext(currentMonthlySpendingDate, currentSpendingGroupId, userId, forward);

            return RedirectToAction("Current", new { dateTime = monthlyspending.CreationDate });
        }

        public ActionResult Pick(int month, int year)
        {
            return RedirectToAction("Current", new { dateTime = new DateTime(year, month, 1) });
        }

        // GET: MonthlySpendingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: MonthlySpendingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: MonthlySpendingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
