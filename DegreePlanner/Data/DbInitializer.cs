using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(DegreePlannerDbContext context)
        {
            if (context.Degrees.Any())
            {
                Console.WriteLine(" Degrees already exist");
            }
            else
            {
                var Degrees = new Models.Degree[]
                {
                    new Models.Degree {DegreeID=1, DegreeAbrev = "ACS+2", DegreeName = "MS ACS +2" },
                    new Models.Degree {DegreeID=2, DegreeAbrev = "ACS+DB", DegreeName = "MS ACS +DB"},
                    new Models.Degree {DegreeID=3, DegreeAbrev = "ACS+NF", DegreeName ="MS ACS+NF"},
                    new Models.Degree {DegreeID=4, DegreeAbrev ="ACS", DegreeName  ="MS ACS" }

                };
                Console.WriteLine($"Inserted {Degrees.Length} new degrees");

                foreach (Models.Degree d in Degrees)
                {
                    context.Degrees.Add(d);
                }
                context.SaveChanges();
            }

            if (context.Requirements.Any())
            {
                Console.WriteLine("Requirements already exist");
            }
            else
            {
                var Requirements = new Models.Requirement[]
                {
                    new Models.Requirement {RequirementID= 460, RequirementAbbrev="DB", RequirementName="44-460 Database"},
                    new Models.Requirement {RequirementID= 356, RequirementAbbrev="NF",RequirementName="44-356 Network Fundamemtals"},
                    new Models.Requirement {RequirementID= 542, RequirementAbbrev="OOP",RequirementName="44-542 OOP with Java"},
                    new Models.Requirement {RequirementID= 563, RequirementAbbrev="Web apps",RequirementName="44-563 Web apps"},
                    new Models.Requirement {RequirementID= 560, RequirementAbbrev="ADB",RequirementName="44-560 ADB"},
                    new Models.Requirement {RequirementID= 555, RequirementAbbrev="NS",RequirementName="44-555 Network Security"},
                    new Models.Requirement {RequirementID= 618, RequirementAbbrev="PM",RequirementName="44-618 PM"},
                    new Models.Requirement {RequirementID= 1, RequirementAbbrev="Mobile",RequirementName="44-643 or 44-644"},
                    new Models.Requirement {RequirementID= 664, RequirementAbbrev="UX",RequirementName="44-664 UX"},
                    new Models.Requirement {RequirementID= 10, RequirementAbbrev="E1",RequirementName="Elective 1"},
                    new Models.Requirement {RequirementID= 20, RequirementAbbrev="E2",RequirementName="Elective 2"},
                    new Models.Requirement {RequirementID= 691, RequirementAbbrev="GDP1",RequirementName="GDP1"},
                    new Models.Requirement {RequirementID= 692, RequirementAbbrev="GDP2",RequirementName="GDP2"}
                };
                Console.WriteLine($"Inserted {Requirements.Length} new Requirements");

                foreach (Models.Requirement req in Requirements)
                {
                    context.Requirements.Add(req);
                }
                context.SaveChanges();

            }
        }
    }
}
