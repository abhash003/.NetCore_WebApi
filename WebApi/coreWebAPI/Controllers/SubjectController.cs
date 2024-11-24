using coreWebAPI.DataBase;
using coreWebAPI.DTO;
using coreWebAPI.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private SchoolDBContext _dbContext;

        public SubjectController(SchoolDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var subject = _dbContext.subjects.ToList();

            return Ok(subject);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) 
        {
            var Subject = _dbContext.subjects.SingleOrDefault(x => x.id == id);

            if (Subject == null)
            {
                return NotFound();
            }

            return Ok(Subject);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] SubjectDTO subject)
        {
            var newSub = new Subject
            {
                Name = subject.Name,
            };

            _dbContext.subjects.Add(newSub);
            _dbContext.SaveChanges();
            return Ok(subject);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult UpdateSubject([FromBody] SubjectDTO subject, int id) 
        {
            var sub = _dbContext.subjects.SingleOrDefault(x => x.id == id);

            sub.Name = subject.Name;

            _dbContext.SaveChanges();
            return Ok(subject);
        }
    }
}
