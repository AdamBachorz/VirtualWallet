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
            var monthlySpendings = Enumerable.Range(startMonth, endMonth - 1)
                .Select(n => MonthlySpending.New(budget, year, n, null, null))
                .ToList();

            monthlySpendings.ForEach(ms => _monthlySpendingDaoMock.Setup(x => x.Insert(It.Is<MonthlySpending>(y => y.Month == ms.Month))).Returns(ms));

            var service = new MonthlySpendingService(_monthlySpendingDaoMock.Object);

            var addedMonthlySpendings = service.AddInMonthRange(year, budget, startMonth, endMonth, null);

            Assert.That(addedMonthlySpendings.Count(), Is.EqualTo(monthlySpendings.Count()));
            Assert.That(addedMonthlySpendings.Select(x => x.Month), Is.EqualTo(monthlySpendings.Select(x => x.Month)));

        }
    }
}
