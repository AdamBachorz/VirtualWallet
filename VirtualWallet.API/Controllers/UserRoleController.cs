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
    public class UserRoleController : CustomBaseController<UserRoleController, UserRole>
    {
        private readonly IUserRoleDao _userRoleDao;

        public UserRoleController(ILogger<UserRoleController> logger, IBaseDao<UserRole> baseDao, IUserRoleDao userRoleDao) : base(logger, baseDao)
        {
            _userRoleDao = userRoleDao;
        }
    }
}
