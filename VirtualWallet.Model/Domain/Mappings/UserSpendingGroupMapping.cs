using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class UserSpendingGroupMapping : ClassMap<UserSpendingGroup>
    {
        public UserSpendingGroupMapping()
        {
            Table("user_spending_group");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            References(x => x.User)
                .Column("id_user")
                .Not.LazyLoad()
                ;
            References(x => x.SpendingGroup)
                .Column("id_spending_group")
                .Not.LazyLoad()
                ;
        }
    }
}
