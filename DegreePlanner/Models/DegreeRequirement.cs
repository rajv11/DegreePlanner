using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class DegreeRequirement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DegreeRequirementId { get; set; }

        [ForeignKey("DegreeId")]
        public int DegreeId { get; set; }

        [ForeignKey("RequirementId")]
        public int RequirementId { get; set; }

        public Degree Degree { get; set; }
        public Requirement Requirement { get; set; }
    }
}
