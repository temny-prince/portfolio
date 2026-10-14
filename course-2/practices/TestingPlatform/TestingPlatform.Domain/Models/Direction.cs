using TestingPlatform.Domain.Models.Enums;

namespace TestingPlatform.Domain.Models
{
    public class Direction
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Group> Groups { get; set; } = new();
        public List<TestDirection> TestDirections { get; set; } = new(); 
    }
}