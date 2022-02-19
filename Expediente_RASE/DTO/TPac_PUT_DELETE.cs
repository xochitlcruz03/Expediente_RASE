using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class TPac_PUT_DELETE
    {
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

    }
}
