using coreWebAPI.DataBase;
using coreWebAPI.DTO;
using coreWebAPI.model;
using Microsoft.AspNetCore.Mvc;

namespace coreWebAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private SchoolDBContext _dbContext;

        public AddressController(SchoolDBContext dBContext) 
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllAddress()
        {
            var addressList = _dbContext.Addresses.ToList();

            return Ok(addressList);
        }

        [HttpGet]
        [Route ("{id}") ]
        public IActionResult GetAddress(int id)
        {
            var addressList = _dbContext.Addresses.FirstOrDefault(x => x.Id == id);
            
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

            _dbContext.Addresses.Add(AddressDomainModel);
            _dbContext.SaveChanges();

            return Ok(AddressDomainModel);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult UpdateAddress([FromBody] AddressDTO address, int id)
        {
            var addressDomain = _dbContext.Addresses.Find(id);

            if(addressDomain == null)
            {
                return NotFound();
            }
            addressDomain.Street = address.Street;
            addressDomain.PostalCode = address.PostalCode;
            addressDomain.City = address.City;

            _dbContext.SaveChanges();

            return Ok(addressDomain);

        }
    }
}
