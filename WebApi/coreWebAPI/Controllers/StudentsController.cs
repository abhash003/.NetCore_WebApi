using Data.Model;
using Data.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repository.Repository.Students;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentRepository studentRepository;

        public StudentsController (IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var Students = studentRepository.GetAllStudents();

            return Ok(Students);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var student = studentRepository.GetStudent(id);
            if (student == null)
            {
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
                StandardId = student.StandardId,
                AddressId = student.AddressId,
                PhoneNO = student.PhoneNO
            };

            studentRepository.CreateStudent(studentDomain);

            return Ok(student);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Update([FromBody] StudentDTO student, int id)
        {
            var studentDomain = studentRepository.GetStudent(id);
            //var Address = standa
            if (studentDomain == null)
            {
                return NotFound();
            }

            studentDomain.AddressId = student.AddressId;
            studentDomain.StandardId = student.StandardId;
            studentDomain.PhoneNO = student.PhoneNO;
            studentDomain.Name = student.Name;

            studentRepository.UpdateStudent(studentDomain);

            return Ok(studentDomain);
        }

    }
}
