using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Expediente_RASE.Models;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Expediente_RASE.DTO;
using Expediente_RASE.Utils;
using Microsoft.EntityFrameworkCore;

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
        private IMapper _mapper;
        private readonly string _connectionString;

        public TUsuarioController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }
        
        [HttpPost]
        public JsonResult Post(Models.TUsuario usuario)
        {
           /* string query = @"EXEC AGREGA_DOCTOR @NOM_DOC,@AP_PAT_DOC,@AP_MAT_DOC,@CURP_DOC,@REC_DIS,@ID_ESP,@CORREO_DOC,@TEL_DOC,@CED_P";

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@NOM_DOC", doctor.NomDoc);
                    myCommand.Parameters.AddWithValue("@AP_PAT_DOC", doctor.ApPatDoc);
                    myCommand.Parameters.AddWithValue("@AP_MAT_DOC", doctor.ApMatDoc);
                    myCommand.Parameters.AddWithValue("@CURP_DOC", doctor.CurpDoc);
                    myCommand.Parameters.AddWithValue("@REC_DIS", doctor.RecDis);
                    myCommand.Parameters.AddWithValue("@ID_ESP", doctor.IdEsp);
                    myCommand.Parameters.AddWithValue("@CORREO_DOC", doctor.CorreoDoc);
                    myCommand.Parameters.AddWithValue("@TEL_DOC", doctor.TelDoc);
                    myCommand.Parameters.AddWithValue("@CED_P", doctor.CedP);
                    myReader = myCommand.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");*/
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
                    cmd.Parameters.Add(new SqlParameter("@ID_USER", id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return Ok();
                }
            }
        }
        /*[HttpPost]
        [Route("login")]
        public IActionResult Login(TUsuario login)
        {
            var existeAutor = oContext.TUsuarios.AnyAsync(a => a.CorreoU == login.CorreoU);
            if (existeAutor)
            {
                this.oContext.Add(usuario);
                await this.oContext.SaveChangesAsync();
                return Ok();
                            }
            else
            {
                return BadRequest($"El correo {usuario.CorreoU} ya pertenece a un usuario");

            }
        }*/

    }
}
