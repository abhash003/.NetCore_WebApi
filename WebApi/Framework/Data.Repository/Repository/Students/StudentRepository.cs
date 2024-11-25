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

        public List<Student> GetAllStudents()
        {
            var student = _schoolDBContext.Students.ToList();

            return student;
        }

        public Student GetStudent(int id)
        {
            var student = _schoolDBContext.Students.FirstOrDefault(x => x.Id == id);

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
