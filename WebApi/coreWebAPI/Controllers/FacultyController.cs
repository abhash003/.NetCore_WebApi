using coreWebAPI.DataBase;
using coreWebAPI.DTO;
using coreWebAPI.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private SchoolDBContext _dbContext;

        public FacultyController (SchoolDBContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Getall")]
        public IActionResult GetAll()
        {
            var faculty = _dbContext.Faculties.ToList();

            return Ok(faculty);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) 
        {
            var faculty = _dbContext.Faculties.FirstOrDefault(x => x.Id == id);

            return Ok(faculty);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] FacultyDTO faculty)
        {
            var facultydomain = new Faculty
            {
                Address = faculty.Address,
                Subject = faculty.Subject,
                Name = faculty.Name,
                PhoneNo = faculty.PhoneNo
            };

            _dbContext.Faculties.Add(facultydomain);

            _dbContext.SaveChanges();

            return Ok(facultydomain);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Update([FromBody] FacultyDTO faculty, int id)
        {
            var facultyDomain = _dbContext.Faculties.FirstOrDefault(x => x.Id==id);

            facultyDomain.Address = faculty.Address;
            facultyDomain.Subject = faculty.Subject;
            facultyDomain.PhoneNo = faculty.PhoneNo;
            facultyDomain.Name = faculty.Name;
            
            _dbContext.SaveChanges();

            return Ok(facultyDomain);
        }

    }
}
