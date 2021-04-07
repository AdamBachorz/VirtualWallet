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
    public class SpendingGroupController : CustomBaseController<SpendingGroupController, SpendingGroup>
    {
        private readonly ISpendingGroupDao _spendingGroupDao;

        public SpendingGroupController(ILogger<SpendingGroupController> logger, IBaseDao<SpendingGroup> baseDao, ISpendingGroupDao spendingGroupDao) : base(logger, baseDao)
        {
            _spendingGroupDao = spendingGroupDao;
        }
    }
}
