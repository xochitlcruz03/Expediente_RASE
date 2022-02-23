using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class AntPat_POST
    {
        public int? IdPac { get; set; }
        public int? IdAnt { get; set; }
        public string RegPat { get; set; }
        public string AnPat { get; set; }
    }
}
