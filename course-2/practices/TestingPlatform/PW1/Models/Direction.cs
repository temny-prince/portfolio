using PW1.Models.JoinTablesModels;

namespace PW1.Models
{
    public class Direction
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Group> Groups { get; set; } = new();
        public List<TestDirection> TestDirections { get; set; } = new(); 
    }
}