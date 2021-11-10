using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class TConsultum
    {
        public int IdCon { get; set; }
        public int? IdPac { get; set; }
        public int? IdDoc { get; set; }
        public int? IdSuc { get; set; }
        public DateTime? FechaCon { get; set; }
        public double? Estatura { get; set; }
        public double? Peso { get; set; }
        public double? MasaCorp { get; set; }
        public double? Temperatura { get; set; }
        public int? FrecResp { get; set; }
        public int? PresArt { get; set; }
        public int? FrecCar { get; set; }
        public int? GrasaCorp { get; set; }
        public int? MasaMusc { get; set; }
        public int? SatOxigeno { get; set; }
        public string Motivo { get; set; }
        public string Diagnostico { get; set; }

        public virtual TDoctore IdDocNavigation { get; set; }
        public virtual TPac IdPacNavigation { get; set; }
        public virtual CSuc IdSucNavigation { get; set; }
    }
}
