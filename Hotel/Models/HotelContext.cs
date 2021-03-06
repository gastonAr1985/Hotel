using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.Models
{
    public class HotelContext : DbContext

    {

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }

        public HotelContext(DbContextOptions<HotelContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
           // option.UseSqlServer(@"Data Source =  MICA\SQLEXPRESS;" + " Initial Catalog = HOTEL_ORT;" + " Integrated Security = true;");
        }
        public DbSet<Hotel.Models.Organigrama> Organigrama { get; set; }


    }
}
