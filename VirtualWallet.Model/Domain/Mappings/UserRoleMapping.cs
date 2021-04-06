using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class UserRoleMapping : ClassMap<UserRole>
    {
        public UserRoleMapping()
        {
            Table("user_role");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            Map(x => x.Name, "name");
            HasMany(x => x.Users)
                .KeyColumn("id_user_role")
                .Not.LazyLoad()
                .Inverse()
                ;

        }
    }
}
