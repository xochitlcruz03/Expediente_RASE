using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class AntPsi
    {
        public int? IdPac { get; set; }
        public int? IdAnt { get; set; }
        public string RegPsi { get; set; }
        public string AnPsi { get; set; }

        public virtual CAnt IdAntNavigation { get; set; }
        public virtual TPac IdPacNavigation { get; set; }
    }
}
