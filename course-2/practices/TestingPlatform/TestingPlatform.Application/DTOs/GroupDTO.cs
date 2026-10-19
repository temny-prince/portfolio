using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Application.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DirectionDto Direction { get; set; }

        public CourseDto Course { get; set; }

        public ProjectDto Project { get; set; }
    }
}
