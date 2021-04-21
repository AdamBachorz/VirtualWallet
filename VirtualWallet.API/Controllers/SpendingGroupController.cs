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
    public class SpendingGroupController : CustomBaseController<SpendingGroupController, SpendingGroup>
    {
        private readonly ISpendingGroupDao _spendingGroupDao;

        public SpendingGroupController(ILogger<SpendingGroupController> logger, IBaseDao<SpendingGroup> baseDao, ISpendingGroupDao spendingGroupDao) : base(logger, baseDao)
        {
            _spendingGroupDao = spendingGroupDao;
        }

        [HttpGet("foruser/{userId}")]
        [BasicAuth]
        public IEnumerable<SpendingGroup> GetForUser(int userId)
        {
            try
            {
                _logger.QuickLog(DbOperationType.GetAll, typeof(SpendingGroup));
                var result = _spendingGroupDao.GetForUser(userId);
                _logger.LogIfNotFound(typeof(SpendingGroup), result);
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
