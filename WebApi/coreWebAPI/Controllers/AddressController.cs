using Data.Model;
using Data.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repository.DataBase;
using WebApi.Data.Repository.Repository.Addresses;
using WebApi.Data.Repository.Repository.Standards;

namespace coreWebAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressRepository addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllAddress()
        {
            var addressList = addressRepository.GetAllAddresses();

            return Ok(addressList);
        }

        [HttpGet]
        [Route ("{id}") ]
        public IActionResult GetAddress(int id)
        {
            var addressList = addressRepository.GetAddress(id);
            
            return Ok(addressList);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateAddress([FromBody] AddressDTO address)
        {
            var AddressDomainModel = new Address
            {
                City = address.City,
                Street = address.Street,
                PostalCode = address.PostalCode,
            };

            addressRepository.CreateAddress(AddressDomainModel);

            return Ok(AddressDomainModel);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult UpdateAddress([FromBody] AddressDTO address, int id)
        {
            var addressDomain = addressRepository.GetAddress(id);

            if(addressDomain == null)
            {
                return NotFound();
            }
            addressDomain.Street = address.Street;
            addressDomain.PostalCode = address.PostalCode;
            addressDomain.City = address.City;

            addressRepository.UpdateAddress(addressDomain);

            return Ok(addressDomain);

        }
    }
}
