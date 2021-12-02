using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expediente_RASE.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expediente_RASE.Controllers
{
    [Route("api/User")]
    [Authorize]
    [ApiController]
    public class pruebaController : ControllerBase
    {
        //xochitl 
        private readonly IConfiguration _configuration;
        private ApplicationDbContext oContext;
        public pruebaController(ApplicationDbContext context, IConfiguration configuration) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _configuration = configuration;
        }
       /* [HttpPost]
        public async Task<ActionResult> Post(T_USUARIOS t_USUARIOS )
        {
            var existeAutor = await oContext.T_USUARIOS.AnyAsync(a => a.CORREO_U == t_USUARIOS.CORREO_U);

            if (existeAutor)
            {
                return BadRequest($"El nombre del autor {t_USUARIOS.CORREO_U} ya existe");
            }
            else
            {
                this.oContext.Add(t_USUARIOS);
                await this.oContext.SaveChangesAsync();
                return Ok();
            }
        }
       */
        // GET: api/<pruebaController>
        [HttpGet]
        public async Task<ActionResult<List<T_USUARIOS>>> Get()
        {
            return await oContext.T_USUARIOS.ToListAsync();
        }

        /* [HttpGet]
         public JsonResult Get()
         {
             string query = @"
                 select * from T_USUARIOS";
             DataTable table = new DataTable();
             string sqlDataSource = _configuration.GetConnectionString("Sucursal1");
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
         }*/


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
