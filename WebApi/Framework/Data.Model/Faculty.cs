using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public Address Address { get; set; }

        public Subject Subject { get; set; }
    }
}
