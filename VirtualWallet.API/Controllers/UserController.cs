using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController<UserController, User>
    {
        private readonly IUserDao _userDao;

        public UserController(ILogger<UserController> logger, IBaseDao<User> baseDao, IUserDao userDao) : base(logger, baseDao)
        {
            _userDao = userDao;
        }
    }
}
