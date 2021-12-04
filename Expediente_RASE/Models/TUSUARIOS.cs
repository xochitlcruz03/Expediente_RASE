using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.Models
{
    //xochitl
    public class TUSUARIOS
    {
        [Required(ErrorMessage = "El campo USUARIO es requerido")]
        [Key]
        public int ID_USER { get; set; }

        [Required]
        public string CORREO_U { get; set; }

        [Required]
        public string CONTRA_U { get; set; }

        [Required]
        public string CARGO_U { get; set; }
    }
}
