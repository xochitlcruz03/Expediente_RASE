using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class AntAler
    {
        public int? IdPac { get; set; }
        public string RegAler { get; set; } //alergias
        public string DescAler { get; set; } //descripcion

        public virtual TPac IdPacNavigation { get; set; }
    }
}
