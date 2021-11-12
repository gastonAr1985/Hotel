using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Habitacion
    {
        [Key]
        public int Id { get; set; }

        //NAVEGACIONAL
        public int IdEmpleado { get; set; }
        public  Empleado EmpleadoAcargo { get; set; }


        [Required]
        public int Numero { get; set; }
        
        public bool Mantenimiento { get; set; }

        public TipoMantenimiento TipoMantenimiento { get; set; }

       
        public bool Estado { get; set; }
        
        
    }
}
