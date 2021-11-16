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
    public class EmpleadoesController : Controller
    {
        const double ADICIONAL_MANTENIMIENTO = 500;
        const double ADICIONAL_LIMPIEZA = 0;
        const double ADICIONAL_JEFE = 5000;
        const double ADICIONAL_ADMINISTRADOR = 2000;
        const double ADICIONAL_RECEPCIONISTA = 700;
        

        private readonly HotelContext _context;

        public EmpleadoesController(HotelContext context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {

            return View(await _context.Empleados.ToListAsync());
        }
        public async Task<IActionResult> Seleccion(int id)
        {
            var empleado = await _context.Empleados
               .FirstOrDefaultAsync(m => m.Id == id);


            if (empleado == null)
            {
                return NotFound();
            }

           

            ViewData["telefonos"] = ListaDeTelefonos(id);
            ViewBag.sueldo = CalcularSueldo(id);
            ViewBag.antiguedad = CalcularAntiguedad(id);

            return View(empleado);
        }
        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            //ViewData["Antiguedad"] = CalcularAntiguedad(empleado);



            return View(empleado);
        }

        // GET: Empleadoes/Create
        public  ActionResult Create()
        {
            var turnos = new List<TurnoEnum>();

            foreach (TurnoEnum t in Enum.GetValues(typeof(TurnoEnum)))
            {
                turnos.Add(t);
            }
            ViewData["tr"] = turnos;

            var cargos = new List<CargoEnum>();
            foreach (CargoEnum c in Enum.GetValues(typeof(CargoEnum)))
            {
                cargos.Add(c);
            }
            ViewData["car"] = cargos;




            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Password,Nombre,Apellido,Sueldo,FechaIngreso,TurnoEnum,Cargo")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {

                //var Telefonito = new Telefono(); 
                //_context.Telefonos.Add()

                _context.Add(empleado);
                
               
                await _context.SaveChangesAsync();

                return RedirectToAction("Create","Telefonos");
            }
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var turnos = new List<TurnoEnum>();

            foreach (TurnoEnum t in Enum.GetValues(typeof(TurnoEnum)))
            {
                turnos.Add(t);
            }
            ViewData["tr"] = turnos;

            var cargos = new List<CargoEnum>();
            foreach (CargoEnum c in Enum.GetValues(typeof(CargoEnum)))
            {
                cargos.Add(c);
            }
            ViewData["car"] = cargos;

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Password,Nombre,Apellido,Sueldo,FechaIngreso,TurnoEnum,Cargo")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
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
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tel = from e in _context.Telefonos
                      select e;

            // Buscamos el el telefono correspondiente al empleado id , recorremos sus telefonos los borramos y guardamos.
            tel = tel.Where(s => s.EmpleadoId == id);
            foreach (var t in tel)
            {
                _context.Telefonos.Remove(t);
               
            }
            await _context.SaveChangesAsync();

            /////////////////////////////////////////////////////////////
           
            var empleado = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
        public int CalcularAntiguedad(int? id) {
            
            if (id == null)
            {
                return 0;
            }

            var empleado =  _context.Empleados
                .FirstOrDefault(m => m.Id == id);
            if (empleado == null)
            {
                return 0;
            }

            int edadCalculada = DateTime.Now.Year - empleado.FechaIngreso.Year;

            
            return edadCalculada;
        }

        public double CalcularSueldo(int id) {
            
            double sueldoTotal = 0;
            var empleado =  _context.Empleados
                .FirstOrDefault(m => m.Id == id);

            switch (empleado.Cargo) {
                case CargoEnum.JEFE: sueldoTotal = empleado.Sueldo + ADICIONAL_JEFE;
                    break;
                case CargoEnum.ADMINISTRACION:
                    sueldoTotal = empleado.Sueldo + ADICIONAL_ADMINISTRADOR;
                    break;
                case CargoEnum.MANTENIMIENTO:
                    sueldoTotal = empleado.Sueldo + ADICIONAL_MANTENIMIENTO;
                    break;
                case CargoEnum.RECEPCIONISTA:
                    sueldoTotal = empleado.Sueldo + ADICIONAL_RECEPCIONISTA;
                    break;
                case CargoEnum.LIMPIEZA:
                    sueldoTotal = empleado.Sueldo + ADICIONAL_LIMPIEZA;
                    break;


            }
            return sueldoTotal;
        }
        
        public List<Telefono> ListaDeTelefonos(int id)
        {
            var tel = from e in _context.Telefonos
                      select e;


            tel = tel.Where(s => s.EmpleadoId == id);

            return (tel.ToList());
        }

        public IActionResult buscarEmpleado(string NombreEmpleado)
        {

            // Aca me traigo el empleado para poder filtrarlo en la busqueda

           

            Empleado emp = null;

            if (!String.IsNullOrEmpty(NombreEmpleado))
            {
                emp = _context.Empleados.FirstOrDefault(e => e.Nombre == NombreEmpleado);
                
            }
            else
            {
                emp = null;
            }
            ViewData["emp"] = emp;
            return View(emp);
        }

        public Empleado BuscarEmpleado(int id) {

            Empleado emp = null;
            if (id != 0)
            {
                emp = _context.Empleados.Find(id);
            }

            return emp;
        }


        public IActionResult ContadorAsistencias(int id)
        {
            ViewBag.Empleados = _context.Empleados.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            }).ToList();



            var listaAsistencia = _context.Asistencia.ToList();
            var Presente = 0;
            var Tarde = 0;
            var Ausente = 0;

            foreach (Asistencia a in listaAsistencia)
            {
                if (a.EmpleadoId == id && a.Estado == AsistenciaEnum.PRESENTE)
                {
                    Presente++;
                }
                else if (a.EmpleadoId == id && a.Estado == AsistenciaEnum.TARDE)
                {
                    Tarde++;
                }
                else if (a.EmpleadoId == id && a.Estado == AsistenciaEnum.AUSENTE)
                {
                    Ausente++;
                }
            }
            Empleado emp = BuscarEmpleado(id);
            ViewBag.Presente = Presente;
            ViewBag.Tarde = Tarde;
            ViewBag.Ausente = Ausente;


            return View(emp);
        }
    





}
}
