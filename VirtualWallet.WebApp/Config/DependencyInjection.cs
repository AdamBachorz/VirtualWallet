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
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.ApiConsumer;

namespace VirtualWallet.WebApp.Config
{
    public static class DependencyInjection
    {
        public static void RegisterModules(IServiceCollection services)
        {
            services.AddScoped<INHibernateHelper, NHibernateHelper>();

            // DAOs
            services.AddScoped<IUserDao, UserDao>();

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserContainer, UserContainer>();

            // API consumers
            services.AddScoped<IBaseApiConsumer<SpendingGroup>, SpendingGroupApiConsumer>();
            services.AddScoped<ISpendingGroupApiConsumer, SpendingGroupApiConsumer>();

            services.AddScoped<IBaseApiConsumer<Spending>, SpendingApiConsumer>();
            services.AddScoped<ISpendingApiConsumer, SpendingApiConsumer>();

            services.AddScoped<IBaseApiConsumer<MonthlySpending>, MonthlySpendingApiConsumer>();
            services.AddScoped<IMonthlySpendingApiConsumer, MonthlySpendingApiConsumer>();

            services.AddScoped<IBaseApiConsumer<User>, UserApiConsumer>();
            services.AddScoped<IUserApiConsumer, UserApiConsumer>();
        }
    }
}
