using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class AntNoPat_POST
    {
        public int? IdPac { get; set; }
        public int? IdAnt { get; set; }
        public string RegNPat { get; set; }
        public string AnNPat { get; set; }
    }
}
