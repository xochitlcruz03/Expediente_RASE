using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class TInsMed
    {
        public int? IdCon { get; set; }
        public int? IdMed { get; set; }
        public string Indicaciones { get; set; }
        public string Frecuencia { get; set; }
        public string Duracion { get; set; }
        public string NotasIns { get; set; }

        public virtual TConsulta IdConNavigation { get; set; }
        public virtual TMedicina IdMedNavigation { get; set; }
    }
}
