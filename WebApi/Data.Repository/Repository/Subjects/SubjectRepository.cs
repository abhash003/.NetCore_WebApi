using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            var subject = _schoolDBContext.subjects.FirstOrDefault(x => x.id == id);

            return subject;
        }

        public List<Subject> GetAllSubjects()
        {
            var subjects = _schoolDBContext.subjects.ToList();

            return subjects;
        }

        public void CreateSubject(Subject subject)
        {
            _schoolDBContext.subjects.Add(subject);
            _schoolDBContext.SaveChanges();
        }


        public void UpdateSubject(Subject subject)
        {
            _schoolDBContext.SaveChanges();
        }
    }
}
