using System;
using System.Collections.Generic;

#nullable disable

namespace Expediente_RASE.Models
{
    public partial class CEsp
    {
        public CEsp()
        {
            TDoctores = new HashSet<TDoctore>();
        }

        public int IdEsp { get; set; }
        public string NEsp { get; set; }

        public virtual ICollection<TDoctore> TDoctores { get; set; }
    }
}
