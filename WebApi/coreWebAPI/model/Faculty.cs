using System.ComponentModel.DataAnnotations;

namespace coreWebAPI.model
{
    public class Faculty
    {
        [Key]
        public int Id {  get; set; }

        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public Address Address { get; set; }

        public Subject Subject { get; set; }
    }
}
