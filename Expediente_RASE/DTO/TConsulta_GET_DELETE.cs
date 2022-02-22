using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class TConsulta_GET_DELETE
    {
        public int IdCon { get; set; } // id consulta
        public int? IdPac { get; set; } // id paciente
        public int? IdDoc { get; set; } // id doctor
        public int? IdSuc { get; set; } // Id sucursal
        public DateTime? FechaCon { get; set; } // fecha de consulta
        public double? Estatura { get; set; } // estatura
        public double? Peso { get; set; } // peso
        public double? MasaCorp { get; set; } // masa corporal
        public double? Temperatura { get; set; } // temperatura
        public int? FrecResp { get; set; } //frecuencia respiratoria
        public int? PresArt { get; set; } // presion arterial
        public int? FrecCar { get; set; } // frecuencia cardiaca
        public int? GrasaCorp { get; set; } //grasa corporal
        public int? MasaMusc { get; set; } //masa muscular
        public int? SatOxigeno { get; set; } //saturacion de oxigeno
        public string Motivo { get; set; }  // texto libre
        public string Diagnostico { get; set; } // texto libre
    }
}
