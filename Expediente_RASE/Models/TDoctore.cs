using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class TDoctore
    {
        public TDoctore()
        {
            TConsulta = new HashSet<TConsultum>();
        }

        public int IdDoc { get; set; }
        public string NomDoc { get; set; }
        public string ApPatDoc { get; set; }
        public string ApMatDoc { get; set; }
        public string CurpDoc { get; set; }
        public int? RecDis { get; set; }
        public int? IdEsp { get; set; }
        public string CorreoDoc { get; set; }
        public string TelDoc { get; set; }
        public string CedP { get; set; }

        public virtual CEsp IdEspNavigation { get; set; }
        public virtual ICollection<TConsultum> TConsulta { get; set; }
    }
}
