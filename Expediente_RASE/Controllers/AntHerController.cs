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
    [Route("api/Anther")]
    [ApiController]
    public class AntHerController : ControllerBase
    {
        private Models.RASE_DBContext oContext;
        private IMapper _mapper;
        private readonly string _connectionString;

        public AntHerController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }
        // GET: api/<AntPatController>
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"EXEC CONSULTA_ANT_HEREDOFAM @ID_PAC";//DEVUELVE N_ANT, REGISTRO, NOTAS
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
        public JsonResult Post(AntHer_POST antp)
        {
            string query = @"EXEC AGREGA_ANT_HEREDOFAM @ID_PAC, @ID_ANT, @REG_HER, @AN_HER";//DEVUELVE NOM_SUC DIR_SUC
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_PAC", antp.IdPac);
                    myCommand.Parameters.AddWithValue("@ID_ANT", antp.IdAnt);
                    myCommand.Parameters.AddWithValue("@REG_HER", antp.RegHer);
                    myCommand.Parameters.AddWithValue("@AN_HER", antp.AnHer);

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
        public JsonResult Put(AntHer_POST antp, int id)
        {
            string query = @"EXEC ACTUALIZA_ANT_HEREDOFAM @ID_PAC, @ID_ANT, @REG_PAT, @AN_PAT";//DEVUELVE NOM_SUC DIR_SUC
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_PAC", id);
                    myCommand.Parameters.AddWithValue("@ID_ANT", antp.IdAnt);
                    myCommand.Parameters.AddWithValue("@REG_PAT", antp.RegHer);
                    myCommand.Parameters.AddWithValue("@AN_PAT", antp.AnHer);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("put Successfully");
        }

    }
}
