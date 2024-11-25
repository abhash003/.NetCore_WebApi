using Data.Model;
using Data.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repository.Repository.Standards;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        private IStandardRepository standardRepository;

        public StandardController(IStandardRepository standardRepository)
        {
            this.standardRepository = standardRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllStandard()
        {
            var standardList = standardRepository.GetAllStandards();

            return Ok(standardList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStandard(int id)
        {
            var standardList = standardRepository.GetStandard(id);

            return Ok(standardList);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateStandard([FromBody] StandardDTO standard)
        {
            var standardDomainModel = new Standard
            {
                Name = standard.Name,
                ClassTeacherId = standard.ClassTeacherId
            };

            standardRepository.CreateStandard(standardDomainModel);

            return Ok(standardDomainModel);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult UpdateStandard([FromBody] StandardDTO standard, int id)
        {
            var standardDomain = standardRepository.GetStandard(id);

            if (standardDomain == null)
            {
                return NotFound();
            }
            standardDomain.Name = standard.Name;
            standardDomain.ClassTeacherId = standard.ClassTeacherId;

            standardRepository.UpdateStandard(standardDomain);

            return Ok(standardDomain);

        }
    }
}
