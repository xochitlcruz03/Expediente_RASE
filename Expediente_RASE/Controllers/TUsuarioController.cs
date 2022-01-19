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
using Microsoft.Extensions.Configuration;

namespace Expediente_RASE.Controllers
{
    [Route("api/Usuario")]
   // [Authorize]
    [ApiController]
    public class TUsuarioController : ControllerBase
    {
        //xochitl 
        //private readonly IConfiguration _configuration;
        private Models.RASE_DBContext oContext;
        private readonly string _connectionString;

        public TUsuarioController(Models.RASE_DBContext context, IConfiguration configuration) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(Models.TUsuario usuario)
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


        // PUT api/<pruebaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<pruebaController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.ELIIMINA_USUARIO", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return Ok();
                }
            }
        }

    }
}
