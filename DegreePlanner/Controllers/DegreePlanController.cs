using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DegreePlanner.Data;
using DegreePlanner.Models;

namespace DegreePlanner.Controllers
{
    public class DegreePlanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreePlanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DegreePlan
        public async Task<IActionResult> Index(String sortOrder, String searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AbbrvSortParm"] = sortOrder == "Abbrv" ? "Abbrv_desc" : "Abbrv";
            ViewData["CurrentFilter"] = searchString;

            var applicationDbContext = _context.DegreePlans.Include(d => d.Degree).Include(d => d.Student);
            var degreePlans = from dp in applicationDbContext
                             select dp;
            if (!String.IsNullOrEmpty(searchString))
            {
                degreePlans = degreePlans.Where(d => d.Student.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    degreePlans = degreePlans.OrderByDescending(dp => dp.DegreePlanName);
                        break;
                case "Abbrv_desc":
                    degreePlans = degreePlans.OrderByDescending(dp => dp.DegreePlanAbbrev);
                    break;
                case "Abbrv":
                    degreePlans = degreePlans.OrderBy(dp => dp.DegreePlanAbbrev);
                    break;
                default:
                    degreePlans = degreePlans.OrderBy(dp => dp.DegreePlanName);
                    break;
            }

            return View(await degreePlans.ToListAsync());
        }

        // GET: DegreePlan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlan = await _context.DegreePlans
                .Include(d => d.Degree)
                .Include(d => d.Student)
                .FirstOrDefaultAsync(m => m.DegreePlanId == id);
            if (degreePlan == null)
            {
                return NotFound();
            }

            return View(degreePlan);
        }

        // GET: DegreePlan/Create
        public IActionResult Create()
        {
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrev");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");
            return View();
        }

        // POST: DegreePlan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreePlanId,DegreeId,StudentId,DegreePlanAbbrev,DegreePlanName")] DegreePlan degreePlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreePlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrev", degreePlan.DegreeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", degreePlan.StudentId);
            return View(degreePlan);
        }

        // GET: DegreePlan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var degreePlan = await _context.DegreePlans
                .Include(p => p.Degree).ThenInclude(pd => pd.Requirements)
                .Include(p => p.Student)
                .Include(p => p.StudentTerms).ThenInclude(pt => pt.DegreePlanTermRequirements)
                .SingleOrDefaultAsync(m => m.DegreePlanId == id);


            if (degreePlan == null)
            {
                return NotFound();
            }
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrev", degreePlan.DegreeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", degreePlan.StudentId);
            return View(degreePlan);
        }

        // POST: DegreePlan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreePlanId,DegreeId,StudentId,DegreePlanAbbrev,DegreePlanName")] DegreePlan degreePlan)
        {
            if (id != degreePlan.DegreePlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreePlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreePlanExists(degreePlan.DegreePlanId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrev", degreePlan.DegreeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", degreePlan.StudentId);
            return View(degreePlan);
        }

        // GET: DegreePlan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlan = await _context.DegreePlans
                .Include(d => d.Degree)
                .Include(d => d.Student)
                .FirstOrDefaultAsync(m => m.DegreePlanId == id);
            if (degreePlan == null)
            {
                return NotFound();
            }

            return View(degreePlan);
        }

        // POST: DegreePlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreePlan = await _context.DegreePlans.FindAsync(id);
            _context.DegreePlans.Remove(degreePlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreePlanExists(int id)
        {
            return _context.DegreePlans.Any(e => e.DegreePlanId == id);
        }
    }
}
