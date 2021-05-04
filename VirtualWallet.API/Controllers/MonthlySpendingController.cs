using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.API.Classes.Extensions;
using VirtualWallet.API.Config;
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

        [HttpGet("bymonthandyear/{spendingGroupId}/{month}/{year}")]
        [BasicAuth]
        public MonthlySpending GetByMonthAndYear(int spendingGroupId, int month, int year)
        {
            try
            {
                _logger.LogInformation($"Pobieranie miesięcznego wydatku ID = {spendingGroupId} na podstawie miesiąca {month} i roku {year}");
                var result = _monthlySpendingDao.GetByMonthAndYear(spendingGroupId, month, year);
                _logger.LogSuccess();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw;
            }
        }

        [HttpGet("getcurrentandfurtherthan/{dateTime}/{spendingGroupId}")]
        [BasicAuth]
        public IList<MonthlySpending> GetCurrentAndFurtherThan(DateTime? dateTime, int spendingGroupId)
        {
            try
            {
                _logger.LogInformation($"Pobieranie miesięcznych wydatków od daty {dateTime} dale grupy o ID = {spendingGroupId}");
                var result = _monthlySpendingDao.GetCurrentAndFurtherThan(dateTime, spendingGroupId);
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
