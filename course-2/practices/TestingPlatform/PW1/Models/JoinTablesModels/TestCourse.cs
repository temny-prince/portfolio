namespace PW1.Models.JoinTablesModels
{
    public class TestCourse
    {
        public int TestId { get; set; }
        public Test Test { get; set; } = null!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
