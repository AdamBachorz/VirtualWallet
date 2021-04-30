using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.API.Classes;
using VirtualWallet.API.Classes.Extensions;
using VirtualWallet.API.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

namespace VirtualWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpendingController : CustomBaseController<SpendingController, Spending>
    {
        private readonly ISpendingDao _spendingDao;

        public SpendingController(ILogger<SpendingController> logger, IBaseDao<Spending> baseDao, ISpendingDao spendingDao) : base(logger, baseDao)
        {
            _spendingDao = spendingDao;
        }

        [HttpGet("formonthlyspending/{monthlySpendingId}")]
        [BasicAuth]
        public IEnumerable<Spending> GetForMonthlySpending(int monthlySpendingId)
        {
            try
            {
                _logger.LogInformation($"Pobieranie listy wydatków na podstawie ID miesięcznego wydatku ({monthlySpendingId})");
                var result = _spendingDao.GetSpendingsForMonthlySpending(monthlySpendingId);
                _logger.LogSuccess();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw;
            }
        }
    }
}
