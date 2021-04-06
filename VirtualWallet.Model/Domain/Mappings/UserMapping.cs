using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("app_user");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            Map(x => x.UserName, "user_name");
            Map(x => x.PasswordHash, "password_hash");
            Map(x => x.Email, "email");
            References(x => x.UserRole)
                .Column("id_user_role")
                .Not.LazyLoad()
                ;
        }
    }
}
