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
    public class AsistenciasController : Controller
    {
        private readonly HotelContext _context;

        public AsistenciasController(HotelContext context)
        {
            _context = context;
        }

        // GET: Asistencias
        public async Task<IActionResult> Index(String nombre)
        {
            var emp = from e in _context.Asistencia
                         select e;

            if(!String.IsNullOrEmpty(nombre))
            {
                emp = emp.Where(s => s.Empleado.Nombre!.Contains(nombre));
            }

            ViewBag.Empleados = _context.Empleados.ToList();

            return View(await emp.ToListAsync());
        }

        // GET: Asistencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencia
                .FirstOrDefaultAsync(m => m.AsistenciaId == id);
            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        // GET: Asistencias/Create
        public IActionResult Create()
        {
            var asistencia = new List<AsistenciaEnum>();

            foreach (AsistenciaEnum a in Enum.GetValues(typeof(AsistenciaEnum)))
            {
                asistencia.Add(a);
            }
            ViewData["as"] = asistencia;

            ViewBag.Empleados = _context.Empleados.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            }).ToList();

            return View();
        }

        // POST: Asistencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsistenciaId,Dia,Estado,EmpleadoId")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asistencia);
        }

        // GET: Asistencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            

            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencia.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }
            ViewBag.Empleaditos= _context.Empleados.ToList();
            ViewData["ListaEnums"] = ObtenerEnums();

            return View(asistencia);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("AsistenciaId,Dia,Estado,EmpleadoId")] Asistencia asistencia)
        {
            if (id != asistencia.AsistenciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(asistencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciaExists(asistencia.AsistenciaId))
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
            return View(asistencia);
        }

        // GET: Asistencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencia
                .FirstOrDefaultAsync(m => m.AsistenciaId == id);
            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistencia = await _context.Asistencia.FindAsync(id);
            _context.Asistencia.Remove(asistencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciaExists(int id)
        {
            return _context.Asistencia.Any(e => e.AsistenciaId == id);
        }
        public async Task<IActionResult> Contador()
        {

            ViewBag.Empleados = await _context.Empleados.ToListAsync();
            ViewBag.Asistencias = await _context.Asistencia.ToListAsync();

            return View();
        }

        public List<AsistenciaEnum> ObtenerEnums() {

            var Asistencia = new List<AsistenciaEnum>();

            foreach (AsistenciaEnum a in Enum.GetValues(typeof(AsistenciaEnum)))
            {

                Asistencia.Add(a);
            }
            return Asistencia;
        }

    }
}
