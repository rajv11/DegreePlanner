using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DegreePlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Degrees.Any())
            {
                Console.WriteLine(" Degrees already exist");
            }
            else
            {
                var Degrees = new Models.Degree[]
                {
                    new Models.Degree {DegreeId=1, DegreeAbrev = "ACS+2", DegreeName = "MS ACS +2" },
                    new Models.Degree {DegreeId=2, DegreeAbrev = "ACS+DB", DegreeName = "MS ACS +DB"},
                    new Models.Degree {DegreeId=3, DegreeAbrev = "ACS+NF", DegreeName ="MS ACS+NF"},
                    new Models.Degree {DegreeId=4, DegreeAbrev ="ACS", DegreeName  ="MS ACS" }

                };
                Console.WriteLine($"Inserted {Degrees.Length} new degrees");

                foreach (Models.Degree degree in Degrees)
                {
                    context.Degrees.Add(degree);
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
                    new Models.Requirement {RequirementId= 460, RequirementAbbrev="DB", RequirementName="44-460 Database"},
                    new Models.Requirement {RequirementId= 356, RequirementAbbrev="NF",RequirementName="44-356 Network Fundamemtals"},
                    new Models.Requirement {RequirementId= 542, RequirementAbbrev="OOP",RequirementName="44-542 OOP with Java"},
                    new Models.Requirement {RequirementId= 563, RequirementAbbrev="Web apps",RequirementName="44-563 Web apps"},
                    new Models.Requirement {RequirementId= 560, RequirementAbbrev="ADB",RequirementName="44-560 ADB"},
                    new Models.Requirement {RequirementId= 555, RequirementAbbrev="NS",RequirementName="44-555 Network Security"},
                    new Models.Requirement {RequirementId= 618, RequirementAbbrev="PM",RequirementName="44-618 PM"},
                    new Models.Requirement {RequirementId= 1, RequirementAbbrev="Mobile",RequirementName="44-643 or 44-644"},
                    new Models.Requirement {RequirementId= 664, RequirementAbbrev="UX",RequirementName="44-664 UX"},
                    new Models.Requirement {RequirementId= 10, RequirementAbbrev="E1",RequirementName="Elective 1"},
                    new Models.Requirement {RequirementId= 20, RequirementAbbrev="E2",RequirementName="Elective 2"},
                    new Models.Requirement {RequirementId= 691, RequirementAbbrev="GDP1",RequirementName="GDP1"},
                    new Models.Requirement {RequirementId= 692, RequirementAbbrev="GDP2",RequirementName="GDP2"}
                };
                Console.WriteLine($"Inserted {Requirements.Length} new Requirements");

                foreach (Models.Requirement req in Requirements)
                {
                    context.Requirements.Add(req);
                }
                context.SaveChanges();

            }

            if (context.DegreeRequirements.Any())
            {
                Console.WriteLine(" DegreeRequirement already exist");
            }
            else
            {
                var DegreeRequirements = new Models.DegreeRequirement[]
                {
                    new Models.DegreeRequirement {DegreeRequirementId=1,DegreeId=1,RequirementId=460, RequirementName="44-460 Database"},
new Models.DegreeRequirement {DegreeRequirementId=2,DegreeId=1,RequirementId=356, RequirementName="44-356 Network Fundamemtals"},
new Models.DegreeRequirement {DegreeRequirementId=3,DegreeId=1,RequirementId=542, RequirementName="44-542 OOP with Java"},
new Models.DegreeRequirement {DegreeRequirementId=4,DegreeId=1,RequirementId=563, RequirementName="44-563 Web apps"},
new Models.DegreeRequirement {DegreeRequirementId=5,DegreeId=1,RequirementId=560, RequirementName="44-560 ADB"},
new Models.DegreeRequirement {DegreeRequirementId=6,DegreeId=1,RequirementId=555, RequirementName="44-555 Network Security"},
new Models.DegreeRequirement {DegreeRequirementId=7,DegreeId=1,RequirementId=618, RequirementName="44-618 PM"},
new Models.DegreeRequirement {DegreeRequirementId=8,DegreeId=1,RequirementId=1, RequirementName="44-643 or 44-644"},
new Models.DegreeRequirement {DegreeRequirementId=9,DegreeId=1,RequirementId=664, RequirementName="44-664 UX"},
new Models.DegreeRequirement {DegreeRequirementId=10,DegreeId=1,RequirementId=10, RequirementName="Elective 1"},
new Models.DegreeRequirement {DegreeRequirementId=11,DegreeId=1,RequirementId=20, RequirementName="Elective 2"},
new Models.DegreeRequirement {DegreeRequirementId=12,DegreeId=1,RequirementId=691, RequirementName="GDP1"},
new Models.DegreeRequirement {DegreeRequirementId=13,DegreeId=1,RequirementId=692, RequirementName="GDP2"},
new Models.DegreeRequirement {DegreeRequirementId=14,DegreeId=2,RequirementId=460, RequirementName="44-460 Database"},
new Models.DegreeRequirement {DegreeRequirementId=15,DegreeId=2,RequirementId=542, RequirementName="44-542 OOP with Java"},
new Models.DegreeRequirement {DegreeRequirementId=16,DegreeId=2,RequirementId=563, RequirementName="44-563 Web apps"},
new Models.DegreeRequirement {DegreeRequirementId=17,DegreeId=2,RequirementId=560, RequirementName="44-560 ADB"},
new Models.DegreeRequirement {DegreeRequirementId=18,DegreeId=2,RequirementId=555, RequirementName="44-555 Network Security"},
new Models.DegreeRequirement {DegreeRequirementId=19,DegreeId=2,RequirementId=618, RequirementName="44-618 PM"},
new Models.DegreeRequirement {DegreeRequirementId=20,DegreeId=2,RequirementId=1, RequirementName="44-643 or 44-644"},
new Models.DegreeRequirement {DegreeRequirementId=21,DegreeId=2,RequirementId=664, RequirementName="44-664 UX"},
new Models.DegreeRequirement {DegreeRequirementId=22,DegreeId=2,RequirementId=10, RequirementName="Elective 1"},
new Models.DegreeRequirement {DegreeRequirementId=23,DegreeId=2,RequirementId=20, RequirementName="Elective 2"},
new Models.DegreeRequirement {DegreeRequirementId=24,DegreeId=2,RequirementId=691, RequirementName="GDP1"},
new Models.DegreeRequirement {DegreeRequirementId=25,DegreeId=2,RequirementId=692, RequirementName="GDP2"},
new Models.DegreeRequirement {DegreeRequirementId=26,DegreeId=3,RequirementId=356, RequirementName="44-356 Network Fundamemtals"},
new Models.DegreeRequirement {DegreeRequirementId=27,DegreeId=3,RequirementId=542, RequirementName="44-542 OOP with Java"},
new Models.DegreeRequirement {DegreeRequirementId=28,DegreeId=3,RequirementId=563, RequirementName="44-563 Web apps"},
new Models.DegreeRequirement {DegreeRequirementId=29,DegreeId=3,RequirementId=560, RequirementName="44-560 ADB"},
new Models.DegreeRequirement {DegreeRequirementId=30,DegreeId=3,RequirementId=555, RequirementName="44-555 Network Security"},
new Models.DegreeRequirement {DegreeRequirementId=31,DegreeId=3,RequirementId=618, RequirementName="44-618 PM"},
new Models.DegreeRequirement {DegreeRequirementId=32,DegreeId=3,RequirementId=1, RequirementName="44-643 or 44-644"},
new Models.DegreeRequirement {DegreeRequirementId=33,DegreeId=3,RequirementId=664, RequirementName="44-664 UX"},
new Models.DegreeRequirement {DegreeRequirementId=34,DegreeId=3,RequirementId=10, RequirementName="Elective 1"},
new Models.DegreeRequirement {DegreeRequirementId=35,DegreeId=3,RequirementId=20, RequirementName="Elective 2"},
new Models.DegreeRequirement {DegreeRequirementId=36,DegreeId=3,RequirementId=691, RequirementName="GDP1"},
new Models.DegreeRequirement {DegreeRequirementId=37,DegreeId=3,RequirementId=692, RequirementName="GDP2"},
new Models.DegreeRequirement {DegreeRequirementId=38,DegreeId=4,RequirementId=542, RequirementName="44-542 OOP with Java"},
new Models.DegreeRequirement {DegreeRequirementId=39,DegreeId=4,RequirementId=563, RequirementName="44-563 Web apps"},
new Models.DegreeRequirement {DegreeRequirementId=40,DegreeId=4,RequirementId=560, RequirementName="44-560 ADB"},
new Models.DegreeRequirement {DegreeRequirementId=41,DegreeId=4,RequirementId=555, RequirementName="44-555 Network Security"},
new Models.DegreeRequirement {DegreeRequirementId=42,DegreeId=4,RequirementId=618, RequirementName="44-618 PM"},
new Models.DegreeRequirement {DegreeRequirementId=43,DegreeId=4,RequirementId=1, RequirementName="44-643 or 44-644"},
new Models.DegreeRequirement {DegreeRequirementId=44,DegreeId=4,RequirementId=664, RequirementName="44-664 UX"},
new Models.DegreeRequirement {DegreeRequirementId=45,DegreeId=4,RequirementId=10, RequirementName="Elective 1"},
new Models.DegreeRequirement {DegreeRequirementId=46,DegreeId=4,RequirementId=20, RequirementName="Elective 2"},
new Models.DegreeRequirement {DegreeRequirementId=47,DegreeId=4,RequirementId=691, RequirementName="GDP1"},
new Models.DegreeRequirement {DegreeRequirementId=48,DegreeId=4,RequirementId=692, RequirementName="GDP2" }

                };
                Console.WriteLine($"Inserted {DegreeRequirements.Length} new DegreeRequirements");
            
                foreach (Models.DegreeRequirement degreReq in DegreeRequirements)
                {
                    context.DegreeRequirements.Add(degreReq);
                }
                context.SaveChanges();
            }
            if (context.Students.Any())
            {
                Console.WriteLine(" Students already exist");
            }
            else
            {
                var Students = new Models.Student[]
                {
                    new Models.Student{StudentId=531519,FirstName="Yashwanth" ,LastName="Bommineni" ,SNumber="S531519" ,_919=919562791},
                    new Models.Student{StudentId=531499,FirstName="Saicharan" ,LastName="Gurudu" ,SNumber="s531499" ,_919=919558726},
                    new Models.Student{StudentId=531370,FirstName="Vamshi raj" ,LastName="jennaikode" ,SNumber="s531370" ,_919=919563101},
                    new Models.Student{StudentId=531439,FirstName="Dattu Bhargav" ,LastName="Medarametla" ,SNumber="s531439" ,_919=919563365},
                    };
                Console.WriteLine($"Inserted {Students.Length} new degrees");

                foreach (Models.Student student in Students)
                {
                    context.Students.Add(student);
                }
                context.SaveChanges();
            }

            if (context.StudentTerms.Any())
            {
                Console.WriteLine(" StudentTerms already exist");
            }
            else
            {
                var StudentTerms = new Models.StudentTerm[]
                {
                    new Models.StudentTerm{StudentTermId=1,StudentId=531519, Term=1,TermAbbrev="S19" ,TermLabel="Spring 2019"},
                    new Models.StudentTerm{StudentTermId=2,StudentId=531519, Term=2,TermAbbrev="Su19" ,TermLabel="Summer 2019"},
                    new Models.StudentTerm{StudentTermId=3,StudentId=531519, Term=3,TermAbbrev="F19" ,TermLabel="Fall 2019"},
                    new Models.StudentTerm{StudentTermId=4,StudentId=531519, Term=4,TermAbbrev="S20" ,TermLabel="Spring 2020"},
                    new Models.StudentTerm{StudentTermId=5,StudentId=531519, Term=5,TermAbbrev="Su20" ,TermLabel="Summer2020"},
                    new Models.StudentTerm{StudentTermId=6,StudentId=531499, Term=1,TermAbbrev="F19" ,TermLabel="Fall 2019"},
                    new Models.StudentTerm{StudentTermId=7,StudentId=531499, Term=2,TermAbbrev="S20" ,TermLabel="Spring 2020"},
                    new Models.StudentTerm{StudentTermId=8,StudentId=531499, Term=3,TermAbbrev="Su20" ,TermLabel="Summer2020"},
                    new Models.StudentTerm{StudentTermId=9,StudentId=531499, Term=4,TermAbbrev="F20" ,TermLabel="Fall 2020"},
                    new Models.StudentTerm{StudentTermId=10,StudentId=531499, Term=5,TermAbbrev="S21" ,TermLabel="Spring2021"},
                    new Models.StudentTerm{StudentTermId=11,StudentId=531370, Term=1,TermAbbrev="Su19" ,TermLabel="Fall 2019"},
                    new Models.StudentTerm{StudentTermId=12,StudentId=531370, Term=2,TermAbbrev="F19" ,TermLabel="Spring 2019"},
                    new Models.StudentTerm{StudentTermId=13,StudentId=531370, Term=3,TermAbbrev="S19" ,TermLabel="Summer 2020"},
                    new Models.StudentTerm{StudentTermId=14,StudentId=531370, Term=4,TermAbbrev="Su20" ,TermLabel="Fall 2020"},
                    new Models.StudentTerm{StudentTermId=15,StudentId=531370, Term=5,TermAbbrev="F20" ,TermLabel="Spring 2021"},
                    new Models.StudentTerm{StudentTermId=16,StudentId=531439, Term=1,TermAbbrev="S18" ,TermLabel="Spring 2018"},
                    new Models.StudentTerm{StudentTermId=17,StudentId=531439, Term=2,TermAbbrev="Su18" ,TermLabel="Summer 2018"},
                    new Models.StudentTerm{StudentTermId=18,StudentId=531439, Term=3,TermAbbrev="F18" ,TermLabel="Fall 2018"},
                    new Models.StudentTerm{StudentTermId=19,StudentId=531439, Term=4,TermAbbrev="S19" ,TermLabel="Spring 2019"},
                    new Models.StudentTerm{StudentTermId=20,StudentId=531439, Term=5,TermAbbrev="Su19" ,TermLabel="Summer2019"},
                };
                Console.WriteLine($"Inserted {StudentTerms.Length} new StudentTerms");

                foreach (Models.StudentTerm studentTerm in StudentTerms)
                {
                    context.StudentTerms.Add(studentTerm);
                }
                context.SaveChanges();

            }

            if (context.DegreePlans.Any())
            {
                Console.WriteLine(" DegreePlan already exist");
            }
            else
            {
                var DegreePlans = new Models.DegreePlan[]
                {
                    new Models.DegreePlan{DegreePlanId=10,DegreeId=3,StudentId=531519,DegreePlanAbbrev="NSO",DegreePlanName="No summer off"},
                    new Models.DegreePlan{DegreePlanId=11,DegreeId=3,StudentId=531519,DegreePlanAbbrev="SO",DegreePlanName="summer off"},
                    new Models.DegreePlan{DegreePlanId=12,DegreeId=3,StudentId=531499,DegreePlanAbbrev="NSO",DegreePlanName="No summer off"},
                    new Models.DegreePlan{DegreePlanId=13,DegreeId=3,StudentId=531499,DegreePlanAbbrev="SO",DegreePlanName="summer off"},
                    new Models.DegreePlan{DegreePlanId=14,DegreeId=3,StudentId=531370,DegreePlanAbbrev="NSO",DegreePlanName="No summer off"},
                    new Models.DegreePlan{DegreePlanId=15,DegreeId=3,StudentId=531370,DegreePlanAbbrev="SO",DegreePlanName="summer off"},
                    new Models.DegreePlan{DegreePlanId=16,DegreeId=3,StudentId=531439,DegreePlanAbbrev="NSO",DegreePlanName="No summer off"},
                    new Models.DegreePlan{DegreePlanId=17,DegreeId=3,StudentId=531439,DegreePlanAbbrev="SO",DegreePlanName="summer off"}
                 };
                Console.WriteLine($"Inserted {DegreePlans.Length} new DegreePlans");

                foreach (Models.DegreePlan degreePlan in DegreePlans)
                {
                    context.DegreePlans.Add(degreePlan);
                }
                context.SaveChanges();
            }

            

            if (context.DegreePlanTermRequirements.Any())
            {
                Console.WriteLine("DegreePlanTermRequirements already exist");
            }
            else
            {
                var degreePlanTermRequirements = new Models.DegreePlanTermRequirement[]
                {
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=1,DegreePlanId=10,TermId=1,RequirementId=356},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=2,DegreePlanId=10,TermId=1,RequirementId=542},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=3,DegreePlanId=10,TermId=1,RequirementId=563},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=4,DegreePlanId=10,TermId=2,RequirementId=560},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=5,DegreePlanId=10,TermId=2,RequirementId=555},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=6,DegreePlanId=10,TermId=2,RequirementId=618},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=7,DegreePlanId=10,TermId=3,RequirementId=1},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=8,DegreePlanId=10,TermId=3,RequirementId=664},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=9,DegreePlanId=10,TermId=4,RequirementId=691},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=10,DegreePlanId=10,TermId=4,RequirementId=10},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=11,DegreePlanId=10,TermId=4,RequirementId=20},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=12,DegreePlanId=10,TermId=5,RequirementId=692},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=13,DegreePlanId=11,TermId=1,RequirementId=356},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=14,DegreePlanId=11,TermId=1,RequirementId=542},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=15,DegreePlanId=11,TermId=1,RequirementId=563},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=16,DegreePlanId=11,TermId=3,RequirementId=560},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=17,DegreePlanId=11,TermId=3,RequirementId=555},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=18,DegreePlanId=11,TermId=3,RequirementId=618},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=19,DegreePlanId=11,TermId=4,RequirementId=1},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=20,DegreePlanId=11,TermId=4,RequirementId=664},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=21,DegreePlanId=11,TermId=4,RequirementId=691},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=22,DegreePlanId=11,TermId=5,RequirementId=10},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=23,DegreePlanId=11,TermId=5,RequirementId=20},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=24,DegreePlanId=11,TermId=5,RequirementId=692},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=25,DegreePlanId=12,TermId=1,RequirementId=356},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=26,DegreePlanId=12,TermId=1,RequirementId=542},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=27,DegreePlanId=12,TermId=1,RequirementId=563},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=28,DegreePlanId=12,TermId=2,RequirementId=560},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=29,DegreePlanId=12,TermId=2,RequirementId=555},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=30,DegreePlanId=12,TermId=2,RequirementId=618},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=31,DegreePlanId=12,TermId=3,RequirementId=1},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=32,DegreePlanId=12,TermId=3,RequirementId=664},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=33,DegreePlanId=12,TermId=4,RequirementId=691},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=34,DegreePlanId=12,TermId=4,RequirementId=10},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=35,DegreePlanId=12,TermId=5,RequirementId=20},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=36,DegreePlanId=12,TermId=5,RequirementId=692},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=37,DegreePlanId=13,TermId=1,RequirementId=356},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=38,DegreePlanId=13,TermId=1,RequirementId=542},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=39,DegreePlanId=13,TermId=1,RequirementId=563},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=40,DegreePlanId=13,TermId=2,RequirementId=560},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=41,DegreePlanId=13,TermId=2,RequirementId=555},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=42,DegreePlanId=13,TermId=2,RequirementId=618},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=43,DegreePlanId=13,TermId=3,RequirementId=1},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=44,DegreePlanId=13,TermId=4,RequirementId=664},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=45,DegreePlanId=13,TermId=4,RequirementId=691},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=46,DegreePlanId=13,TermId=4,RequirementId=10},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=47,DegreePlanId=13,TermId=5,RequirementId=20},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=48,DegreePlanId=13,TermId=5,RequirementId=692},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=49,DegreePlanId=14,TermId=1,RequirementId=356},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=50,DegreePlanId=14,TermId=1,RequirementId=542},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=51,DegreePlanId=14,TermId=1,RequirementId=563},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=52,DegreePlanId=14,TermId=2,RequirementId=560},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=53,DegreePlanId=14,TermId=2,RequirementId=555},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=54,DegreePlanId=14,TermId=2,RequirementId=618},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=55,DegreePlanId=14,TermId=3,RequirementId=1},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=56,DegreePlanId=14,TermId=3,RequirementId=664},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=57,DegreePlanId=14,TermId=4,RequirementId=691},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=58,DegreePlanId=14,TermId=4,RequirementId=10},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=59,DegreePlanId=14,TermId=4,RequirementId=20},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=60,DegreePlanId=14,TermId=5,RequirementId=692},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=61,DegreePlanId=15,TermId=1,RequirementId=356},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=62,DegreePlanId=15,TermId=1,RequirementId=542},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=63,DegreePlanId=15,TermId=1,RequirementId=563},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=64,DegreePlanId=15,TermId=2,RequirementId=560},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=65,DegreePlanId=15,TermId=2,RequirementId=555},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=66,DegreePlanId=15,TermId=2,RequirementId=618},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=67,DegreePlanId=15,TermId=4,RequirementId=1},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=68,DegreePlanId=15,TermId=4,RequirementId=664},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=69,DegreePlanId=15,TermId=4,RequirementId=691},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=70,DegreePlanId=15,TermId=5,RequirementId=10},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=71,DegreePlanId=15,TermId=5,RequirementId=20},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=72,DegreePlanId=15,TermId=5,RequirementId=692},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=73,DegreePlanId=16,TermId=1,RequirementId=356},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=74,DegreePlanId=16,TermId=1,RequirementId=542},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=75,DegreePlanId=16,TermId=1,RequirementId=563},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=76,DegreePlanId=16,TermId=2,RequirementId=560},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=77,DegreePlanId=16,TermId=2,RequirementId=555},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=78,DegreePlanId=16,TermId=2,RequirementId=618},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=79,DegreePlanId=16,TermId=3,RequirementId=1},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=80,DegreePlanId=16,TermId=3,RequirementId=664},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=81,DegreePlanId=16,TermId=4,RequirementId=691},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=82,DegreePlanId=16,TermId=4,RequirementId=10},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=83,DegreePlanId=16,TermId=4,RequirementId=20},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=84,DegreePlanId=16,TermId=5,RequirementId=692},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=85,DegreePlanId=17,TermId=1,RequirementId=356},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=86,DegreePlanId=17,TermId=1,RequirementId=542},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=87,DegreePlanId=17,TermId=1,RequirementId=563},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=88,DegreePlanId=17,TermId=3,RequirementId=560},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=89,DegreePlanId=17,TermId=3,RequirementId=555},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=90,DegreePlanId=17,TermId=3,RequirementId=618},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=91,DegreePlanId=17,TermId=4,RequirementId=1},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=92,DegreePlanId=17,TermId=4,RequirementId=664},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=93,DegreePlanId=17,TermId=4,RequirementId=691},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=94,DegreePlanId=17,TermId=5,RequirementId=10},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=95,DegreePlanId=17,TermId=5,RequirementId=20},
                    new Models.DegreePlanTermRequirement {DegreePlanTermRequirementId=96,DegreePlanId=17,TermId=5,RequirementId=692}
                };
                Console.WriteLine($"Inserted {degreePlanTermRequirements.Length} new DegreePlanTermRequirement");

                foreach (Models.DegreePlanTermRequirement degreePlanReq in degreePlanTermRequirements)
                {
                    context.DegreePlanTermRequirements.Add(degreePlanReq);
                }
                context.SaveChanges();

            }





            
        }
    }
}
