using AutoMapper;
using Expediente_RASE.DTO;
using Expediente_RASE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expediente_RASE.Controllers
{
    [Route("api/Sucursales")]
    [ApiController]
    public class CSucController : ControllerBase
    {
        private Models.RASE_DBContext oContext;
        private IMapper _mapper;
        private readonly string _connectionString;

        public CSucController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }

        // GET: api/<CSucController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"EXEC CONSULTA_CAT_SUC";//DEVUELVE NOM_SUC DIR_SUC
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

        // POST api/<CSucController>
        [HttpPost]
        public JsonResult Post(CSuc_POST suc)
        {
            string query = @"EXEC AGREGA_CAT_SUC @NOM_SUC, @DIR_SUC";

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@NOM_SUC", suc.NomSuc);
                    myCommand.Parameters.AddWithValue("@DIR_SUC", suc.DirSuc);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }


        // PUT api/<CSucController>/5
        [HttpPut()]
        public JsonResult Put(CSuc_PUT_DELETE suc)
        {
            string query = @"EXEC ACTUALIZA_CAT_SUC @ID_SUC, @NOM_SUC, @DIR_SUC";

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_SUC", suc.IdSuc);
                    myCommand.Parameters.AddWithValue("@NOM_SUC", suc.NomSuc);
                    myCommand.Parameters.AddWithValue("@DIR_SUC", suc.DirSuc);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("PUT Successfully");
        }

        // DELETE api/Sucursal/5
        [HttpDelete()]
        public JsonResult Delete(int id)
        {
            string query = @"EXEC ELIMINA_CAT_SUC @ID_SUC";

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_SUC", id);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }
    }
}
