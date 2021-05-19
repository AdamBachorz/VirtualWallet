using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualWallet.DAL.Daos.Interfaces;
using VirtualWallet.Model.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEntityController : CustomBaseController<TestEntityController, TestEntity>
    {
        private readonly ITestEntityDao _testEntityDao;

        public TestEntityController(ILogger<TestEntityController> logger, IBaseDao<TestEntity> baseDao, ITestEntityDao testEntityDao) : base(logger, baseDao)
        {
            _testEntityDao = testEntityDao;
        }

        // GET: api/<TestEntityController>
        [HttpGet("test")]
        public IEnumerable<TestEntity> GetTest()
        {
            return _testEntityDao.GetTestAllLazy();
        }

        // GET api/<TestEntityController>/5
        [HttpGet("test/{id}")]
        public TestEntity GetTest(int id)
        {
            return _testEntityDao.GetTestAllLazy().FirstOrDefault(te => te.Id == id);
        }

        [HttpGet("test/one")]
        public TestEntity GetTestOne()
        {
            return new TestEntity { Text = "ttt", Value = 12.21m };
        }

    }
}
