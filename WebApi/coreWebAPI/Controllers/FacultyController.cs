using Data.Model;
using Data.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repository.Repository.Faculties;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private IFacultyRepository facultyRepository;

        public FacultyController(IFacultyRepository facultyRepository)
        {
            this.facultyRepository = facultyRepository;
        }

        [HttpGet]
        [Route("Getall")]
        public IActionResult GetAll()
        {
            var faculty = facultyRepository.GetAllFaculties();

            return Ok(faculty);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) 
        {
            var faculty = facultyRepository.GetFaculty(id);

            return Ok(faculty);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] FacultyDTO faculty)
        {
            var facultydomain = new Faculty
            {
                AddressId = faculty.AddressId,
                SubjectId = faculty.SubjectId,
                Name = faculty.Name,
                PhoneNo = faculty.PhoneNo
            };

            facultyRepository.CreateFaculty(facultydomain);

            return Ok(facultydomain);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Update([FromBody] FacultyDTO faculty, int id)
        {
            var facultyDomain = facultyRepository.GetFaculty(id);

            if(facultyDomain == null)
            {
                return NotFound();
            }

            facultyDomain.AddressId = faculty.AddressId;
            facultyDomain.SubjectId = faculty.SubjectId;
            facultyDomain.PhoneNo = faculty.PhoneNo;
            facultyDomain.Name = faculty.Name;
            
            facultyRepository.UpdateFaculty(facultyDomain);

            return Ok(facultyDomain);
        }

    }
}
