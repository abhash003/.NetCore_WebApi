using coreWebAPI.DataBase;
using coreWebAPI.DTO;
using coreWebAPI.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        private SchoolDBContext _dbContext;

        public StandardController(SchoolDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllStandard()
        {
            var standardList = _dbContext.Standards.ToList();

            return Ok(standardList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStandard(int id)
        {
            var standardList = _dbContext.Standards.FirstOrDefault(x => x.Id == id);

            return Ok(standardList);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateAddress([FromBody] StandardDTO standard)
        {
            var standardDomainModel = new Standard
            {
                Name = standard.Name,
                ClassteacherId = standard.ClassteacherId,
                ClassTeacherName = standard.ClassTeacherName,
                subjects = standard.subjects
            };

            _dbContext.Standards.Add(standardDomainModel);
            _dbContext.SaveChanges();

            return Ok(standardDomainModel);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult UpdateAddress([FromBody] StandardDTO standard, int id)
        {
            var standardDomain = _dbContext.Standards.Find(id);

            if (standardDomain == null)
            {
                return NotFound();
            }
            standardDomain.Name = standard.Name;
            standardDomain.ClassteacherId = standard.ClassteacherId;
            standardDomain.ClassTeacherName = standard.ClassTeacherName;

            _dbContext.SaveChanges();

            return Ok(standardDomain);

        }
    }
}
