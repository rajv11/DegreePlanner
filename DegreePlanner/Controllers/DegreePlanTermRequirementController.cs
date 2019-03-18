﻿using System;
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
    public class DegreePlanTermRequirementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreePlanTermRequirementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DegreePlanTermRequirement
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DegreePlanTermRequirements.Include(d => d.DegreePlan).Include(d => d.Requirement);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DegreePlanTermRequirement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlanTermRequirement = await _context.DegreePlanTermRequirements
                .Include(d => d.DegreePlan)
                .Include(d => d.Requirement)
                .FirstOrDefaultAsync(m => m.DegreePlanTermRequirementId == id);
            if (degreePlanTermRequirement == null)
            {
                return NotFound();
            }

            return View(degreePlanTermRequirement);
        }

        // GET: DegreePlanTermRequirement/Create
        public IActionResult Create()
        {
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev");
            ViewData["RequirementId"] = new SelectList(_context.Requirements, "RequirementId", "RequirementAbbrev");
            return View();
        }

        // POST: DegreePlanTermRequirement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreePlanTermRequirementId,DegreePlanId,TermId,RequirementId")] DegreePlanTermRequirement degreePlanTermRequirement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degreePlanTermRequirement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", degreePlanTermRequirement.DegreePlanId);
            ViewData["RequirementId"] = new SelectList(_context.Requirements, "RequirementId", "RequirementAbbrev", degreePlanTermRequirement.RequirementId);
            return View(degreePlanTermRequirement);
        }

        // GET: DegreePlanTermRequirement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlanTermRequirement = await _context.DegreePlanTermRequirements.FindAsync(id);
            if (degreePlanTermRequirement == null)
            {
                return NotFound();
            }
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", degreePlanTermRequirement.DegreePlanId);
            ViewData["RequirementId"] = new SelectList(_context.Requirements, "RequirementId", "RequirementAbbrev", degreePlanTermRequirement.RequirementId);
            return View(degreePlanTermRequirement);
        }

        // POST: DegreePlanTermRequirement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreePlanTermRequirementId,DegreePlanId,TermId,RequirementId")] DegreePlanTermRequirement degreePlanTermRequirement)
        {
            if (id != degreePlanTermRequirement.DegreePlanTermRequirementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degreePlanTermRequirement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreePlanTermRequirementExists(degreePlanTermRequirement.DegreePlanTermRequirementId))
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
            ViewData["DegreePlanId"] = new SelectList(_context.DegreePlans, "DegreePlanId", "DegreePlanAbbrev", degreePlanTermRequirement.DegreePlanId);
            ViewData["RequirementId"] = new SelectList(_context.Requirements, "RequirementId", "RequirementAbbrev", degreePlanTermRequirement.RequirementId);
            return View(degreePlanTermRequirement);
        }

        // GET: DegreePlanTermRequirement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degreePlanTermRequirement = await _context.DegreePlanTermRequirements
                .Include(d => d.DegreePlan)
                .Include(d => d.Requirement)
                .FirstOrDefaultAsync(m => m.DegreePlanTermRequirementId == id);
            if (degreePlanTermRequirement == null)
            {
                return NotFound();
            }

            return View(degreePlanTermRequirement);
        }

        // POST: DegreePlanTermRequirement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degreePlanTermRequirement = await _context.DegreePlanTermRequirements.FindAsync(id);
            _context.DegreePlanTermRequirements.Remove(degreePlanTermRequirement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreePlanTermRequirementExists(int id)
        {
            return _context.DegreePlanTermRequirements.Any(e => e.DegreePlanTermRequirementId == id);
        }
    }
}