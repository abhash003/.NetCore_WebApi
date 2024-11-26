using Data.Model;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Repository.DataBase;

namespace WebApi.Data.Repository.Repository.Students
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolDBContext _schoolDBContext;
        public StudentRepository( SchoolDBContext dBContext) 
        {
            _schoolDBContext = dBContext;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var student = await _schoolDBContext.Students.ToListAsync();

            return student;
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            var student = await _schoolDBContext.Students.Include(x => x.StandardId).Include(x => x.AddressId).FirstOrDefaultAsync(x => x.Id == id);

            return student;
        }

        public void CreateStudent(Student student)
        {
            _schoolDBContext.Students.Add(student);
            _schoolDBContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _schoolDBContext.SaveChanges();
        }
    }
}
