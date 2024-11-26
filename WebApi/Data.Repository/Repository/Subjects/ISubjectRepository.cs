using Data.Model;

namespace WebApi.Data.Repository.Repository.Subjects
{
    public interface ISubjectRepository
    {
        List<Subject> GetAllSubjects();

        Subject GetSubject(int id);

        Task CreateSubjectAsync(Subject subject);

        void UpdateSubject(Subject subject);

    }
}
