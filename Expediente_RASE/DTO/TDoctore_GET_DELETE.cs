using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class TDoctore_GET_DELETE
    {
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
    }
}
