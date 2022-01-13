using Expediente_RASE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE
{
    //Xochitl Cruz
    public class noplisnoApplicationDbContext : DbContext
    {
        public noplisnoApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TUsuario> TUSUARIO1 { get; set; }
    }
}
