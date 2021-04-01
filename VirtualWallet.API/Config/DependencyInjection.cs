using Microsoft.Extensions.DependencyInjection;
using VirtualWallet.API.Config;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWallet.API.Config
{
    public static class DependencyInjection
    {
        public static void RegisterModules(IServiceCollection services)
        {
            services.AddScoped<INHibernateHelper, NHibernateHelper>();

            // DAOs
            services.AddScoped<IBaseDao<MyEntity>, MyEntityDao>();
            services.AddScoped<IMyEntityDao, MyEntityDao>();
            services.AddScoped<IBaseDao<MyReference>, MyReferenceDao>();
            services.AddScoped<IMyReferenceDao, MyReferenceDao>();

            //Services
            services.AddScoped<IUserService, UserService>();
        }
    }
}
