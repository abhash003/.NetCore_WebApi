using coreWebAPI.DataBase;
using coreWebAPI.DTO;
using coreWebAPI.model;
using Microsoft.AspNetCore.Mvc;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private SchoolDBContext _dbContext;

        public StudentsController (SchoolDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var student = _dbContext.Students.ToList();

            return Ok(student);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null) { 
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] StudentDTO student)
        {
            var studentDomain = new Student
            {
                Name = student.Name,
                Standard = student.Standard,
                Address = student.Address,
                PhoneNO = student.PhoneNO
            };

            _dbContext.Students.Add(studentDomain);
            _dbContext.SaveChanges();

            return Ok(student);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Update([FromBody] StudentDTO student, int id) 
        {
            var studentDomain = _dbContext.Students.FirstOrDefault(y => y.Id == id);
            if (studentDomain == null)
            {
                return NotFound();
            }

            studentDomain.Standard = student.Standard;
            studentDomain.Address = student.Address;
            studentDomain.PhoneNO = student.PhoneNO;
            studentDomain.Name = student.Name;

            _dbContext.SaveChanges();
            return Ok(studentDomain);
        }

    }
}
