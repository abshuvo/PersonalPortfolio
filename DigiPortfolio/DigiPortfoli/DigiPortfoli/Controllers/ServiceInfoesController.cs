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
    public class ServiceInfoesController : Controller
    {
        private readonly DBConfiguration _context;

        public ServiceInfoesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: ServiceInfoes
        public async Task<IActionResult> Index()
        {
              return _context.ServiceInfo != null ? 
                          View(await _context.ServiceInfo.ToListAsync()) :
                          Problem("Entity set 'DBConfiguration.ServiceInfo'  is null.");
        }

        // GET: ServiceInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceInfo == null)
            {
                return NotFound();
            }

            var serviceInfo = await _context.ServiceInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceInfo == null)
            {
                return NotFound();
            }

            return View(serviceInfo);
        }

        // GET: ServiceInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,description,Icon")] ServiceInfo serviceInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceInfo);
        }

        // GET: ServiceInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceInfo == null)
            {
                return NotFound();
            }

            var serviceInfo = await _context.ServiceInfo.FindAsync(id);
            if (serviceInfo == null)
            {
                return NotFound();
            }
            return View(serviceInfo);
        }

        // POST: ServiceInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,description,Icon")] ServiceInfo serviceInfo)
        {
            if (id != serviceInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceInfoExists(serviceInfo.Id))
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
            return View(serviceInfo);
        }

        // GET: ServiceInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceInfo == null)
            {
                return NotFound();
            }

            var serviceInfo = await _context.ServiceInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceInfo == null)
            {
                return NotFound();
            }

            return View(serviceInfo);
        }

        // POST: ServiceInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceInfo == null)
            {
                return Problem("Entity set 'DBConfiguration.ServiceInfo'  is null.");
            }
            var serviceInfo = await _context.ServiceInfo.FindAsync(id);
            if (serviceInfo != null)
            {
                _context.ServiceInfo.Remove(serviceInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceInfoExists(int id)
        {
          return (_context.ServiceInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
