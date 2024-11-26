using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Repository.DataBase;

namespace WebApi.Data.Repository.Repository.Standards
{
    public class StandardRepository : IStandardRepository
    {
        private SchoolDBContext _schoolDBContext;

        public StandardRepository(SchoolDBContext dBContext)
        {
            _schoolDBContext = dBContext;
        }

        public List<Standard> GetAllStandards()
        {
            var standard = _schoolDBContext.Standards.ToList();

            return standard;
        }

        public Standard GetStandard(int id)
        {
            var standard = _schoolDBContext.Standards.Include(x => x.subjects).Include(x => x.Faculties).FirstOrDefault(x => x.Id == id);

            return standard;
        }

        public void CreateStandard(Standard standard)
        {
            _schoolDBContext.Standards.Add(standard);
            _schoolDBContext.SaveChanges();
        }


        public void UpdateStandard(Standard standard)
        {
            _schoolDBContext.SaveChanges();
        }
    }
}
