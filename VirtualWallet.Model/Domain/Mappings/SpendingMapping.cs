using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class SpendingMapping : ClassMap<Spending>
    {
        public SpendingMapping()
        {
            Table("spending");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            Map(x => x.Name, "name");
            Map(x => x.Budget, "budget");
            References(x => x.User)
                .Column("id_user")
                .Not.LazyLoad()
                ;
            //References(x => x.MonthlySpending)
            //    .Column("id_monthly_spending")
            //    .Not.LazyLoad()
            //    ;
        }
    }
}
