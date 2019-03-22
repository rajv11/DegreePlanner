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
    public class RequirementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequirementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Requirement
        public async Task<IActionResult> Index(String sortOrder, String searchString)
        {
            ViewData["AbbrSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Abbr_desc" : "";
            ViewData["ReqSortParm"] = sortOrder == "Req" ? "Req_desc" : "Req";
            ViewData["CurrentFilter"] = searchString;

            var requirements = from r in _context.Requirements
                          select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                requirements = requirements.Where(r => r.RequirementName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Abbrv_desc":
                    requirements = requirements.OrderByDescending(r => r.RequirementAbbrev);
                    break;
                case "Req_desc":
                    requirements = requirements.OrderByDescending(r => r.RequirementName);
                    break;
                case "req":
                    requirements = requirements.OrderBy(r => r.RequirementName);
                    break;
                default:
                    requirements = requirements.OrderBy(r => r.RequirementAbbrev);
                    break;
            }
            return View(await requirements.ToListAsync());
        }

        // GET: Requirement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirement = await _context.Requirements
                .FirstOrDefaultAsync(m => m.RequirementId == id);
            if (requirement == null)
            {
                return NotFound();
            }

            return View(requirement);
        }

        // GET: Requirement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requirement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequirementId,RequirementAbbrev,RequirementName")] Requirement requirement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requirement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requirement);
        }

        // GET: Requirement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirement = await _context.Requirements.FindAsync(id);
            if (requirement == null)
            {
                return NotFound();
            }
            return View(requirement);
        }

        // POST: Requirement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequirementId,RequirementAbbrev,RequirementName")] Requirement requirement)
        {
            if (id != requirement.RequirementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requirement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequirementExists(requirement.RequirementId))
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
            return View(requirement);
        }

        // GET: Requirement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirement = await _context.Requirements
                .FirstOrDefaultAsync(m => m.RequirementId == id);
            if (requirement == null)
            {
                return NotFound();
            }

            return View(requirement);
        }

        // POST: Requirement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requirement = await _context.Requirements.FindAsync(id);
            _context.Requirements.Remove(requirement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequirementExists(int id)
        {
            return _context.Requirements.Any(e => e.RequirementId == id);
        }
    }
}
