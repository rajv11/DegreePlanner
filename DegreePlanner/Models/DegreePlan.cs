using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class DegreePlan
    {
        public int DegreePlanId { get; set; }
        public int DegreeId { get; set; }
        public int StudentId { get; set; }
        public string DegreePlanAbbrev { get; set; }
        public string DegreePlanName { get; set; }

        public ICollection<Degree> Degrees { get; set; }
        public ICollection<Student> Studnets { get; set; }
    }
}
