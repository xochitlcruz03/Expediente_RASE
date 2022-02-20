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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expediente_RASE.Controllers
{
    [Route("api/Medicos")]
    [ApiController]
    public class TDoctoresController : ControllerBase
    {
        //xochitl 
        //private readonly IConfiguration _configuration;
        private Models.RASE_DBContext oContext;
        private IMapper _mapper;
        private readonly string _connectionString;

        public TDoctoresController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }
        // GET: api/medicos
        [HttpGet]
        public JsonResult Get()
        {
           string query = @"EXEC CONSULTA_DOCTORES";
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
        // GET api/medicos/5
        [HttpGet("{id:int}")]
        public JsonResult GetUno(int id)
        {
            string query = @"EXEC CONSULTA_DOCTOR @ID_DOC";
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_DOC", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        // POST api/medicos
        [HttpPost]
        public JsonResult Post(TDoctore_POST doctor)
        {
            string query = @"EXEC AGREGA_DOCTOR @NOM_DOC,@AP_PAT_DOC,@AP_MAT_DOC,@CURP_DOC,@REC_DIS,@ID_ESP,@CORREO_DOC,@TEL_DOC,@CED_P";
           
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

            return new JsonResult("Added Successfully");
        }

        // PUT api/medicos/5
        [HttpPut()]
        public JsonResult Put(TDoctore_GET_DELETE doctor)
        {
            string query = @"EXEC ACTUALIZA_DOCTOR @ID_DOC,@NOM_DOC,@AP_PAT_DOC,@AP_MAT_DOC,@CURP_DOC,@REC_DIS,@ID_ESP,@CORREO_DOC,@TEL_DOC,@CED_P";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_DOC", doctor.IdDoc);
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
            return new JsonResult("PUT Successfully");
        }

        // DELETE api/medicos/5
        [HttpDelete()]
        public JsonResult Delete(int id)
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

        }
    }
}
