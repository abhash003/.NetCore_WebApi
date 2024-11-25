using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.Repository.Repository.Faculties
{
    public interface IFacultyRepository
    {
        List<Faculty> GetAllFaculties ();

        Faculty GetFaculty(int id);

        void CreateFaculty(Faculty faculty);

        void UpdateFaculty(Faculty faculty);

    }
}
