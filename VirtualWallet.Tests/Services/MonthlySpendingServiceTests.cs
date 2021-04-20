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
        Mock<ISpendingDao> _spendingDaoMock;

        [SetUp]
        public void Setup()
        {
            _monthlySpendingDaoMock = new Mock<IMonthlySpendingDao>();
            _spendingDaoMock = new Mock<ISpendingDao>();

        }

        [TestCase(2021, 10000, 2, 4)]
        public void ShouldInsert_SmallRange(int year, decimal budget, int startMonth, int endMonth)
        {
            var user = new User { Id = 1 };
            var spendingGroup = new SpendingGroup { Budget = budget };
            var constantSpendings = Enumerable.Range(1, 2).Select(n => new ConstantSpending { Id = n, Name = $"CS{n}", Value = n, SpendingGroup = spendingGroup });

            var monthlySpendings = Enumerable.Range(startMonth, endMonth - 1)
                .Select(n => MonthlySpending.New(budget, year, n, spendingGroup, null))
                .ToList();
            spendingGroup.ConstantSpendings = constantSpendings;
            spendingGroup.MonthlySpendings = monthlySpendings;

            monthlySpendings.ForEach(ms => _monthlySpendingDaoMock.Setup(msMock => msMock.Insert(It.Is<MonthlySpending>(x => x.Month == ms.Month))).Returns(ms));
            constantSpendings.ForEach(cs => _spendingDaoMock.Setup(sMock => sMock.Insert(cs.ToSpending(It.IsAny<MonthlySpending>(), user)))
                .Returns(cs.ToSpending(It.IsAny<MonthlySpending>(), user)));
            _spendingDaoMock.Setup(x => x.Update(It.IsAny<Spending>())).Verifiable();

            var service = new MonthlySpendingService(_monthlySpendingDaoMock.Object, _spendingDaoMock.Object);

            var addedMonthlySpendings = service.AddInMonthRange(year, budget, startMonth, endMonth, spendingGroup, user);

            Assert.That(addedMonthlySpendings.Count(), Is.EqualTo(monthlySpendings.Count()));
            Assert.That(addedMonthlySpendings.Select(addMs => addMs.Month), Is.EqualTo(monthlySpendings.Select(ms => ms.Month)));

            foreach (var monthlySpending in addedMonthlySpendings)
            {
                Assert.True(monthlySpending.Spendings.All(s => s.ConstantSpending != null));
            }

        }
    }
}
