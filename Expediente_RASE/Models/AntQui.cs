using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class AntQui
    {
        public int? IdPac { get; set; }
        public string RegQui { get; set; }
        public int? EdadQ { get; set; }
        public string TipoQ { get; set; }

        public virtual TPac IdPacNavigation { get; set; }
    }
}
