using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                if (ValidarNumero(habitacion.Numero))
                {
                    _context.Add(habitacion);

                    await _context.SaveChangesAsync();

                   return RedirectToAction(nameof(Index));
                }
                
            }
            return RedirectToAction("ErrorDuplicado");

            // return View(habitacion);
        }

        public IActionResult InformarMantenimiento(int? id)
        {


            ViewBag.habitaciones = _context.Habitaciones.Select(x => new SelectListItem
            {
                Text = x.Numero.ToString(),
                Value = x.Id.ToString()
            }).ToList();

            var listaMant = new List<TipoMantenimiento>();

            foreach (TipoMantenimiento t in Enum.GetValues(typeof(TipoMantenimiento)))
            {
                listaMant.Add(t);
            }
            ViewData["tipos"] = listaMant;

            return View();
        }

        [HttpPost]
        public IActionResult InformarMantenimiento(int id, TipoMantenimiento tipoMantenimiento)
        {
            var hab = BuscarHabitacion(id);

            hab.TipoMantenimiento = tipoMantenimiento;
            hab.Mantenimiento = true;
            hab.Ocupacion = EstadoDeUsos.FUERA_DE_USO;
            hab.Estado = true;
            _context.Update(hab);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }




        private Habitacion BuscarHabitacion(int id)
        {
            Habitacion hab = _context.Habitaciones
                    .FirstOrDefault(m => m.Id == id);

            return hab;
        }
        private Habitacion BuscarHabitacionNumero(int Numero)
        {
            Habitacion hab = _context.Habitaciones
                    .FirstOrDefault(m => m.Numero == Numero);

            return hab;
        }


        public IActionResult DarMantenimiento(int id)
        {
            //busco la habitacion por el Id

            var hab = BuscarHabitacion(id);

            //Si necesita mantenimiento hago la reparacion
            if (hab.Mantenimiento == true)
            {

                hab.Mantenimiento = false;
                hab.TipoMantenimiento = 0;
                hab.Estado = false;
                hab.Ocupacion = EstadoDeUsos.LIBRE;

                _context.Update(hab);
                _context.SaveChanges();
            }
           return RedirectToAction("Index");
            
           
        }
        public IActionResult OcuparHabitacion(int id)
        {
            Habitacion h = BuscarHabitacion(id);

            if (h.Ocupacion == EstadoDeUsos.LIBRE && h.Ocupacion != EstadoDeUsos.FUERA_DE_USO)
            {
                h.Ocupacion = EstadoDeUsos.OCUPADA;
                _context.Update(h);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DesocuparHabitacion(int id)
        {
            Habitacion h = BuscarHabitacion(id);

            if (h.Ocupacion == EstadoDeUsos.OCUPADA && h.Ocupacion != EstadoDeUsos.FUERA_DE_USO)
            {
                h.Ocupacion = EstadoDeUsos.LIBRE;
                h.Entrada = DateTime.MinValue;
                h.Salida = DateTime.MinValue;
                _context.Update(h);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Alquilar() {

            List<Habitacion> habitaciones = _context.Habitaciones.ToList();
            List<Habitacion> habitacionesLibres = new List<Habitacion> ();

            foreach (var h in habitaciones) { 
             if(h.Ocupacion == EstadoDeUsos.LIBRE) {

                    habitacionesLibres.Add(h);

            }

            }
            ViewBag.HabitacionesLibres = habitacionesLibres;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Alquilar(int Numero,DateTime entrada,DateTime salida)
        {

            var hBuscada = BuscarHabitacionNumero(Numero);

            if (hBuscada != null) {

                if (validarAlquiler(hBuscada,salida))
                {
                    hBuscada.Entrada = entrada;
                    hBuscada.Salida = salida;

                    _context.Update(hBuscada);
                    _context.SaveChanges();
                }
               

            }

            confirmarIngreso(Numero,entrada);

            return RedirectToAction("Index");
        }


        public bool validarAlquiler(Habitacion h, DateTime fi)
        {
            bool sePuede = false;
            

            if (h != null)
            {
                if(h.Salida.Date.Month < fi.Date.Month)
                {
                    sePuede = true;
                }
            }


            return sePuede;
        }

        public void confirmarIngreso(int Numero, DateTime fi)
        {
            var h = BuscarHabitacionNumero(Numero);
            if (fi <= DateTime.Now)
            {
                h.Ocupacion = EstadoDeUsos.OCUPADA;
                _context.Update(h);
                _context.SaveChanges();
            }
        }

        public void confirmarSalida(int Numero, DateTime ff)
        {
            var h = BuscarHabitacionNumero(Numero);
            if (ff == DateTime.Now)
            {
                h.Ocupacion = EstadoDeUsos.LIBRE;
                h.Salida = default;
                h.Entrada = default;

                _context.Update(h);
                _context.SaveChanges();
            }
        }

        public IActionResult ListaHabitacionesPorEstado(int num)
        {
            List<Habitacion> h = _context.Habitaciones.ToList();

            List<Habitacion> mostrables = new List<Habitacion>();

            switch (num)
            {
                case 1:
                   
                    foreach (var hab in h)
                    {
                        if (hab.Ocupacion == EstadoDeUsos.LIBRE)
                        {
                            mostrables.Add(hab);
                        }
                       
                    }
                    
                    break;
                   

                case 2:

                    
                    foreach (var hab in h)
                    {
                        if (hab.Ocupacion == EstadoDeUsos.OCUPADA)
                        {
                            mostrables.Add(hab);
                        }

                    }
                    break;
                   
                case 3:

                    foreach (var hab in h)
                    {
                        if (hab.Ocupacion == EstadoDeUsos.FUERA_DE_USO)
                        {
                            mostrables.Add(hab);
                        }

                    }
                    break;
            }

            return View(mostrables);
        }


        public bool ValidarNumero(int numero)
        {
            bool esValido = true;
            List<Habitacion> hab = _context.Habitaciones.ToList();
           
            foreach(var h in hab){
                if (h.Numero == numero)
                {
                    esValido = false;
                }
            }

            return esValido;

        }

        public IActionResult ErrorDuplicado() {

            return View();
        
        }



    }






}
