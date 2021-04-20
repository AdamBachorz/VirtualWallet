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

            services.AddScoped<IBaseDao<User>, UserDao>();
            services.AddScoped<IUserDao, UserDao>();

            services.AddScoped<IBaseDao<SpendingGroup>, SpendingGroupDao>();
            services.AddScoped<ISpendingGroupDao, SpendingGroupDao>();

            services.AddScoped<IBaseDao<UserSpendingGroup>, UserSpendingGroupDao>();
            services.AddScoped<IUserSpendingGroupDao, UserSpendingGroupDao>();

            services.AddScoped<IBaseDao<ConstantSpending>, ConstantSpendingDao>();
            services.AddScoped<IConstantSpendingDao, ConstantSpendingDao>();

            services.AddScoped<IBaseDao<Spending>, SpendingDao>();
            services.AddScoped<ISpendingDao, SpendingDao>();

            services.AddScoped<IBaseDao<MonthlySpending>, MonthlySpendingDao>();
            services.AddScoped<IMonthlySpendingDao, MonthlySpendingDao>();

            // Services
            services.AddScoped<DAL.Services.Interfaces.IUserService, UserService>();

            // API consumers
        }
    }
}
