using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class AntPsi_POST
    {
        public int? IdPac { get; set; }
        public int? IdAnt { get; set; }
        public string RegPsi { get; set; }
        public string AnPsi { get; set; }

    }
}
