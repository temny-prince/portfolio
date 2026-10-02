namespace PW1.Models.JoinTablesModels
{
    public class TestProject
    {
        public int TestId { get; set; }
        public Test Test { get; set; } = null!;

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
    }
}
