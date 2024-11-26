
using Data.Model;

namespace WebApi.Data.Repository.Repository.Students
{
    public interface IStudentRepository
    {

        Task<List<Student>?> GetAllStudentsAsync();

        Task<Student> GetStudentAsync(int id);

        void CreateStudent(Student student);

        void UpdateStudent(Student student);
    }
}
