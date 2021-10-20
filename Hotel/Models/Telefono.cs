using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Telefono
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }

    }
}
