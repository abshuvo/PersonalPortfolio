using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigiPortfoli.Models;
using DigiPortfoli.Models.Entities;

namespace DigiPortfoli.Controllers
{
    public class ExperienceInfoesController : Controller
    {
        private readonly DBConfiguration _context;

        public ExperienceInfoesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: ExperienceInfoes
        public async Task<IActionResult> Index()
        {
              return _context.ExperienceInfo != null ? 
                          View(await _context.ExperienceInfo.ToListAsync()) :
                          Problem("Entity set 'DBConfiguration.ExperienceInfo'  is null.");
        }

        // GET: ExperienceInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExperienceInfo == null)
            {
                return NotFound();
            }

            var experienceInfo = await _context.ExperienceInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienceInfo == null)
            {
                return NotFound();
            }

            return View(experienceInfo);
        }

        // GET: ExperienceInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExperienceInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,StartDate,EndDate,Company,Department,Description")] ExperienceInfo experienceInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienceInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experienceInfo);
        }

        // GET: ExperienceInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExperienceInfo == null)
            {
                return NotFound();
            }

            var experienceInfo = await _context.ExperienceInfo.FindAsync(id);
            if (experienceInfo == null)
            {
                return NotFound();
            }
            return View(experienceInfo);
        }

        // POST: ExperienceInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,StartDate,EndDate,Company,Department,Description")] ExperienceInfo experienceInfo)
        {
            if (id != experienceInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienceInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceInfoExists(experienceInfo.Id))
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
            return View(experienceInfo);
        }

        // GET: ExperienceInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExperienceInfo == null)
            {
                return NotFound();
            }

            var experienceInfo = await _context.ExperienceInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienceInfo == null)
            {
                return NotFound();
            }

            return View(experienceInfo);
        }

        // POST: ExperienceInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExperienceInfo == null)
            {
                return Problem("Entity set 'DBConfiguration.ExperienceInfo'  is null.");
            }
            var experienceInfo = await _context.ExperienceInfo.FindAsync(id);
            if (experienceInfo != null)
            {
                _context.ExperienceInfo.Remove(experienceInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceInfoExists(int id)
        {
          return (_context.ExperienceInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
