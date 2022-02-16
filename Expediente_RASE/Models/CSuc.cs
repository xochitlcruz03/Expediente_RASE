using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class CSuc
    {
        public CSuc()
        {
            TConsulta = new HashSet<TConsulta>();
        }

        public int IdSuc { get; set; }
        public string NomSuc { get; set; }
        public string DirSuc { get; set; }

        public virtual ICollection<TConsulta> TConsulta { get; set; }
    }
}
