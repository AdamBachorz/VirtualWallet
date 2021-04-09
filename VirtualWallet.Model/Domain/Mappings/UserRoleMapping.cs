using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class UserRoleMapping : EntityMapping<UserRole>
    {
        public UserRoleMapping() : base("user_role")
        {
            Map(x => x.Name, "name");
            HasMany(x => x.Users)
                .KeyColumn("id_user_role")
                .Not.LazyLoad()
                .Inverse()
                ;

        }
    }
}
