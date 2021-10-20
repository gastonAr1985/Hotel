using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Empleado
    {
       
        
            [Key]
            public int Id { get; set; }
            [Required]
            public String Password { get; set; }
            [Required]
            public string Nombre { get; set; }
            [Required]
            public string Apellido { get; set; }
            [Required]
            public double Sueldo { get; set; }
            [Required]
            public int AniosAntiguedad { get; set; }
            [Required]
            public List<Telefono> Telefonos { get; set; }
            [Required]
            public Turno TurnoEnum { get; set; }
            [Required]
            public Asistencia AsistenciaEnum { get; set; }
            [Required]
            public List<Habitacion> Habitaciones { get; set; }

        }
    }

