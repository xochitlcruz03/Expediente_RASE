using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class AntOb_POST
    {
        public int? IdPac { get; set; } //id del paciente
        public int? IdAnt { get; set; } //1027-1033 
        public string AnPsi { get; set; } //varvar descripcion
    }
}
