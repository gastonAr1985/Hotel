using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Empleado
    {
       
        
        [Key]
        public int Id { get; set; }
        //Navegacional
        public List<Asistencia> ListaAsistencia { get; set; }

        public List<Habitacion> Habitaciones { get; set; }
        public  List<Telefono> Telefonos { get; set; }



        [Display(Name = "Turno")]
        public TurnoEnum TurnoEnum { get; set; }

        [Display(Name = "Cargo")]
        public CargoEnum Cargo { get; set; }


            [Required]
            public string Nombre { get; set; }
            [Required]
            public string Apellido { get; set; }
            [Required]
             [Display(Name = "Sueldo Base")]
            public double Sueldo { get; set; }

            [Required]
            [Display(Name = "Fecha de Ingreso")]
            public DateTime FechaIngreso { get; set; }
        
       

          
        
            public int Antiguedad { get; set; }
           

        }
    }

