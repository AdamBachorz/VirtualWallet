
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.ApiConsumer.Interfaces;
using VirtualWallet.ApiConsumer.Utils;
using VirtualWallet.DAL.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.DAL.Services.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.ApiConsumer
{
    public class UserApiConsumer : BaseApiConsumer<User>, IUserApiConsumer
    {
        protected IUserDao _userDao;

        public UserApiConsumer(ICustomConfig customConfig, IUserService userService, IUserDao userDao) : base(customConfig, userService)
        {
            _userDao = userDao;
        }

    }
}
