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
        public JsonResult Post(TUsuario usuario)
        {
            string query = @"EXEC AGREGA_USUARIO @CORREO_U,@CONTRA_U,@CARGO_U";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@CORREO_U", usuario.CorreoU);
                    cmd.Parameters.AddWithValue("@CONTRA_U", usuario.ContraU);
                    cmd.Parameters.AddWithValue("@CARGO_U", usuario.CargoU);
                    myReader = cmd.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        
       
        // GET: api/<pruebaController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"EXEC CONSULTA_USUARIOS";
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); 

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }


        // DELETE api/<pruebaController>/5
        [HttpDelete()]
        public JsonResult Delete(int id)
        {
            string query = @"EXEC ELIMINA_USUARIO @ID_USER";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@ID_USER", id);
                    myReader = cmd.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
       /* [HttpGet] aqui debe ir el login
        [Route("login")]
        public IActionResult Login(TUsuario login)
        {

            return new JsonResult("Deleted Successfully");
        }
       */
    }
}
