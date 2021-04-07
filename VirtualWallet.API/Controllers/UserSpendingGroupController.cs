using Microsoft.AspNetCore.Http;
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
    public class UserSpendingGroupController : CustomBaseController<UserSpendingGroupController, UserSpendingGroup>
    {
        private readonly IUserSpendingGroupDao _userSpendingGroupDao;

        public UserSpendingGroupController(ILogger<UserSpendingGroupController> logger, IBaseDao<UserSpendingGroup> baseDao, IUserSpendingGroupDao userSpendingGroupDao) : base(logger, baseDao)
        {
            _userSpendingGroupDao = userSpendingGroupDao;
        }
    }
}
