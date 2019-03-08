using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class DegreeRequirement
    {
        public int DegreeRequirementID { get; set; }
        public int DegreeID { get; set; }
        public int RequirementID { get; set; }

        public ICollection<Degree> Degrees { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
    }
}
