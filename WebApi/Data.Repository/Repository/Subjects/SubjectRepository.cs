using Data.Model;
using WebApi.Data.Repository.DataBase;

namespace WebApi.Data.Repository.Repository.Subjects
{
    public class SubjectRepository : ISubjectRepository
    {
        private SchoolDBContext _schoolDBContext;

        public SubjectRepository(SchoolDBContext dBContext)
        {
            _schoolDBContext = dBContext;
        }

        public Subject GetSubject(int id)
        {
            var subject = _schoolDBContext.Subjects.FirstOrDefault(x => x.id == id);

            return subject;
        }

        public List<Subject> GetAllSubjects()
        {
            var subjects = _schoolDBContext.Subjects.ToList();

            return subjects;
        }

        public async Task CreateSubjectAsync(Subject subject)
        {
            await _schoolDBContext.Subjects.AddAsync(subject);
            await _schoolDBContext.SaveChangesAsync();
        }


        public void UpdateSubject(Subject subject)
        {
            _schoolDBContext.SaveChanges();
        }
    }
}
