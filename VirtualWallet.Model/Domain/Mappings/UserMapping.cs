using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public class UserMapping : EntityMapping<User>
    {
        public UserMapping() : base("app_user")
        {
            Map(x => x.UserName, "user_name");
            Map(x => x.PasswordHash, "password_hash");
            Map(x => x.Email, "email");
            Map(x => x.UserRole, "id_user_role").CustomType<Classes.UserRole>();
        }
    }
}
