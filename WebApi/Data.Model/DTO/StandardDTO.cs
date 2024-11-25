using Data.Model;

namespace Data.Model.DTO
{
    public class StandardDTO
    {
        public string Name { get; set; }

        public int ClassTeacherId { get; set; }

        public List<int> subjects { get; set; }

        public List<int> faculties { get; set; }
    }
}
