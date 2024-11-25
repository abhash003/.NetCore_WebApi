using Data.Model;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Repository.DataBase;

namespace WebApi.Data.Repository.Repository.Faculties
{
    public class FacultyRepository : IFacultyRepository
    {
        private SchoolDBContext _schoolDBContext;

        public FacultyRepository(SchoolDBContext dBContext)
        {
            _schoolDBContext = dBContext;
        }

        public List<Faculty> GetAllFaculties()
        {
            var faculties = _schoolDBContext.Faculties.ToList();

            return faculties;
        }

        public Faculty GetFaculty(int id)
        {
            var faculty = _schoolDBContext.Faculties.Include(x => x.AddressId).Include(x => x.SubjectId).FirstOrDefault(x => x.Id == id);

            return faculty;
        }

        public void CreateFaculty(Faculty faculty)
        {
            _schoolDBContext.Faculties.Add(faculty);
            _schoolDBContext.SaveChanges();
        }

        public void UpdateFaculty(Faculty faculty)
        {
            _schoolDBContext.SaveChanges();
        }
    }
}
