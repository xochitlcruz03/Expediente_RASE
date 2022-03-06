using Expediente_RASE.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using DinkToPdf;
using DinkToPdf.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expediente_RASE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {

        private readonly string _connectionString;
        private IConverter _converter;
       
        public PDFController(IConfiguration configuration, IConverter converter)
        {

            _connectionString = configuration.GetConnectionString("Sucursal2");
            _converter = converter;

        }
        // GET api/<PDFController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id_con)
        {
            string query = @"EXEC CONSULTA_INS_MED @ID_CON";
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(_connectionString))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_CON", id_con);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        /*public void crear_pdf(DataTable dt)
        {
            //DataTable dt = new DataTable();
            Document document = new Document();
            
            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            //dt = DtMedicamentos(id_con);
            if (dt.Rows.Count > 0)
            {
                document.Open();
                Font fontTitle = FontFactory.GetFont(FontFactory.COURIER_BOLD, 25);
                Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);


                PdfPTable table = new PdfPTable(dt.Columns.Count);
                document.Add(new Paragraph(20, "Reporte de Alumnos 2020", fontTitle));
                document.Add(new Chunk("\n"));

                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    widths[i] = 4f;

                table.SetWidths(widths);
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell(new Phrase("columns"));
                cell.Colspan = dt.Columns.Count;

                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font9));
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int h = 0; h < dt.Columns.Count; h++)
                        {
                            table.AddCell(new Phrase(r[h].ToString(), font9));
                        }
                    }
                }
                document.Add(table);
            }
            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=AlumnosActuales2020" + ".pdf");
            HttpContext.Current.Response.Write(document);
            Response.Flush();
            Response.End();
        }*/

        /*[Route("getfile")]
        public HttpResponseMessage GetTestFile()
        {
            HttpResponseMessage result = null;
           
            HttpContext context = HttpContext.Current;
            var localFilePath = HttpContext.Current.Server.MapPath("~/timetable.jpg");

            if (!File.Exists(localFilePath))
            {
                result = Request.CreateResponse(HttpStatusCode.Gone);
            }
            else
            {
                // Serve the file to the client
                result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = "SampleImg";
            }

            return result;
        }*/

        [HttpGet]
        public IActionResult CreatePDF(int id)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"C:\Users\elektra\Documents\octavoA\programacionweb\reporte.pdf"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(id),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Receta Medica" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            return Ok("Successfully created PDF document.");
        }

    }  
       
}
