using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.Model.Domain.Mappings
{
    public abstract class EntityMapping<E> : ClassMap<E> where E : Entity
    {
        public EntityMapping(string tableName) : base()
        {
            Table(tableName);
            Id(x => x.Id, "id")
                //.CustomSqlType("Serial")
                .GeneratedBy
                .Sequence(tableName + "_seq");
        }
    }
}
