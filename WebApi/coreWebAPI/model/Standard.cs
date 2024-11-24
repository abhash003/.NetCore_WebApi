using System.ComponentModel.DataAnnotations;

namespace coreWebAPI.model
{
    public class Standard
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string ClassTeacherName { get; set; }

        public List<Subject> subjects { get; set; }

        public List<Faculty> ClassteacherId {  get; set; }
    }
}
