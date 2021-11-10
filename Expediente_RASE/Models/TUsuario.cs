using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class TUsuario
    {
        public int IdUser { get; set; }
        public string CorreoU { get; set; }
        public string ContraU { get; set; }
        public string CargoU { get; set; }
    }
}
