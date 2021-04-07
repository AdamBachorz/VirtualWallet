using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class SpendingGroupMapping : ClassMap<SpendingGroup>
    {
        public SpendingGroupMapping()
        {
            Table("spending_group");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            Map(x => x.Name, "name");
            Map(x => x.Budget, "budget");
            //HasMany(x => x.ConstantSpendings)
            //    .KeyColumn("id_constant_spending")
            //    .Not.LazyLoad()
            //    .Inverse()
            //    ;
        }
    }
}
