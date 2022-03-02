using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class TInsMed_POST
    {
        public int? IdPac { get; set; }
        public int? IdCon { get; set; } // id de Tconsulta
        public int? IdMed { get; set; }// pantoprasol - 2045
        public string Indicaciones { get; set; } // 1 tableta
        public string Frecuencia { get; set; } //cada 8 horas
        public string Duracion { get; set; } //7
        public string NotasIns { get; set; }  //presentarse a nueva cita medica en 2 semanas
    }
}
