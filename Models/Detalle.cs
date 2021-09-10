using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgeDemo.Models
{
    public class Detalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Linea { get; set; }

        [Required]
        public int Id { get; set; }


        [Required]
        public string Producto { get; set; }

        [Required]
        public string Cantidad { get; set; }

        [Required]
        public string Monto { get; set; }

        [Required]
        public string Monto_total { get; set; }
    }
}
