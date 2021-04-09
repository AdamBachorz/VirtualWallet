using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class MonthlySpendingMapping : ClassMap<MonthlySpending>
    {
        public MonthlySpendingMapping()
        {
            Table("monthly_spending");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            Map(x => x.Budget, "budget");
            Map(x => x.CreationDate, "creation_date");
            References(x => x.PreviousMonthlySpending)
                .Column("id_monthly_spending")
                .Not.LazyLoad()
                ;
        }
    }
}
