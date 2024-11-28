using Data.Model;
using Data.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repository.Repository.Addresses;
using WebApi.Data.Repository.Repository.Standards;
using WebApi.Data.Repository.Repository.Students;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentRepository studentRepository;
        private IStandardRepository standardRepository;
        private IAddressRepository addressRepository;

        public StudentsController (IStudentRepository studentRepository, IStandardRepository standardRepository, IAddressRepository addressRepository)
        {
            this.studentRepository = studentRepository;
            this.standardRepository = standardRepository;
            this.addressRepository = addressRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var Students = await studentRepository.GetAllStudentsAsync();

            foreach (var item in Students)
            {
                item.Address = addressRepository.GetAddress(item.AddressId);
                item.Standard = standardRepository.GetStandard(item.StandardId);
            }

            return Ok(Students);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await studentRepository.GetStudentAsync(id);
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

            return Ok(studentDomain);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Update([FromBody] StudentDTO student, int id)
        {
            var studentDomain = studentRepository.GetStudentAsync(id).Result;
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
