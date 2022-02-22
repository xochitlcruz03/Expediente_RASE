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
    [Route("api/pacientes")]
    [ApiController]
    public class TPacController : ControllerBase
    {
        //xochitl 
        //private readonly IConfiguration _configuration;
        private Models.RASE_DBContext oContext;
        private IMapper _mapper;
        private readonly string _connectionString;

        public TPacController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }
        // GET: api/<TPacController>
        [HttpGet]//ID_ PAC, NOM_PAC, AP_PAT_PAC, AP_MAT_PAC, EDAD, TEL_PAC, NOTAS_PAC
        public JsonResult GetListado()
        {
            string query = @"EXEC CONSULTA_PACIENTES";
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

        // GET api/<TPacController>/5
        [HttpGet("{id:int}")]
        public JsonResult Get(int id)
        {
            string query = @"EXEC CONSULTA_PACIENTE @ID_PAC";
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

        // POST api/<TPacController>
        [HttpPost]
        public JsonResult Post(TPac_POST pac)
        {
            string query = @"EXEC AGREGA_PACIENTE @NOM_PAC,@AP_PAT_PAC,@AP_MAT_PAC,@FEC_NAC_PAC,@SEXO_PAC,@CURP_PAC,@TEL_PAC,@CORREO_PAC,@T_SANGRE_PAC,@EST_CIV_PAC,@OCUPACION_PAC,@NOTAS_PAC,@ARCH_PAC";
           
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@NOM_PAC", pac.NomPac);
                    myCommand.Parameters.AddWithValue("@AP_PAT_PAC", pac.ApPatPac);
                    myCommand.Parameters.AddWithValue("@AP_MAT_PAC", pac.ApMatPac);
                    myCommand.Parameters.AddWithValue("@FEC_NAC_PAC", pac.FecNacPac);
                    myCommand.Parameters.AddWithValue("@SEXO_PAC", pac.SexoPac);
                    myCommand.Parameters.AddWithValue("@CURP_PAC", pac.CurpPac);
                    myCommand.Parameters.AddWithValue("@TEL_PAC", pac.TelPac);
                    myCommand.Parameters.AddWithValue("@CORREO_PAC", pac.CorreoPac);
                    myCommand.Parameters.AddWithValue("@T_SANGRE_PAC", pac.TSangrePac);
                    myCommand.Parameters.AddWithValue("@EST_CIV_PAC", pac.EstCivPac);
                    myCommand.Parameters.AddWithValue("@OCUPACION_PAC", pac.OcupacionPac);
                    myCommand.Parameters.AddWithValue("@NOTAS_PAC", pac.NotasPac);
                    myCommand.Parameters.AddWithValue("@ARCH_PAC", pac.ArchPac);
                    myReader = myCommand.ExecuteReader();
                   
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }

        // PUT api/<TPacController>/5
        [HttpPut()]
        public JsonResult Put(TPac_PUT_DELETE pac)
        {
            string query = @"EXEC ACTUALIZA_PACIENTE @ID_PAC,@NOM_PAC,@AP_PAT_PAC,@AP_MAT_PAC,@FEC_NAC_PAC,@SEXO_PAC,@CURP_PAC,@TEL_PAC,@CORREO_PAC,@T_SANGRE_PAC,@EST_CIV_PAC,@OCUPACION_PAC,@NOTAS_PAC,@ARCH_PAC";

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_PAC", pac.IdPac);
                    myCommand.Parameters.AddWithValue("@NOM_PAC", pac.NomPac);
                    myCommand.Parameters.AddWithValue("@AP_PAT_PAC", pac.ApPatPac);
                    myCommand.Parameters.AddWithValue("@AP_MAT_PAC", pac.ApMatPac);
                    myCommand.Parameters.AddWithValue("@FEC_NAC_PAC", pac.FecNacPac);
                    myCommand.Parameters.AddWithValue("@SEXO_PAC", pac.SexoPac);
                    myCommand.Parameters.AddWithValue("@CURP_PAC", pac.CurpPac);
                    myCommand.Parameters.AddWithValue("@TEL_PAC", pac.TelPac);
                    myCommand.Parameters.AddWithValue("@CORREO_PAC", pac.CorreoPac);
                    myCommand.Parameters.AddWithValue("@T_SANGRE_PAC", pac.TSangrePac);
                    myCommand.Parameters.AddWithValue("@EST_CIV_PAC", pac.EstCivPac);
                    myCommand.Parameters.AddWithValue("@OCUPACION_PAC", pac.OcupacionPac);
                    myCommand.Parameters.AddWithValue("@NOTAS_PAC", pac.NotasPac);
                    myCommand.Parameters.AddWithValue("@ARCH_PAC", pac.ArchPac);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("PUT Successfully");
        }

        // DELETE api/<TPacController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"EXEC ELIMINA_PACIENTE @ID_PAC";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_PAC", id);
                    myReader = myCommand.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
