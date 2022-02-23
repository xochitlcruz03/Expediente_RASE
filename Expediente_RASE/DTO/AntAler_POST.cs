using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class AntAler_POST
    {
        public int? IdPac { get; set; }
        public string RegAler { get; set; } //alergias, 0 o 1, si o no, es tipo char(1)
        public string DescAler { get; set; } //descripcion

    }
}
