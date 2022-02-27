using AutoMapper;
using Expediente_RASE.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.Controllers
{
    [Route("api/Antaler")]
    [ApiController]
    public class AntAlerController : Controller
    {
        private Models.RASE_DBContext oContext;
        private IMapper _mapper;
        private readonly string _connectionString;

        public AntAlerController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }
        // GET: api/<AntPatController>
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"EXEC CONSULTA_ANT_ALER @ID_PAC";// DEVUELVE REG_ALER,DESC_ALER
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_PAC", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }


        // POST api/<AntPatController>
        [HttpPost]
        public JsonResult Post(AntAler_POST antp)
        {
            string query = @"EXEC AGREGA_ANT_ALER @ID_PAC, @REG_ALER, @DESC_ALER ";//DEVUELVE NOM_SUC DIR_SUC
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_PAC", antp.IdPac);
                    myCommand.Parameters.AddWithValue("@REG_ALER", antp.RegAler);
                    myCommand.Parameters.AddWithValue("@DESC_ALER", antp.DescAler);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        // PUT api/<AntPatController>/5
        [HttpPut("{id}")]
        public JsonResult Put(AntAler_POST antp, int id)
        {
            string query = @"EXEC ACTUALIZA_ANT_ALER  @ID_PAC, @REG_ALER, @DESC_ALER";//DEVUELVE NOM_SUC DIR_SUC
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@ID_PAC", id);
                    myCommand.Parameters.AddWithValue("@REG_ALER", antp.RegAler);
                    myCommand.Parameters.AddWithValue("@DESC_ALER", antp.DescAler);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Put Successfully");
        }
    }
}
