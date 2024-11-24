using System.ComponentModel.DataAnnotations;

namespace coreWebAPI.model
{
    public class Subject
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }
    }
}
