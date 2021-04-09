using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Model.Classes;
using VirtualWallet.Model.Classes.Extensions;

namespace VirtualWallet.Model.Domain.Mappings
{
    public abstract class EntityMapping<E> : ClassMap<E> where E : Entity
    {
        public EntityMapping(string tableName, IdentityStrategy identityStrategy = IdentityStrategy.Sequance) : base()
        {
            Table(tableName);
            Id(x => x.Id, "id")
                .GeneratedBy
                .Strategy(identityStrategy, tableName);
                //.Sequence(tableName + "_seq");
        }
    }

}
