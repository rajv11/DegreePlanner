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
    public class StudentTermController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentTermController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentTerm
        public async Task<IActionResult> Index(String sortOrder,String searchString)
        {
            ViewData["AbbrvSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Abbrv_desc" : "";
            ViewData["TermSortParm"] = sortOrder == "Term" ? "Term_desc" : "Term";
            ViewData["LabelSortParm"] = sortOrder == "Label" ? "Label_desc" : "Label";
            ViewData["StudentSortParm"] = sortOrder == "St" ? "St_desc" : "St";
            ViewData["CurrentFilter"] = searchString;

            var applicationDbContext = _context.StudentTerms.Include(s => s.Student).Include(s => s.DegreePlan);

            var stTerms = from st in applicationDbContext
                           select st;
            if (!String.IsNullOrEmpty(searchString))
            {
                stTerms = stTerms.Where(s => s.Student.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Abbrv_desc":
                    stTerms = stTerms.OrderByDescending(st => st.TermAbbrev);
                    break;
                case "Term_desc":
                    stTerms = stTerms.OrderByDescending(st => st.Term);
                    break;
                case "Term":
                    stTerms = stTerms.OrderBy(st => st.Term);
                    break;
                case "Label_desc":
                    stTerms = stTerms.OrderByDescending(st => st.TermLabel);
                    break;
                case "Label":
                    stTerms = stTerms.OrderBy(st => st.TermLabel);
                    break;
                case "St_desc":
                    stTerms = stTerms.OrderByDescending(st => st.Student);
                    break;
                case "St":
                    stTerms = stTerms.OrderBy(st => st.Student);
                    break;

                default:
                    stTerms = stTerms.OrderBy(st => st.TermAbbrev);
                    break;
            }
            return View(await stTerms.ToListAsync());
        }

        // GET: StudentTerm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTerm = await _context.StudentTerms
                .Include(s => s.DegreePlan)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentTermId == id);
            if (studentTerm == null)
            {
                return NotFound();
            }

            return View(studentTerm);
        }

        // GET: StudentTerm/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");
            return View();
        }

        // POST: StudentTerm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentTermId,DegreePlanId,StudentId,Term,TermAbbrev,TermLabel")] StudentTerm studentTerm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTerm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", studentTerm.DegreePlanId);

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", studentTerm.StudentId);
            return View(studentTerm);
        }

        // GET: StudentTerm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTerm = await _context.StudentTerms.FindAsync(id);
            if (studentTerm == null)
            {
                return NotFound();
            }
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", studentTerm.DegreePlanId);

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", studentTerm.StudentId);
            return View(studentTerm);
        }

        // POST: StudentTerm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentTermId,DegreePlanId,StudentId,Term,TermAbbrev,TermLabel")] StudentTerm studentTerm)
        {
            if (id != studentTerm.StudentTermId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTermExists(studentTerm.StudentTermId))
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
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", studentTerm.DegreePlanId);

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", studentTerm.StudentId);
            return View(studentTerm);
        }

        // GET: StudentTerm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTerm = await _context.StudentTerms
                .Include(s => s.DegreePlan)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentTermId == id);
            if (studentTerm == null)
            {
                return NotFound();
            }

            return View(studentTerm);
        }

        // POST: StudentTerm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentTerm = await _context.StudentTerms.FindAsync(id);
            _context.StudentTerms.Remove(studentTerm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTermExists(int id)
        {
            return _context.StudentTerms.Any(e => e.StudentTermId == id);
        }
    }
}
