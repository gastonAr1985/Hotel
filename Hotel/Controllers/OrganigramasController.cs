using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class OrganigramasController : Controller
    {
        private readonly HotelContext _context;

        public OrganigramasController(HotelContext context)
        {
            _context = context;
        }

        // GET: Organigramas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organigrama.ToListAsync());
        }

        // GET: Organigramas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organigrama = await _context.Organigrama
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organigrama == null)
            {
                return NotFound();
            }

            return View(organigrama);
        }

        // GET: Organigramas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organigramas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Organigrama organigrama)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organigrama);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organigrama);
        }

        // GET: Organigramas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organigrama = await _context.Organigrama.FindAsync(id);
            if (organigrama == null)
            {
                return NotFound();
            }
            return View(organigrama);
        }

        // POST: Organigramas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id")] Organigrama organigrama)
        {
            if (id != organigrama.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organigrama);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganigramaExists(organigrama.Id))
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
            return View(organigrama);
        }

        // GET: Organigramas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organigrama = await _context.Organigrama
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organigrama == null)
            {
                return NotFound();
            }

            return View(organigrama);
        }

        // POST: Organigramas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var organigrama = await _context.Organigrama.FindAsync(id);
            _context.Organigrama.Remove(organigrama);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganigramaExists(string id)
        {
            return _context.Organigrama.Any(e => e.Id == id);
        }
    }
}
