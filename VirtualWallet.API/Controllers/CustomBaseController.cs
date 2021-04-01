using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirtualWallet.API.Classes;
using VirtualWallet.API.Classes.Extensions;
using VirtualWallet.API.Config;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;
using VirtualWallet.Model.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWallet.API.Controllers
{
    public abstract class CustomBaseController<C, E> : ControllerBase where C : ControllerBase where E : Entity  
    {
        protected readonly ILogger<C> _logger;
        protected readonly IBaseDao<E> _baseDao;

        public CustomBaseController(ILogger<C> logger, IBaseDao<E> baseDao)
        {
            _logger = logger;
            _baseDao = baseDao;
        }

        // GET: api/<controller>
        [HttpGet]
        [BasicAuth]
        public IEnumerable<E> Get()
        {
            try
            {
                _logger.QuickLog(DbOperationType.GetAll, typeof(E));
                var result = _baseDao.GetAll();
                _logger.LogIfNotFound(typeof(E), result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw;
            }
        }

        // GET: api/<controller>/<id>
        [HttpGet("{id}")]
        [BasicAuth]
        public E Get(int id)
        {
            try
            {
                _logger.QuickLog(DbOperationType.GetById, typeof(E), id);
                var result = _baseDao.GetOneById(id);
                _logger.LogIfNotFound(typeof(E), id, result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] E entity)
        {
            try
            {
                _logger.QuickLog(DbOperationType.Insert, entity);
                var justAddedEntity =_baseDao.Insert(entity);
                _logger.LogSuccess(() => justAddedEntity.Equals(entity, excludeId: true) && justAddedEntity.Id > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                //throw;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] E entity)
        {
            try
            {
                _logger.QuickLog(DbOperationType.Update, entity);
                _baseDao.Update(id, entity);
                _logger.LogSuccess(() => _baseDao.GetOneById(id).Equals(entity, excludeId: false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                //throw;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _logger.QuickLog(DbOperationType.Delete, typeof(E), id);
                _baseDao.Delete(id);
                _logger.LogSuccess(() => _baseDao.GetOneById(id) == null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                //throw;
            }
        }
    }
}
