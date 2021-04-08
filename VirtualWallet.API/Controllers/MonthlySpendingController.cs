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
    public class MonthlySpendingController : CustomBaseController<MonthlySpendingController, MonthlySpending>
    {
        private readonly IMonthlySpendingDao _monthlySpendingDao;

        public MonthlySpendingController(ILogger<MonthlySpendingController> logger, IBaseDao<MonthlySpending> baseDao, IMonthlySpendingDao monthlySpendingDao) : base(logger, baseDao)
        {
            _monthlySpendingDao = monthlySpendingDao;
        }
    }
}
