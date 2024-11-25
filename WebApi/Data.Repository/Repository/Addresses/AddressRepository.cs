using Data.Model;
using WebApi.Data.Repository.DataBase;

namespace WebApi.Data.Repository.Repository.Addresses
{
    public class AddressRepository : IAddressRepository
    {
        private SchoolDBContext _schoolDBContext;

        public AddressRepository(SchoolDBContext dBContext)
        {
            _schoolDBContext = dBContext;
        }
        
        public Address GetAddress(int id)
        {
            var address = _schoolDBContext.Addresses.FirstOrDefault(x => x.Id == id);

            return address;
        }

        public List<Address> GetAllAddresses()
        {
            var Addresses = _schoolDBContext.Addresses.ToList();

            return Addresses;
        }

        public void CreateAddress(Address address)
        {
            _schoolDBContext.Addresses.Add(address);
            _schoolDBContext.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            _schoolDBContext.SaveChanges();
        }
    }
}
