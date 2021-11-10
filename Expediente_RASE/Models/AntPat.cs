using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class AntPat
    {
        public int? IdPac { get; set; }
        public int? IdAnt { get; set; }
        public string RegPat { get; set; }
        public string AnPat { get; set; }

        public virtual CAnt IdAntNavigation { get; set; }
        public virtual TPac IdPacNavigation { get; set; }
    }
}
