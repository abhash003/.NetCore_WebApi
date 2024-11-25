using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNO { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int StandardId { get; set; }
        public Standard Standard { get; set; }
    }
}
