using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Organigrama
    {
        [Key]
        public string Id { get; set; }
        public Empleado Empleados { get; set; }
    }
}
