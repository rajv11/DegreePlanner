using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class DegreePlanTermRequirement
    {
        public int DegreePlanTermRequirementID { get; set; }
        public int DegreePlanID { get; set; }
        public int TermID { get; set; }
        public int RequirementID { get; set; }

        public ICollection<Degree> Degrees { get; set; }
        public ICollection<StudentTerm> StudentTerms { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
    }
}
