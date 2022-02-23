using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.DTO
{
    public class AntQui_POST
    {
        public int? IdPac { get; set; }
        public string RegQui { get; set; } //cirugia si o no, un 0-1, 
        public int? EdadQ { get; set; } //edad
        public string TipoQ { get; set; } //tipo

    }
}
