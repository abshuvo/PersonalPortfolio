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
    public class PortfolioInfoesController : Controller
    {
        private readonly DBConfiguration _context;

        public PortfolioInfoesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: PortfolioInfoes
        public async Task<IActionResult> Index()
        {
              return _context.PortfolioInfo != null ? 
                          View(await _context.PortfolioInfo.ToListAsync()) :
                          Problem("Entity set 'DBConfiguration.PortfolioInfo'  is null.");
        }

        // GET: PortfolioInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PortfolioInfo == null)
            {
                return NotFound();
            }

            var portfolioInfo = await _context.PortfolioInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioInfo == null)
            {
                return NotFound();
            }

            return View(portfolioInfo);
        }

        // GET: PortfolioInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfolioInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] PortfolioInfo portfolioInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portfolioInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portfolioInfo);
        }

        // GET: PortfolioInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PortfolioInfo == null)
            {
                return NotFound();
            }

            var portfolioInfo = await _context.PortfolioInfo.FindAsync(id);
            if (portfolioInfo == null)
            {
                return NotFound();
            }
            return View(portfolioInfo);
        }

        // POST: PortfolioInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] PortfolioInfo portfolioInfo)
        {
            if (id != portfolioInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolioInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioInfoExists(portfolioInfo.Id))
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
            return View(portfolioInfo);
        }

        // GET: PortfolioInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PortfolioInfo == null)
            {
                return NotFound();
            }

            var portfolioInfo = await _context.PortfolioInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioInfo == null)
            {
                return NotFound();
            }

            return View(portfolioInfo);
        }

        // POST: PortfolioInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PortfolioInfo == null)
            {
                return Problem("Entity set 'DBConfiguration.PortfolioInfo'  is null.");
            }
            var portfolioInfo = await _context.PortfolioInfo.FindAsync(id);
            if (portfolioInfo != null)
            {
                _context.PortfolioInfo.Remove(portfolioInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioInfoExists(int id)
        {
          return (_context.PortfolioInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
