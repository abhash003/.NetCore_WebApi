using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.Repository.Repository.Standards
{
    public interface IStandardRepository
    {
        List<Standard> GetAllStandards();

        Standard GetStandard(int id);

        void CreateStandard(Standard standard);

        void UpdateStandard(Standard standard);
    }
}
