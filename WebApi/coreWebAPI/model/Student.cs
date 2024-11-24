using System.ComponentModel.DataAnnotations;

namespace coreWebAPI.model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNO { get; set; }

        public Address Address { get; set; }

        public Standard Standard { get; set; }
    }
}
