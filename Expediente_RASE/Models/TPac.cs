using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class TPac
    {
        public TPac()
        {
            TConsulta = new HashSet<TConsulta>();
        }
        public int IdPac { get; set; }
        public string NomPac { get; set; }
        public string ApPatPac { get; set; }
        public string ApMatPac { get; set; }
        public DateTime? FecNacPac { get; set; }
        public string SexoPac { get; set; }
        public string CurpPac { get; set; }
        public string TelPac { get; set; }
        public string CorreoPac { get; set; }
        public string TSangrePac { get; set; }
        public string EstCivPac { get; set; }
        public string OcupacionPac { get; set; }
        public string NotasPac { get; set; }
        public string ArchPac { get; set; }

        public virtual ICollection<TConsulta> TConsulta { get; set; }
    }
}
