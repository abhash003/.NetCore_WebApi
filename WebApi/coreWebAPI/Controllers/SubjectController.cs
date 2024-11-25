using Data.Model;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repository.DataBase;
using WebApi.Data.Repository.Repository.Students;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private IStudentRepository studentRepository;

        public SubjectController(IStudentRepository studentRepository)
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


        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult Get(int id) 
        //{
        //    var Subject = _dbContext.subjects.SingleOrDefault(x => x.id == id);

        //    if (Subject == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(Subject);
        //}

        //[HttpPost]
        //[Route("Create")]
        //public IActionResult Create([FromBody] SubjectDTO subject)
        //{
        //    var newSub = new Subject
        //    {
        //        Name = subject.Name,
        //    };

        //    _dbContext.subjects.Add(newSub);
        //    _dbContext.SaveChanges();
        //    return Ok(subject);
        //}

        //[HttpPut]
        //[Route("Update/{id}")]
        //public IActionResult UpdateSubject([FromBody] SubjectDTO subject, int id) 
        //{
        //    var sub = _dbContext.subjects.SingleOrDefault(x => x.id == id);

        //    sub.Name = subject.Name;

        //    _dbContext.SaveChanges();
        //    return Ok(subject);
        //}
    }
}
