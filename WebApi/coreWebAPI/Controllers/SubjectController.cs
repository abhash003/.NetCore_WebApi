using Data.Model;
using Data.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repository.Repository.Subjects;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ISubjectRepository subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var Students = subjectRepository.GetAllSubjects();

            return Ok(Students);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var Subject = subjectRepository.GetSubject(id);

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

            subjectRepository.CreateSubjectAsync(newSub);
            return Ok(subject);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult UpdateSubject([FromBody] SubjectDTO subject, int id)
        {
            var sub = subjectRepository.GetSubject(id);

            sub.Name = subject.Name;

            subjectRepository.UpdateSubject(sub);
            return Ok(subject);
        }
    }
}
