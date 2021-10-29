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
    public class sucursal
    {
        [Key]
        public int Id_sucursal { get; set; }
        
        [Required]
        public string Nom_suc { get; set; }
        
        [Required]
        public string dir_duc { get; set; }

    }
}
