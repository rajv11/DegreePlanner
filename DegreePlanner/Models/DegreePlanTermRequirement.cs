using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class DegreePlanTermRequirement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DegreePlanTermRequirementId { get; set; }

        [ForeignKey("DegreePlanId")]
        public int DegreePlanId { get; set; }


        public int TermId { get; set; }

        [ForeignKey("RequirementId")]
        public int RequirementId { get; set; }

        public DegreePlan DegreePlan { get; set; }
        public Requirement Requirement { get; set; }
    }
}
