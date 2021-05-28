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
        Mock<ISpendingGroupDao> _spendingGroupDaoMock;
        Mock<IUserDao> _userDaoMock;

        [SetUp]
        public void Setup()
        {
            _monthlySpendingDaoMock = new Mock<IMonthlySpendingDao>();
            _spendingDaoMock = new Mock<ISpendingDao>();
            _spendingGroupDaoMock = new Mock<ISpendingGroupDao>();
            _userDaoMock = new Mock<IUserDao>();
        }

        [TestCase(2021, 10000, 2, 4)]
        public void ShouldInsert_SmallRange(int year, decimal budget, int startMonth, int endMonth)
        {
            var creationDate = new DateTime(year, startMonth, 1);
            var user = new User { Id = 1 };
            var spendingGroup = new SpendingGroup { Id = 1 , Budget = budget };
            var constantSpendings = Enumerable.Range(1, 2).Select(n => new ConstantSpending { Id = n, Name = $"CS{n}", Value = n, SpendingGroup = spendingGroup });

            _spendingGroupDaoMock.Setup(sgd => sgd.GetOneById(spendingGroup.Id)).Returns(spendingGroup);
            _userDaoMock.Setup(ud => ud.GetOneById(user.Id)).Returns(user);
            _monthlySpendingDaoMock.Setup(msd => msd.GetByDate(spendingGroup.Id, creationDate.AddMonths(-1)));

            var month = startMonth;
            MonthlySpending previousMonthlySpending = null;
            var monthlySpendings = Enumerable.Range(startMonth, endMonth - 1)
                .Select(n =>
                {
                    var monthlySpending = MonthlySpending.New(spendingGroup, previousMonthlySpending, user, creationDate.AddMonths(++month));
                    previousMonthlySpending = monthlySpending;
                    return monthlySpending;
                })
                .ToList();
            spendingGroup.ConstantSpendings = constantSpendings;
            spendingGroup.MonthlySpendings = monthlySpendings;

            monthlySpendings.ForEach(ms => _monthlySpendingDaoMock.Setup(msMock => msMock.Insert(It.Is<MonthlySpending>(x => x.Month == ms.Month))).Returns(ms));
            constantSpendings.ForEach(cs => _spendingDaoMock.Setup(sMock => sMock.Insert(cs.ToSpending(It.IsAny<MonthlySpending>(), user)))
                .Returns(cs.ToSpending(It.IsAny<MonthlySpending>(), user)));
            _spendingDaoMock.Setup(x => x.Update(It.IsAny<Spending>())).Verifiable();

            var service = new MonthlySpendingService(_monthlySpendingDaoMock.Object, _spendingDaoMock.Object, _spendingGroupDaoMock.Object, _userDaoMock.Object);

            var addedMonthlySpendings = service.AddInMonthRange(year, budget, startMonth, endMonth, spendingGroup.Id, user.Id);

            Assert.That(addedMonthlySpendings.Count(), Is.EqualTo(monthlySpendings.Count()));
            Assert.That(addedMonthlySpendings.Select(addMs => addMs.Month), Is.EqualTo(monthlySpendings.Select(ms => ms.Month)));

            foreach (var monthlySpending in addedMonthlySpendings)
            {
                Assert.True(monthlySpending.Spendings.All(s => s.ConstantSpending != null));
            }

        }

        [TestCase(2021, 10000, 2, 4)]
        public void ShouldInsert_SmallRangeV2(int year, decimal budget, int startMonth, int endMonth)
        {
            var creationDate = new DateTime(year, startMonth, 1);
            var user = new User { Id = 1 };
            var spendingGroup = new SpendingGroup { Id = 1, Budget = budget };
            var previousMonthlySpending = new MonthlySpending { Id = 1, Budget = budget, CreationDate = creationDate.AddMonths(-1) };
            var constantSpendings = Enumerable.Range(1, 2).Select(n => new ConstantSpending { Id = n, Name = $"CS{n}", Value = n, SpendingGroup = spendingGroup });
            spendingGroup.ConstantSpendings = constantSpendings;

            _spendingGroupDaoMock.Setup(sgd => sgd.GetOneById(spendingGroup.Id)).Returns(spendingGroup);
            _userDaoMock.Setup(ud => ud.GetOneById(user.Id)).Returns(user);
            _monthlySpendingDaoMock.Setup(msd => msd.GetByDate(spendingGroup.Id, creationDate.AddMonths(-1))).Returns(previousMonthlySpending);

            var month = startMonth;
            var monthlySpendings = Enumerable.Range(startMonth, endMonth - 1)
                .Select(n =>
                {
                    var monthlySpending = MonthlySpending.New(spendingGroup, previousMonthlySpending, user, creationDate.AddMonths(++month));
                    previousMonthlySpending = monthlySpending;
                    return monthlySpending;
                })
                .ToList();
            spendingGroup.ConstantSpendings = constantSpendings;
            spendingGroup.MonthlySpendings = monthlySpendings;

            monthlySpendings.ForEach(ms => _monthlySpendingDaoMock.Setup(msMock => msMock.Insert(It.Is<MonthlySpending>(x => x.Month == ms.Month))).Returns(ms));
            constantSpendings.ForEach(cs => _spendingDaoMock.Setup(sMock => sMock.Insert(cs.ToSpending(It.IsAny<MonthlySpending>(), user)))
                .Returns(cs.ToSpending(It.IsAny<MonthlySpending>(), user)));
            _spendingDaoMock.Setup(x => x.Update(It.IsAny<Spending>())).Verifiable();

            var service = new MonthlySpendingService(_monthlySpendingDaoMock.Object, _spendingDaoMock.Object, _spendingGroupDaoMock.Object, _userDaoMock.Object);

            var addedMonthlySpendings = service.AddInMonthRangeV2(year, budget, startMonth, endMonth, spendingGroup.Id, user.Id);

            Assert.That(addedMonthlySpendings.Count(), Is.EqualTo(monthlySpendings.Count()));
            Assert.That(addedMonthlySpendings.Select(addMs => addMs.Month), Is.EqualTo(monthlySpendings.Select(ms => ms.Month)));

            foreach (var monthlySpending in addedMonthlySpendings)
            {
                Assert.True(monthlySpending.Spendings.All(s => s.ConstantSpending != null));
            }

        }
    }
}
