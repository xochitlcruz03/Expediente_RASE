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
            string query = @"
                    select NOM_DOC,AP_PAT_DOC,AP_MAT_DOC,TEL_DOC from dbo.T_DOCTORES";
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
        // GET api/medicos/5
       /* [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/medicos
        [HttpPost]
        public JsonResult Post(TDoctore_POST doctor)
        {
            string query = @"
                            insert into dbo.T_DOCTORES values
                            ('"+doctor.NomDoc+""+doctor.ApPatDoc+""+doctor.ApMatDoc+ "" + doctor.CurpDoc + "" + doctor.RecDis + "" +
                            "" + doctor.IdEsp + "" + doctor.CorreoDoc + "" + doctor.TelDoc + "" + doctor.CedP +@"')"//@"insert into dbo.T_DOCTORES(ID_DOC,NOM_DOC,AP_PAT_DOC,AP_MAT_DOC,CURP_DOC,REC_DIS,ID_ESP,CORREO_DOC,TEL_DOC,CED_P) values (@ID_DOC,@NOM_DOC,@AP_PAT_DOC,@AP_MAT_DOC,@CURP_DOC,@REC_DIS,@ID_ESP,@CORREO_DOC,@TEL_DOC,@CED_P)"
                            ;
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    /**myCommand.Parameters.AddWithValue("@ID_DOC", doctor.IdDoc);
                    myCommand.Parameters.AddWithValue("@NOM_DOC", doctor.NomDoc);
                    myCommand.Parameters.AddWithValue("@AP_PAT_DOC", doctor.ApPatDoc);
                    myCommand.Parameters.AddWithValue("@AP_MAT_DOC", doctor.ApMatDoc);
                    myCommand.Parameters.AddWithValue("@CURP_DOC", doctor.CurpDoc);
                    myCommand.Parameters.AddWithValue("@REC_DIS", doctor.RecDis);
                    myCommand.Parameters.AddWithValue("@ID_ESP", doctor.IdEsp);
                    myCommand.Parameters.AddWithValue("@CORREO_DOC", doctor.CorreoDoc);
                    myCommand.Parameters.AddWithValue("@TEL_DOC", doctor.TelDoc);
                    myCommand.Parameters.AddWithValue("@CED_P", doctor.CedP);**/
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        // PUT api/medicos/5
        [HttpPut("{id:int}")]
        public JsonResult Put(TDoctore doctor)
        {
            string query = @"
                    update dbo.T_DOCTORES set 
                    NOM_DOC = '" + doctor.NomDoc +@"'AP_PAT_DOC='"+doctor.ApMatDoc+@"'
                    AP_MAT_DOC='"+ doctor.ApPatDoc +@"'CURP_DOC='" +doctor.CurpDoc +@"'
                    REC_DIS = '"+doctor.RecDis +@"'ID_ESP='"+doctor.IdEsp +@"'CORREO_DOC='"+doctor.CorreoDoc+@"'
                    TEL_DOC ='"+doctor.TelDoc+@"'CED_P='"+doctor.CedP+@"'
                    where ID_DOC =" + doctor.IdDoc + @"";
                    
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

            return new JsonResult("PUT Successfully");
        }

        // DELETE api/medicos/5
        [HttpDelete("{id:int}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                   delete from dbo.T_DOCTORES where ID_DOC =@ID_DOC";

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

            return new JsonResult("Deleted Successfully");

        }
    }
}
