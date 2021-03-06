using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer.Interfaces
{
    public interface ISpendingApiConsumer : IBaseApiConsumer<Spending>
    {
        IEnumerable<Spending> GetSpendingsForMonthlySpending(int monthlySpendingId);
    }
}
