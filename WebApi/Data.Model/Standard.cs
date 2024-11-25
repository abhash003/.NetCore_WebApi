using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Standard
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ClassTeacherId { get; set; }
        public Faculty ClassTeacher { get; set; }

        public List<Subject> subjects { get; set; }

        public List<Faculty> Faculties { get; set; }
    }
}
