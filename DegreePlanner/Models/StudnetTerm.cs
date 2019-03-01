using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class StudnetTerm
    {
        public int StudentTermID { get; set; }
        public int StudentID { get; set; }
        public int Term { get; set; }
        public string TermAbbrev { get; set; }
        public string TermLable { get; set; }

    }
}
