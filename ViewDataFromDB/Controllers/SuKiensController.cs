using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViewDataFromDB.Data;
using ViewDataFromDB.Models;

namespace ViewDataFromDB.Controllers
{
    public class SuKiensController : Controller
    {
        private readonly ProductDbContext _context;

        public SuKiensController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: SuKiens
        public async Task<IActionResult> Index()
        {
            return View(await _context.suKiens.ToListAsync());
        }

        // GET: SuKiens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suKien = await _context.suKiens
                .FirstOrDefaultAsync(m => m.ID == id);
            if (suKien == null)
            {
                return NotFound();
            }

            return View(suKien);
        }

        // GET: SuKiens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuKiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ten,NgayToChuc,DiaDiem")] SuKien suKien)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(suKien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View(suKien);
        }

        // GET: SuKiens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suKien = await _context.suKiens.FindAsync(id);
            if (suKien == null)
            {
                return NotFound();
            }
            return View(suKien);
        }

        // POST: SuKiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ten,NgayToChuc,DiaDiem")] SuKien suKien)
        {
            if (id != suKien.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suKien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuKienExists(suKien.ID))
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
            return View(suKien);
        }

        // GET: SuKiens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suKien = await _context.suKiens
                .FirstOrDefaultAsync(m => m.ID == id);
            if (suKien == null)
            {
                return NotFound();
            }

            return View(suKien);
        }

        // POST: SuKiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suKien = await _context.suKiens.FindAsync(id);
            if (suKien != null)
            {
                _context.suKiens.Remove(suKien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuKienExists(int id)
        {
            return _context.suKiens.Any(e => e.ID == id);
        }
    }
}
