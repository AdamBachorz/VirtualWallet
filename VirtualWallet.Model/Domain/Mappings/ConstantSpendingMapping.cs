using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class ConstantSpendingMapping : EntityMapping<ConstantSpending>
    {
        public ConstantSpendingMapping() : base("constant_spending")
        {
            Map(x => x.Name, "name");
            Map(x => x.Value, "value");
            References(x => x.SpendingGroup)
                .Column("id_spending_group")
                .Not.LazyLoad()
                ;
        }
    }
}
