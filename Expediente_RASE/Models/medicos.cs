using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Daniel Henrnandez 28-10-2021
/// </summary>

namespace Expediente_RASE.Models
{
    public class medicos
    {
        public medicos() { }
        [Key]
        public int Id_doc { get; set; }

        [Required]
        public string Nombre_doc { get; set; }

        [Required]
        public string Curp_doc { get; set; }

        public especialidad especialidad { get; set; } 
        /**
         * de esta manera se mandan a llamar las llaves foraneas 
         * de otros modelos (los modelos vienen siendo como la estructura de las tablas en sql)
         * para poder enlazar una base de datos existente con el codigo, ya no será necesario de hacer
         * estos modelos.**/
        
        public string correo_doc { get; set; }

        [Required]
        public string Tel_doc { get; set; }
 
        public sucursal sucursal { get; set; }
        

        [Required]
        public string Cedula_p { get; set; }
    }
}
/***
 * esto es para importar una bd exixtente
 * In Visual Studio, select menu Tools -> NuGet Package Manger -> Package Manger Console and run the following command:

PM> Scaffold-DbContext "Server=.\SQLExpress;Database=SchoolDB;Trusted_Connection=True;" Mic......*/