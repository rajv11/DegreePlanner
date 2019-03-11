using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class DegreeRequirement
    {
        public int DegreeRequirementId { get; set; }
        public int DegreeId { get; set; }
        public int RequirementId { get; set; }

        public ICollection<Degree> Degrees { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
    }
}
