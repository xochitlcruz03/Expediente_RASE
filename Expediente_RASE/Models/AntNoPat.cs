using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class AntNoPat
    {
        public int? IdPac { get; set; }
        public int? IdAnt { get; set; }
        public string RegNPat { get; set; }
        public string AnNPat { get; set; }

        public virtual CAnt IdAntNavigation { get; set; }
        public virtual TPac IdPacNavigation { get; set; }
    }
}
