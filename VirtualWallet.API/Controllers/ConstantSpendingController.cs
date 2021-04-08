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
    public class ConstantSpendingController : CustomBaseController<ConstantSpendingController, ConstantSpending>
    {
        private readonly IConstantSpendingDao _constantSpendingDao;

        public ConstantSpendingController(ILogger<ConstantSpendingController> logger, IBaseDao<ConstantSpending> baseDao, IConstantSpendingDao constantSpendingDao) : base(logger, baseDao)
        {
            _constantSpendingDao = constantSpendingDao;
        }
    }
}
