namespace TestingPlatform.Application.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DirectionDTO Direction { get; set; }

        public CourseDTO Course { get; set; }

        public ProjectDTO Project { get; set; }
    }
}
