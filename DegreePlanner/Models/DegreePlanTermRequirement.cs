using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class DegreePlanTermRequirement
    {
        public int DegreePlanTermRequirementId { get; set; }
        public int DegreePlanId { get; set; }
        public int TermId { get; set; }
        public int RequirementId { get; set; }

        public ICollection<Degree> Degrees { get; set; }
        public ICollection<StudentTerm> StudentTerms { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
    }
}
