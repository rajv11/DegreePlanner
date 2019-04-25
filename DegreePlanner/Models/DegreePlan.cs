﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class DegreePlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DegreePlanId { get; set; }

        [ForeignKey("DegreeId")]
        public int DegreeId { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        [Required]
        
        [Display(Name = "Abbreviation")]
        public string DegreePlanAbbrev { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string DegreePlanName { get; set; }


        public Degree Degree { get; set; }
        public Student Student { get; set; }

        public ICollection<StudentTerm> StudentTerms { get; set; }

        //public ICollection<DegreePlan> DegreePlans { get; set; }
    }
}
