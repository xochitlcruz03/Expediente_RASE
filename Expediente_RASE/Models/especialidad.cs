using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.Models
{
    /// <summary>
    /// Daniel Henrnandez 28-10-2021
    /// </summary>
    public class especialidad
    {
        [Key]
        public int Id_esp { get; set; }

        [Required]
        public string Nombre_esp { get; set; }
    }
}
