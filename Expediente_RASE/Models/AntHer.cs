using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class AntHer
    {
        public int? IdPac { get; set; }
        public int? IdAnt { get; set; }
        public string RegHer { get; set; }
        public string AnHer { get; set; }

        public virtual CAnt IdAntNavigation { get; set; }
        public virtual TPac IdPacNavigation { get; set; }
    }
}
