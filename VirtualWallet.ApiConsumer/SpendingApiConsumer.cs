using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.ApiConsumer.Utils;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer
{
    public class SpendingApiConsumer : BaseApiConsumer<Spending>, ISpendingApiConsumer
    {
        public SpendingApiConsumer(ICustomConfig customConfig, IUserContainer userContainer) : base(customConfig, userContainer)
        {
        }

    }
}
