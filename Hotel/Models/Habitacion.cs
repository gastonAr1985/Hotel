using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Habitacion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public bool Mantenimiento { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
