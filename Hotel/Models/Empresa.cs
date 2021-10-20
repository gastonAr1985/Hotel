using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Empleado> Empleados { get; set; }
        public List<Habitacion> Habitaciones { get; set; }
        public List<Telefono> Telefonos { get; set; }

    }
}
