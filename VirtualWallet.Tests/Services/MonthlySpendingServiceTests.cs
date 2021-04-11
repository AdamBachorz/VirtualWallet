using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;
using VirtualWallet.Common.Extensions;
using VirtualWallet.DAL.Services;
using NUnit.Framework;

namespace VirtualWallet.Tests.Services
{
    [TestFixture]
    public class MonthlySpendingServiceTests
    {
        Mock<IMonthlySpendingDao> _monthlySpendingDaoMock;

        [SetUp]
        public void Setup()
        {
            _monthlySpendingDaoMock = new Mock<IMonthlySpendingDao>();

        }

        [TestCase(2021, 10000, 2, 4)]
        public void ShouldInsert_SmallRange(int year, decimal budget, int startMonth, int endMonth)
        {
            int id = 0;
            var monthlySpendings = Enumerable.Range(startMonth, endMonth - 1)
                .Select(n => new MonthlySpending { Id = ++id , CreationDate = new DateTime(year, n, 1) })
                .ToList();

            for (int i = 1; i < monthlySpendings.Count; i++)
            {
                monthlySpendings[i].PreviousMonthlySpending = monthlySpendings[i - 1];
            }

            monthlySpendings.ForEach(ms => _monthlySpendingDaoMock.Setup(x => x.Insert(It.IsAny<MonthlySpending>())).Returns(ms));
            _monthlySpendingDaoMock.Setup(x => x.GetLatest()).Returns(monthlySpendings.Last());

            var service = new MonthlySpendingService(_monthlySpendingDaoMock.Object);

            var addedMonthlySpendings = service.AddInMonthRange(year, budget, startMonth, endMonth);

            Assert.That(addedMonthlySpendings.Count(), Is.EqualTo(monthlySpendings.Count()));

        }
    }
}
