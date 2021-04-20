using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;
using VirtualWallet.API.Classes.Extensions;
using System.Net;

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

        [HttpGet("get/{login}/{password}")]
        public User GetByCredential(string login, string password)
        {
            try
            {
                _logger.LogInformation($"Pobieranie danych o użytkowniku: '{login}'");

                var user = _userDao.GetByCredential(new NetworkCredential(login, password));

                _logger.LogIfNotFound(typeof(User), user);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw;
            }
        }
        
    }
}
