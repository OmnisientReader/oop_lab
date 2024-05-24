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
    public class BufferZonesController : Controller
    {
        private readonly DB _context;

        public BufferZonesController(DB context)
        {
            _context = context;
        }

        // GET: BufferZones
        public async Task<IActionResult> Index()
        {
            var dB = _context.Buffer.Include(b => b.Moon).Include(b => b.Planet);
            return View(await dB.ToListAsync());
        }

        // GET: BufferZones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bufferZone = await _context.Buffer
                .Include(b => b.Moon)
                .Include(b => b.Planet)
                .FirstOrDefaultAsync(m => m.PlanetId == id);
            if (bufferZone == null)
            {
                return NotFound();
            }

            return View(bufferZone);
        }

        // GET: BufferZones/Create
        public IActionResult Create()
        {
            ViewData["MoonId"] = new SelectList(_context.Moons, "MoonId", "MoonId");
            ViewData["PlanetId"] = new SelectList(_context.Planets, "PlanetId", "PlanetId");
            return View();
        }

        // POST: BufferZones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanetId,MoonId")] BufferZone bufferZone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bufferZone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MoonId"] = new SelectList(_context.Moons, "MoonId", "MoonId", bufferZone.MoonId);
            ViewData["PlanetId"] = new SelectList(_context.Planets, "PlanetId", "PlanetId", bufferZone.PlanetId);
            return View(bufferZone);
        }

        // GET: BufferZones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bufferZone = await _context.Buffer.FindAsync(id);
            if (bufferZone == null)
            {
                return NotFound();
            }
            ViewData["MoonId"] = new SelectList(_context.Moons, "MoonId", "MoonId", bufferZone.MoonId);
            ViewData["PlanetId"] = new SelectList(_context.Planets, "PlanetId", "PlanetId", bufferZone.PlanetId);
            return View(bufferZone);
        }

        // POST: BufferZones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanetId,MoonId")] BufferZone bufferZone)
        {
            if (id != bufferZone.PlanetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bufferZone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BufferZoneExists(bufferZone.PlanetId))
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
            ViewData["MoonId"] = new SelectList(_context.Moons, "MoonId", "MoonId", bufferZone.MoonId);
            ViewData["PlanetId"] = new SelectList(_context.Planets, "PlanetId", "PlanetId", bufferZone.PlanetId);
            return View(bufferZone);
        }

        // GET: BufferZones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bufferZone = await _context.Buffer
                .Include(b => b.Moon)
                .Include(b => b.Planet)
                .FirstOrDefaultAsync(m => m.PlanetId == id);
            if (bufferZone == null)
            {
                return NotFound();
            }

            return View(bufferZone);
        }

        // POST: BufferZones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bufferZone = await _context.Buffer.FindAsync(id);
            if (bufferZone != null)
            {
                _context.Buffer.Remove(bufferZone);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BufferZoneExists(int id)
        {
            return _context.Buffer.Any(e => e.PlanetId == id);
        }
    }
}
