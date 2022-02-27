using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class TratAct_POST
    {
        public int? IdPac { get; set; }
        public string TipoTrat { get; set; }
        public string Medic { get; set; }
    }
}
