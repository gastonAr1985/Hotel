﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class HotelContext : DbContext

    {

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Data Source = GASTON\SQLEXPRESS01;" + " Initial Catalog = HOTEL_ORT;" + " Integrated Security = true;");
        }


    }
}
