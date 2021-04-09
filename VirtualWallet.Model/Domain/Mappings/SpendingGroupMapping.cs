using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class SpendingGroupMapping : EntityMapping<SpendingGroup>
    {
        public SpendingGroupMapping() : base("spending_group")
        {
            Map(x => x.Name, "name");
            Map(x => x.Budget, "budget");
            HasMany(x => x.ConstantSpendings)
                .KeyColumn("id_spending_group")
                .Not.LazyLoad()
                .Inverse()
                ;
        }
    }
}
