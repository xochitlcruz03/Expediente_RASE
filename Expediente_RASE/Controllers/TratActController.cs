using AutoMapper;
using Expediente_RASE.DTO;
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
    [Route("api/[controller]")]
    [ApiController]
    public class TratActController : ControllerBase
    {
        private Models.RASE_DBContext oContext;
        private IMapper _mapper;
        private readonly string _connectionString;

        public TratActController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }
        // GET: api/<TratActController>
        [HttpGet("{id:int}")]
        public JsonResult Get(int id)
        {
            string query = @"EXEC CONSULTA_TRAT_ACT @ID_PAC";
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_PAC", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        // POST api/<TratActController>
        [HttpPost]
        public JsonResult Post(TratAct_POST usuario)
        {
            string query = @"EXEC AGREGA_TRAT_ACT @ID_PAC,@TIPO_TRAT,@MEDIC";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@ID_PAC", usuario.IdPac);
                    cmd.Parameters.AddWithValue("@TIPO_TRAT", usuario.TipoTrat);
                    cmd.Parameters.AddWithValue("@MEDIC", usuario.Medic);
                    myReader = cmd.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        // PUT api/<TratActController>/5
        [HttpPut("{id}")]
        public JsonResult Put(TratAct_POST usuario, int id)
        {
            string query = @"EXEC ACTUALIZA_TRAT_ACT @ID_PAC,@TIPO_TRAT,@MEDIC";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@ID_PAC", usuario.IdPac);
                    cmd.Parameters.AddWithValue("@TIPO_TRAT", usuario.TipoTrat);
                    cmd.Parameters.AddWithValue("@MEDIC", usuario.Medic);
                    myReader = cmd.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        // DELETE api/<TratActController>/5
       /* [HttpDelete("{id}")]
        public JsonResult Delete( int id)
        {
            string query = @"EXEC ELIMINA_DOCTOR @ID_DOC";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_DOC", id);
                    myReader = myCommand.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");

        }*/
    }
}
