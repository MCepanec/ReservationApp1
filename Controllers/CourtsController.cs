using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReservationApp.Data;
using ReservationApp.Models;

namespace ReservationApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CourtsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courts.ToListAsync());
        }

        // GET: Courts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await _context.Courts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (court == null)
            {
                return NotFound();
            }

            return View(court);
        }

        // GET: Courts/Create
        public IActionResult Create()
        {
            ViewBag.Sports = new SelectList(Enum.GetValues(typeof(Sport)));
            return View();
        }

        // POST: Courts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,Sport,PricePerHour,IsAvailable")] Court court)
        {
            if (ModelState.IsValid)
            {
                _context.Add(court);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        
            return View(court);
        }

        // GET: Courts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await _context.Courts.FindAsync(id);
            if (court == null)
            {
                return NotFound();
            }
            return View(court);
        }

        // POST: Courts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location,Sport,PricePerHour,IsAvailable")] Court court)
        {
            if (id != court.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(court);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourtExists(court.Id))
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
            return View(court);
        }

        // GET: Courts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await _context.Courts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (court == null)
            {
                return NotFound();
            }

            return View(court);
        }

        // POST: Courts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var court = await _context.Courts.FindAsync(id);
            if (court != null)
            {
                _context.Courts.Remove(court);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourtExists(int id)
        {
            return _context.Courts.Any(e => e.Id == id);
        }
    }
}
