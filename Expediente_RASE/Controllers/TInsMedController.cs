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
    [Route("api/[controller]")]
    [ApiController]
    public class TInsMedController : ControllerBase
    {
        private Models.RASE_DBContext oContext;
        private IMapper _mapper;
        private readonly string _connectionString;

        public TInsMedController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }
        // GET: api/<TInsMedController>
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"EXEC CONSULTA_INS_MED @ID_CON";
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_CON", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }  

        // POST api/<TInsMedController>
        [HttpPost]
        public JsonResult Post(TInsMed_POST usuario)
        {
            string query = @"EXEC AGREGA_INS_MED @ID_PAC,@ID_CON,@ID_MED,@INDICACIONES,@FRECUENCIA,@DURACION,@NOTAS_INS";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@ID_PAC", usuario.IdPac);
                    cmd.Parameters.AddWithValue("@ID_CON", usuario.IdCon);
                    cmd.Parameters.AddWithValue("@ID_MED", usuario.IdMed);
                    cmd.Parameters.AddWithValue("@INDICACIONES", usuario.Indicaciones);
                    cmd.Parameters.AddWithValue("@FRECUENCIA", usuario.Frecuencia);
                    cmd.Parameters.AddWithValue("@DURACION", usuario.Duracion);
                    cmd.Parameters.AddWithValue("@NOTAS_INS", usuario.NotasIns);
                    myReader = cmd.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        // PUT api/<TInsMedController>/5
        [HttpPut("{id}")]
        public JsonResult Put(TInsMed_POST usuario)
        {
            string query = @"EXEC ACTUALIZA_INS_MED @ID_PAC,@ID_CON,@ID_MED,@INDICACIONES,@FRECUENCIA,@DURACION,@NOTAS_INS";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@ID_PAC", usuario.IdPac);
                    cmd.Parameters.AddWithValue("@ID_CON", usuario.IdCon);
                    cmd.Parameters.AddWithValue("@ID_MED", usuario.IdMed);
                    cmd.Parameters.AddWithValue("@INDICACIONES", usuario.Indicaciones);
                    cmd.Parameters.AddWithValue("@FRECUENCIA", usuario.Frecuencia);
                    cmd.Parameters.AddWithValue("@DURACION", usuario.Duracion);
                    cmd.Parameters.AddWithValue("@NOTAS_INS", usuario.NotasIns);
                    myReader = cmd.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        // DELETE api/<TInsMedController>/5
        [HttpDelete("{id1,id2,id3}")]
        public JsonResult Delete(TInsMed_POST usuario)
        {
            string query = @"EXEC ACTUALIZA_INS_MED @ID_PAC,@ID_CON,@ID_MED";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@ID_PAC", usuario.IdPac);
                    cmd.Parameters.AddWithValue("@ID_CON", usuario.IdCon);
                    cmd.Parameters.AddWithValue("@ID_MED", usuario.IdMed);
                    myReader = cmd.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
    }
}
