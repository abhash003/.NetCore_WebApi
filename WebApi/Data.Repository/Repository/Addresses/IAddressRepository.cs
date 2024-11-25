using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.Repository.Repository.Addresses
{
    public interface IAddressRepository
    {
        List<Address> GetAllAddresses();

        Address GetAddress(int id);

        void CreateAddress(Address address);

        void UpdateAddress(Address address);
    }
}
