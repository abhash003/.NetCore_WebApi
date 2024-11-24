using coreWebAPI.model;

namespace coreWebAPI.DTO
{
    public class StudentDTO
    {
        public string Name { get; set; }

        public string PhoneNO { get; set; }

        public Address Address { get; set; }

        public Standard Standard { get; set; }
    }
}
