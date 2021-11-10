using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class TratActivo
    {
        public int? IdPac { get; set; }
        public string TipoTrat { get; set; }
        public string Medic { get; set; }

        public virtual TPac IdPacNavigation { get; set; }
    }
}
