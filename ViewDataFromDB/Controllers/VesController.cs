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
    public class VesController : Controller
    {
        private readonly ProductDbContext _context;

        public VesController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: Ves
        public async Task<IActionResult> Index()
        {
            var productDbContext = _context.ves.Include(v => v.SuKien);
            return View(await productDbContext.ToListAsync());
        }

        // GET: Ves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ve = await _context.ves
                .Include(v => v.SuKien)
                .FirstOrDefaultAsync(m => m.MaVe == id);
            if (ve == null)
            {
                return NotFound();
            }

            return View(ve);
        }

        // GET: Ves/Create
        public IActionResult Create()
        {
            ViewData["MaSuKien"] = new SelectList(_context.suKiens, "ID", "Ten");
            return View();
        }

        // POST: Ves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaVe,LoaiVe,GiaVe,MaSuKien")] Ve ve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ve);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index","Home");

            }
            ViewData["MaSuKien"] = new SelectList(_context.suKiens, "ID", "DiaDiem", ve.MaSuKien);
            return View(ve);

        }

        // GET: Ves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ve = await _context.ves.FindAsync(id);
            if (ve == null)
            {
                return NotFound();
            }
            ViewData["MaSuKien"] = new SelectList(_context.suKiens, "ID", "DiaDiem", ve.MaSuKien);
            return View(ve);
        }

        // POST: Ves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaVe,LoaiVe,GiaVe,MaSuKien")] Ve ve)
        {
            if (id != ve.MaVe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeExists(ve.MaVe))
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
            ViewData["MaSuKien"] = new SelectList(_context.suKiens, "ID", "DiaDiem", ve.MaSuKien);
            return View(ve);
        }

        // GET: Ves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ve = await _context.ves
                .Include(v => v.SuKien)
                .FirstOrDefaultAsync(m => m.MaVe == id);
            if (ve == null)
            {
                return NotFound();
            }

            return View(ve);
        }

        // POST: Ves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ve = await _context.ves.FindAsync(id);
            if (ve != null)
            {
                _context.ves.Remove(ve);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeExists(int id)
        {
            return _context.ves.Any(e => e.MaVe == id);
        }
    }
}
