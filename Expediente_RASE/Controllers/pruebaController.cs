using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expediente_RASE.Models;
//using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using System.Configuration;

namespace Expediente_RASE.Controllers
{
    [Route("api/User")]
   // [Authorize]
    [ApiController]
    public class pruebaController : ControllerBase
    {
        //xochitl 
        //private readonly IConfiguration _configuration;
        private Models.RASE_DBContext oContext;
        public pruebaController(Models.RASE_DBContext context) //Inyeccion de una dependencia
        {
            this.oContext = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post(TUsuario usuario)
        {
            var existeAutor = await oContext.TUsuarios.AnyAsync(a => a.CorreoU == usuario.CorreoU);

            if (existeAutor)
            {
                return BadRequest($"El correo {usuario.CorreoU} ya pertenece a un usuario");
            }
            else
            {
                this.oContext.Add(usuario);
                await this.oContext.SaveChangesAsync();
                return Ok();
            }
        }
       
        // GET: api/<pruebaController>
        [HttpGet]
        public async Task<ActionResult<List<TUsuario>>> Get()
        {
            return await oContext.TUsuarios.ToListAsync();
        }

        [HttpGet]
         public JsonResult Getsql()
         {
             string query = @"
                 select * from T_USUARIOS";
             DataTable table = new DataTable();
            string sqlDataSource = "Data Source=186.96.165.239;Initial Catalog=RASE_DB; User ID=sa;Password=Aurum2101; encrypt=true; trustServerCertificate=true";
        SqlDataReader myReader;
             using (SqlConnection myCon = new SqlConnection(sqlDataSource)){
                 myCon.Open();
                 using (SqlCommand myCommand = new SqlCommand (query, myCon))
                 {
                     myReader = myCommand.ExecuteReader();
                     table.Load(myReader); 
                     myReader.Close();
                     myCon.Close();
                 }
             }
             return new JsonResult(table);
         }


        // PUT api/<pruebaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<pruebaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
      
    }
}
