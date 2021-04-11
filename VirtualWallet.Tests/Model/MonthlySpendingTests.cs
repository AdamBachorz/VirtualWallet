using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Domain;
using VirtualWallet.Model.Classes.Extensions;

namespace VirtualWallet.Tests.Model
{
    [TestFixture]
    public class MonthlySpendingTests
    {
        [Test]
        public void ShouldGet_MonthAndYear()
        {
            var monthlySpending = new MonthlySpending
            {
                CreationDate = DateTime.Parse("2021-04-10")
            };

            Assert.That(monthlySpending.Month, Is.EqualTo(4));
            Assert.That(monthlySpending.Year, Is.EqualTo(2021));
        }

        [Test]
        public void ShouldGet_SpedingSummary()
        {
            var spendings = new[]
            {
                new Spending {Value = 10},
                new Spending {Value = 40},
                new Spending {Value = 50},
            };

            var monthlySpending = new MonthlySpending { Spendings = spendings };

            Assert.That(monthlySpending.SpendingSummary, Is.EqualTo(100));
        }

        [Test]
        public void ShouldGet_SummaryBilance()
        {
            var spendings = new[]
            {
                new Spending {Value = 10},
                new Spending {Value = 40},
                new Spending {Value = 50},
            };

            var previousMonthSpendings = new[]
            {
                new Spending {Value = 100},
                new Spending {Value = 100},
            };

            var monthlySpending = new MonthlySpending 
            { 
                Budget = 10000,
                Spendings = spendings,
                PreviousMonthlySpending = new MonthlySpending 
                { 
                    Budget = 1000, 
                    Spendings = previousMonthSpendings 
                }
            };

            Assert.That(monthlySpending.SummaryBilance, Is.EqualTo(10700));
        }

        [TestCase(2021, 6, ExpectedResult = "Czerwiec 2021")]
        public string ShouldGetTitle(int year, int month)
        {
            var monthlySpending = new MonthlySpending
            {
                CreationDate = new DateTime(year, month, 1)
            };

            return monthlySpending.Title;
        }
    }
}
