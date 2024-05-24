using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAbBA3.DB_;
using LAbBA3.Models;

namespace LAbBA3.Controllers
{
    public class MoonsController : Controller
    {
        private readonly DB _context;

        public MoonsController(DB context)
        {
            _context = context;
        }

        // GET: Moons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moons.ToListAsync());
        }

        // GET: Moons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moon = await _context.Moons
                .FirstOrDefaultAsync(m => m.MoonId == id);
            if (moon == null)
            {
                return NotFound();
            }

            return View(moon);
        }

        // GET: Moons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoonId,Name,Size")] Moon moon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moon);
        }

        // GET: Moons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moon = await _context.Moons.FindAsync(id);
            if (moon == null)
            {
                return NotFound();
            }
            return View(moon);
        }

        // POST: Moons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MoonId,Name,Size")] Moon moon)
        {
            if (id != moon.MoonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoonExists(moon.MoonId))
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
            return View(moon);
        }

        // GET: Moons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moon = await _context.Moons
                .FirstOrDefaultAsync(m => m.MoonId == id);
            if (moon == null)
            {
                return NotFound();
            }

            return View(moon);
        }

        // POST: Moons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moon = await _context.Moons.FindAsync(id);
            if (moon != null)
            {
                _context.Moons.Remove(moon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoonExists(int id)
        {
            return _context.Moons.Any(e => e.MoonId == id);
        }
    }
}
