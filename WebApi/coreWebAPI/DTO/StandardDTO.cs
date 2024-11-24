using coreWebAPI.model;

namespace coreWebAPI.DTO
{
    public class StandardDTO
    {
        public string Name { get; set; }

        public string ClassTeacherName { get; set; }
        public List<Subject> subjects { get; set; }

        public List<Faculty> ClassteacherId { get; set; }
    }
}
