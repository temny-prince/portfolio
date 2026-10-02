using PW1.Models.JoinTablesModels;

namespace PW1.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int DirectionId { get; set; }
        public int CourseId { get; set; }
        public int ProjectId { get; set; }

        public Direction Direction { get; set; } = null!;
        public Course Course { get; set; } = null!;
        public Project Project { get; set; } = null!;

        public List<Student> Students { get; set; } = new();
        public List<TestGroup> TestGroups { get; set; } = new();      
    }
}