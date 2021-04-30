using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer.Interfaces
{
    public interface IMonthlySpendingApiConsumer : IBaseApiConsumer<MonthlySpending>
    {
        MonthlySpending GetByMonthAndYear(int month, int year);
    }
}
