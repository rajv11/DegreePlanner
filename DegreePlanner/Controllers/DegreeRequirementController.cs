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
    public class DegreeRequirementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreeRequirementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DegreeRequirement
        public async Task<IActionResult> Index(String sortOrder)
        {
            ViewData["DegreeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "degree_desc" : "";
            ViewData["ReqSortParm"] = sortOrder == "Req" ? "Req_desc" : "Req";
            var applicationDbContext = _context.DegreeRequirements.Include(d => d.Degree).Include(d => d.Requirement);
            var dreq = from dr in applicationDbContext
                        select dr;
            switch (sortOrder)
            {
                case "degree_desc":
                    dreq = dreq.OrderByDescending(dr => dr.Degree);
                    break;
                
                case "Req_desc":
                    dreq = dreq.OrderByDescending(dr => dr.Requirement);
                    break;
                case "Req":
                    dreq = dreq.OrderBy(dr => dr.Requirement);
                    break;
                default:
                    dreq = dreq.OrderBy(dr => dr.Degree);
                    break;
            }

            return View(await dreq.ToListAsync());
        }

        // GET: DegreeRequirement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeRequirement = await _context.DegreeRequirements
                .Include(d => d.Degree)
                .Include(d => d.Requirement)
                .FirstOrDefaultAsync(m => m.DegreeRequirementId == id);
            if (degreeRequirement == null)
            {
                return NotFound();
            }

            return View(degreeRequirement);
        }

        // GET: DegreeRequirement/Create
        public IActionResult Create()
        {
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrev");
            ViewData["RequirementId"] = new SelectList(_context.Requirements, "RequirementId", "RequirementAbbrev");
            return View();
        }

        // POST: DegreeRequirement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreeRequirementId,DegreeId,RequirementId")] DegreeRequirement degreeRequirement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreeRequirement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrev", degreeRequirement.DegreeId);
            ViewData["RequirementId"] = new SelectList(_context.Requirements, "RequirementId", "RequirementAbbrev", degreeRequirement.RequirementId);
            return View(degreeRequirement);
        }

        // GET: DegreeRequirement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeRequirement = await _context.DegreeRequirements.FindAsync(id);
            if (degreeRequirement == null)
            {
                return NotFound();
            }
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrev", degreeRequirement.DegreeId);
            ViewData["RequirementId"] = new SelectList(_context.Requirements, "RequirementId", "RequirementAbbrev", degreeRequirement.RequirementId);
            return View(degreeRequirement);
        }

        // POST: DegreeRequirement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreeRequirementId,DegreeId,RequirementId")] DegreeRequirement degreeRequirement)
        {
            if (id != degreeRequirement.DegreeRequirementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreeRequirement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeRequirementExists(degreeRequirement.DegreeRequirementId))
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
            ViewData["DegreeId"] = new SelectList(_context.Degrees, "DegreeId", "DegreeAbrev", degreeRequirement.DegreeId);
            ViewData["RequirementId"] = new SelectList(_context.Requirements, "RequirementId", "RequirementAbbrev", degreeRequirement.RequirementId);
            return View(degreeRequirement);
        }

        // GET: DegreeRequirement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreeRequirement = await _context.DegreeRequirements
                .Include(d => d.Degree)
                .Include(d => d.Requirement)
                .FirstOrDefaultAsync(m => m.DegreeRequirementId == id);
            if (degreeRequirement == null)
            {
                return NotFound();
            }

            return View(degreeRequirement);
        }

        // POST: DegreeRequirement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreeRequirement = await _context.DegreeRequirements.FindAsync(id);
            _context.DegreeRequirements.Remove(degreeRequirement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeRequirementExists(int id)
        {
            return _context.DegreeRequirements.Any(e => e.DegreeRequirementId == id);
        }
    }
}
