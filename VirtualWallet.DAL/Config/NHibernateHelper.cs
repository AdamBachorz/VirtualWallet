using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
//using VirtualWallet.Model.Domain.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace VirtualWallet.DAL.Config
{
    public class NHibernateHelper : INHibernateHelper
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly FluentConfiguration _configuration;
        private readonly ICustomConfig _customConfig;

        public NHibernateHelper(ICustomConfig customConfig)
        {
            _customConfig = customConfig;
            _configuration = BasicNHibernateConfiguration();
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        private FluentConfiguration BasicNHibernateConfiguration()
        {
            return Fluently.Configure()
            .Database(PostgreSQLConfiguration.Standard.ConnectionString(_customConfig.ConnectionString))
            .Mappings(Mapping);
        }
        
        private void Mapping(MappingConfiguration mapping)
        {
            //mapping.FluentMappings.Add<>();
        }

        private HbmMapping BasicMapping()
        {
            var modelMapper = new ModelMapper();

            modelMapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

            var mapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }

        private static void BuildSchema(Configuration config)
        {
            // This NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it.
            var dbSchemaExport = new SchemaExport(config);
            
            dbSchemaExport.SetOutputFile("db_creation.sql");
            dbSchemaExport.Drop(true, true);
            dbSchemaExport.Create(false, true);
        }

        public ISession OpenSession() => _sessionFactory.OpenSession();

        public ICustomConfig CustomConfig => _customConfig;
    }
}
