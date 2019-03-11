using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Models
{
    public class Requirement
    {
        public int RequirementId { get; set; }
        public string RequirementAbbrev { get; set; }
        public string RequirementName { get; set; }
    }
}
