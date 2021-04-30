using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DAL.Daos.Interfaces
{
    public interface ISpendingDao : IBaseDao<Spending>
    {
        IList<Spending> GetSpendingsForMonthlySpending(int monthlySpendingId);
    }
}
