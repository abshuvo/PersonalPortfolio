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
    public class SocialMediaInfoesController : Controller
    {
        private readonly DBConfiguration _context;

        public SocialMediaInfoesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: SocialMediaInfoes
        public async Task<IActionResult> Index()
        {
              return _context.SocialMediaInfo != null ? 
                          View(await _context.SocialMediaInfo.ToListAsync()) :
                          Problem("Entity set 'DBConfiguration.SocialMediaInfo'  is null.");
        }

        // GET: SocialMediaInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SocialMediaInfo == null)
            {
                return NotFound();
            }

            var socialMediaInfo = await _context.SocialMediaInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMediaInfo == null)
            {
                return NotFound();
            }

            return View(socialMediaInfo);
        }

        // GET: SocialMediaInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialMediaInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonalInfoId,SocialMediaName,SocialMediaURL")] SocialMediaInfo socialMediaInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialMediaInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialMediaInfo);
        }

        // GET: SocialMediaInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SocialMediaInfo == null)
            {
                return NotFound();
            }

            var socialMediaInfo = await _context.SocialMediaInfo.FindAsync(id);
            if (socialMediaInfo == null)
            {
                return NotFound();
            }
            return View(socialMediaInfo);
        }

        // POST: SocialMediaInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonalInfoId,SocialMediaName,SocialMediaURL")] SocialMediaInfo socialMediaInfo)
        {
            if (id != socialMediaInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialMediaInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediaInfoExists(socialMediaInfo.Id))
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
            return View(socialMediaInfo);
        }

        // GET: SocialMediaInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SocialMediaInfo == null)
            {
                return NotFound();
            }

            var socialMediaInfo = await _context.SocialMediaInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMediaInfo == null)
            {
                return NotFound();
            }

            return View(socialMediaInfo);
        }

        // POST: SocialMediaInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SocialMediaInfo == null)
            {
                return Problem("Entity set 'DBConfiguration.SocialMediaInfo'  is null.");
            }
            var socialMediaInfo = await _context.SocialMediaInfo.FindAsync(id);
            if (socialMediaInfo != null)
            {
                _context.SocialMediaInfo.Remove(socialMediaInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialMediaInfoExists(int id)
        {
          return (_context.SocialMediaInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
