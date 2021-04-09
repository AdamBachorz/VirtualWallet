using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class SpendingMapping : EntityMapping<Spending>
    {
        public SpendingMapping() : base("spending")
        {
            Map(x => x.Name, "name");
            Map(x => x.Value, "value");
            References(x => x.User)
                .Column("id_user")
                .Not.LazyLoad()
                ;
            References(x => x.MonthlySpending)
                .Column("id_monthly_spending")
                .Not.LazyLoad()
                ;
        }
    }
}
