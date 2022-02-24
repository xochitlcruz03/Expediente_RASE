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
    [Route("api/consulta")]
    [ApiController]
    public class TConsultaController : ControllerBase
    {
        private Models.RASE_DBContext oContext;
        private IMapper _mapper;
        private readonly string _connectionString;

        public TConsultaController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }
        // GET: api/<TConsultaController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"EXEC CONSULTA_CONS_PACIENTE";//ID_PAC,PAC_NOM, AP_PAT_PAC, AP_MAT_PAC, DOC_NOM, DOC_AP_PAT, DOC_AP_MAT, NOM_SUC, FECHA_CON, MOTIVO, DIAGNOSTICO
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

        // GET api/<TConsultaController>/5
        [HttpGet("{id}")]
        public JsonResult GetPaciente(int id)
        {
            //CONSULTA_CONS_PACIENTES
            string query = @"EXEC CONSULTA_CONS_PACIENTES @ID_PAC";
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

        // POST api/<TConsultaController>
        [HttpPost]
        public JsonResult Post(TConsulta_POST consulta)
        {
            string query = @"EXEC AGREGA_CONSULTA @ID_PAC,@ID_DOC,@ID_SUC,@FECHA_CON,@ESTATURA,@PESO,@MASA_CORP,@TEMPERATURA,@FREC_RESP,@PRES_ART,@FREC_CAR,@GRASA_CORP,@MASA_MUSC,@SAT_OXIGENO,@MOTIVO,@DIAGNOSTICO";

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_PAC", consulta.IdPac);
                    myCommand.Parameters.AddWithValue("@ID_DOC", consulta.IdDoc);
                    myCommand.Parameters.AddWithValue("@ID_SUC", consulta.IdSuc);
                    myCommand.Parameters.AddWithValue("@FECHA_CON", consulta.FechaCon);
                    myCommand.Parameters.AddWithValue("@ESTATURA", consulta.Estatura);
                    myCommand.Parameters.AddWithValue("@PESO", consulta.Peso);
                    myCommand.Parameters.AddWithValue("@MASA_CORP", consulta.MasaCorp);
                    myCommand.Parameters.AddWithValue("@TEMPERATURA", consulta.Temperatura);
                    myCommand.Parameters.AddWithValue("@FREC_RESP", consulta.FrecResp);
                    myCommand.Parameters.AddWithValue("@PRES_ART", consulta.PresArt);
                    myCommand.Parameters.AddWithValue("@FREC_CAR", consulta.FrecCar);
                    myCommand.Parameters.AddWithValue("@GRASA_CORP", consulta.GrasaCorp);
                    myCommand.Parameters.AddWithValue("@MASA_MUSC", consulta.MasaMusc);
                    myCommand.Parameters.AddWithValue("@SAT_OXIGENO", consulta.SatOxigeno);
                    myCommand.Parameters.AddWithValue("@MOTIVO", consulta.Motivo);
                    myCommand.Parameters.AddWithValue("@DIAGNOSTICO", consulta.Diagnostico);
                    myReader = myCommand.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }


        // PUT api/<TConsultaController>/5
        [HttpPut("{id}")]
        public JsonResult Put(TConsulta_POST consulta, int id)
        {
            string query = @"EXEC ACTUALIZA_CONSULTA @ID_CON,@ID_PAC,@ID_DOC,@ID_SUC,@FECHA_CON,@ESTATURA,@PESO,@MASA_CORP,@TEMPERATURA,@FREC_RESP,@PRES_ART,@FREC_CAR,@GRASA_CORP,@MASA_MUSC,@SAT_OXIGENO,@MOTIVO,@DIAGNOSTICO";

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_CON", id);
                    myCommand.Parameters.AddWithValue("@ID_PAC", consulta.IdPac);
                    myCommand.Parameters.AddWithValue("@ID_DOC", consulta.IdDoc);
                    myCommand.Parameters.AddWithValue("@ID_SUC", consulta.IdSuc);
                    myCommand.Parameters.AddWithValue("@FECHA_CON", consulta.FechaCon);
                    myCommand.Parameters.AddWithValue("@ESTATURA", consulta.Estatura);
                    myCommand.Parameters.AddWithValue("@PESO", consulta.Peso);
                    myCommand.Parameters.AddWithValue("@MASA_CORP", consulta.MasaCorp);
                    myCommand.Parameters.AddWithValue("@TEMPERATURA", consulta.Temperatura);
                    myCommand.Parameters.AddWithValue("@FREC_RESP", consulta.FrecResp);
                    myCommand.Parameters.AddWithValue("@PRES_ART", consulta.PresArt);
                    myCommand.Parameters.AddWithValue("@FREC_CAR", consulta.FrecCar);
                    myCommand.Parameters.AddWithValue("@GRASA_CORP", consulta.GrasaCorp);
                    myCommand.Parameters.AddWithValue("@MASA_MUSC", consulta.MasaMusc);
                    myCommand.Parameters.AddWithValue("@SAT_OXIGENO", consulta.SatOxigeno);
                    myCommand.Parameters.AddWithValue("@MOTIVO", consulta.Motivo);
                    myCommand.Parameters.AddWithValue("@DIAGNOSTICO", consulta.Diagnostico);
                    myReader = myCommand.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("PUT Successfully");
        }


        // DELETE api/<TConsultaController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"EXEC ELIMINA_CONS @ID_CON";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                   myCommand.Parameters.AddWithValue("@ID_CON", id);
                    myReader = myCommand.ExecuteReader();

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
