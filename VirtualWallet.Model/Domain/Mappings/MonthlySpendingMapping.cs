using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class MonthlySpendingMapping : EntityMapping<MonthlySpending>
    {
        public MonthlySpendingMapping() : base("monthly_spending")
        {
            Map(x => x.Budget, "budget");
            Map(x => x.CreationDate, "creation_date");
            References(x => x.SpendingGroup)
               .Column("id_spending_group")
               .Not.LazyLoad()
               ;
            References(x => x.PreviousMonthlySpending)
                .Column("id_monthly_spending")
                .Not.LazyLoad()
                ;
            HasMany(x => x.Spendings)
                //.KeyColumn("id_monthly_spending")
                .Not.LazyLoad()
                .Inverse()
                ;
           
        }
    }
}
