using AutoMapper;
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
    [Route("api/Medicina")]
    [ApiController]
    public class TMedicinaController : ControllerBase
    {
        private Models.RASE_DBContext oContext;
        private IMapper _mapper;
        private readonly string _connectionString;

        public TMedicinaController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }
        // GET: api/<TMedicinaController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"EXEC CONSULTA_TAB_MED";//NOM_MEDICINA, ((DESCRIPCION
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
        [HttpGet("scroll")]//api/medicina/scroll
        public JsonResult GetScroll()
        {
            string query = @"EXEC CONSULTA_TAB_MED_SCROLL";//NOM_MEDICINA
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(TMedicina med)
        {
            string query = @"EXEC AGREGA_TAB_MED @NOMB_MED,@DESC_MED";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@NOMB_MED", med.NomMed);
                    myCommand.Parameters.AddWithValue("@DESC_MED", med.DescMed);
                    myReader = myCommand.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut()]
        public JsonResult Put(TMedicina med)
        {
            string query = @"EXEC ACTUALIZA_TAB_MED @ID_MED, @NOMB_MED, @DESC_MED";

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@ID_MED", med.IdMed);
                    myCommand.Parameters.AddWithValue("@NOMB_MED", med.NomMed);
                    myCommand.Parameters.AddWithValue("@DESC_MED", med.DescMed);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("PUT Successfully");
        }

        [HttpDelete()]
        public JsonResult Delete(int ID)
        {
            string query = @"EXEC ELIMINA_TAB_MED @ID_MED";

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@ID_MED", ID);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }




    }
}
