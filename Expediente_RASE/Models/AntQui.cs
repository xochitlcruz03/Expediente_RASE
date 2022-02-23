﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class AntQui
    {
        public int? IdPac { get; set; }
        public string RegQui { get; set; } //cirugia
        public int? EdadQ { get; set; } //edad
        public string TipoQ { get; set; } //tipo

        public virtual TPac IdPacNavigation { get; set; }
    }
}
