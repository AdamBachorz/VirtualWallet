using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.ApiConsumer;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.DAL.Services;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.DesktopApp.Classes.Config
{
    public class MySimpleInjector
    {
        private Container _container;

        public MySimpleInjector()
        {
            _container = new Container();
            _container.Options.EnableAutoVerification = false;
        }

        public void RegisterSingleton()
        {
            _container.RegisterInstance<ICustomConfig>(new CustomConfig(false, "User ID=ikpsbjrr;Password=PD3VF_f8PgDU6GMEFcsDwuxsOrSomjnT;Host=tai.db.elephantsql.com;Port=5432;Database=ikpsbjrr;Pooling=true;"));
        }

        public void Register()
        {
            _container.Register<INHibernateHelper, NHibernateHelper>();

            // Services
            _container.Register<IUserService, UserService>();

            // API consumers
            _container.Register<IBaseApiConsumer<TestEntity>, TestEntityApiConsumer>();
            _container.Register<ITestEntityApiConsumer, TestEntityApiConsumer>();

            _container.Register<IBaseApiConsumer<SpendingGroup>, SpendingGroupApiConsumer>();
            _container.Register<ISpendingGroupApiConsumer, SpendingGroupApiConsumer>();

            _container.Register<MainForm>();
        }

        public MainForm MainViewInstance => _container.GetInstance<MainForm>();
    }
}
