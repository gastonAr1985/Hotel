using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Asistencia
    {
        [Key]
        public int AsistenciaId { get; set; }

        //Navegacional
        public Empleado Empleado { get; set; }

        public int EmpleadoId { get; set; }

        public AsistenciaEnum Estado { get; set; }

        public DateTime Dia { get; set; }

        

        
    }
}