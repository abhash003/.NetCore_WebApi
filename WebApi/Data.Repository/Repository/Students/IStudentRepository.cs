
using Data.Model;

namespace WebApi.Data.Repository.Repository.Students
{
    public interface IStudentRepository
    {

        List<Student> GetAllStudents();

        Student GetStudent(int id);

        void CreateStudent(Student student);

        void UpdateStudent(Student student);
    }
}
