using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Subject
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }
    }
}
