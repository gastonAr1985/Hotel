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

        public IActionResult Index()
        {
            ViewBag.Empleados = _context.Empleados.ToList();
            if (ViewBag.Empleados.Count == 0) { 
            
                return RedirectToAction("Error");
            }
            else
            {
                return View();
            }
        }


    
    public IActionResult Error()
    {
        return View();
    }

}
}
