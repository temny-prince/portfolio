using PW1.Models.JoinTablesModels;

namespace PW1.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Group> Groups { get; set; } = new();
        public List<TestProject> TestProjects { get; set; } = new();  
    }
}