using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class UserSpendingGroupMapping : EntityMapping<UserSpendingGroup>
    {
        public UserSpendingGroupMapping() : base("user_spending_group")
        {
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
