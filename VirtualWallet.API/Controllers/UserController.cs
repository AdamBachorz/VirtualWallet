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
using VirtualWallet.DAL.Services.Interfaces;

namespace VirtualWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController<UserController, User>
    {
        private readonly IUserDao _userDao;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IBaseDao<User> baseDao, IUserDao userDao, IUserService userService) : base(logger, baseDao)
        {
            _userDao = userDao;
            _userService = userService;
        }

        [HttpGet("get/{token}")]
        public User GetByToken(string token)
        {
            try
            {
                _logger.LogInformation($"Pobieranie danych o użytkowniku");

                var user = _userService.GetByToken(token);

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
