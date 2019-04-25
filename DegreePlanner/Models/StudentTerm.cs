using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class StudentTerm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentTermId { get; set; }

        public int DegreePlanId { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public int Term { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "Abbreviation")]
        public string TermAbbrev { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        [Display(Name = "Term Label")]
        public string TermLabel { get; set; }

        public Student Student { get; set; }
        public DegreePlan DegreePlan { get; set; }

        public ICollection<DegreePlanTermRequirement> DegreePlanTermRequirements { get; set; }
    }
}
