using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class StudentTerm
    {
        public int StudentTermId { get; set; }
        public int StudentId { get; set; }
        public int Term { get; set; }
        public string TermAbbrev { get; set; }
        public string TermLabel { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
