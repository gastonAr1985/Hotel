using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class HabitacionesController : Controller
    {
        private readonly HotelContext _context;

        public HabitacionesController(HotelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           ViewBag.Empleados = _context.Empleados.ToList();

            return View(_context.Habitaciones.ToList());
        }
        

        //GET
        public IActionResult Crear()
        {
            
            ViewBag.Empleados = _context.Empleados.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            }).ToList();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,Numero,Mantenimiento,Estado,IdEmpleado")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {

              _context.Add(habitacion);

               await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
           

            return View(habitacion);
        }









    }






}
