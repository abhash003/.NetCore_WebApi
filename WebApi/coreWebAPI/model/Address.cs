using System.ComponentModel.DataAnnotations;

namespace coreWebAPI.model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string? Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }
    }
}
