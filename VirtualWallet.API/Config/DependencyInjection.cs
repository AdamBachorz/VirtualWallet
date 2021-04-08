using Microsoft.Extensions.DependencyInjection;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.DAL.Services;
using VirtualWallet.ApiConsumer;
using VirtualWallet.ApiConsumer.Interfaces;

namespace VirtualWallet.API.Config
{
    public static class DependencyInjection
    {
        public static void RegisterModules(IServiceCollection services)
        {
            services.AddScoped<INHibernateHelper, NHibernateHelper>();

            // DAOs
            services.AddScoped<IBaseDao<TestEntity>, TestEntityDao>();
            services.AddScoped<ITestEntityDao, TestEntityDao>();

            services.AddScoped<IBaseDao<UserRole>, UserRoleDao>();
            services.AddScoped<IUserRoleDao, UserRoleDao>();

            services.AddScoped<IBaseDao<SpendingGroup>, SpendingGroupDao>();
            services.AddScoped<ISpendingGroupDao, SpendingGroupDao>();

            services.AddScoped<IBaseDao<UserSpendingGroup>, UserSpendingGroupDao>();
            services.AddScoped<IUserSpendingGroupDao, UserSpendingGroupDao>();

            services.AddScoped<IBaseDao<ConstantSpending>, ConstantSpendingDao>();
            services.AddScoped<IConstantSpendingDao, ConstantSpendingDao>();

            // Services
            services.AddScoped<IUserService, UserService>();

            // API consumers
            services.AddScoped<IBaseApiConsumer<TestEntity>, TestEntityApiConsumer>();
            services.AddScoped<ITestEntityApiConsumer, TestEntityApiConsumer>();
        }
    }
}
