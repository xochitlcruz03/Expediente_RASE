using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expediente_RASE.Utils
{
    public class TemplateGenerator
    {
        private readonly string _connectionString;

        public TemplateGenerator(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            
            _connectionString = configuration.GetConnectionString("Sucursal2");
            
        }
        private DataTable GetData(string query)
        {
            string conString = _connectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public static string GetHTMLString()
        {
            var employees = DataStorage.GetAllEmployees();
            var sb = new StringBuilder();
            
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h3>Consulta-Rase</h3></div>
                                
                                <table>
    <tbody>
        <tr> <div class='Fecha'>
                <p>Fecha:07/03/2022</p>
             <div>
            </td>
            <td>
                <p>Consulta-rase</p>
            </td>
            <td>
                <p>&nbsp;</p>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td><div class='Matriz'>
                <p>Matriz Consultorio&nbsp;<br> <strong>ZAIRA LUEVANO PELAYO&nbsp;</strong><br> <strong>M&eacute;dico Cirujano</strong><br>&nbsp;zairaluevanopelayo@gmail.com<br>&nbsp;C&eacute;dula Profesional: XXXXXXXX</p>
                </div>
            </td>
            <td >
                <div class='folio'>
                <p>Receta de Medicamentos</p>
                <p>Generado por: RASE</p>
                <p>Folio: 100001</p>
                </div>
            </td>
        </tr>
        <tr><div class='paciente'>
            <td>
                <p>Paciente: ANTONIO VAZQUEZ VALENCIA</p>
            </td>
            </div>
            <td>
                <p>Sexo: MASCULINO</p>
            </td>
        </tr>
        <tr><div id='medicamento'>
            <td>
                <p>Medicamentos</p>
            </td>
        </div>
        </tr>
        <tr>
            <td>
                <p>Medicamento</p>
            </td>
            <td>
                <p> Dosis </p>
            </td>
            <td>
                <p>Frecuencia</p>
            </td>
            <td>
                <p>Duraci&oacute;n</p>
            </td>
            <td>
                <p>Notas</p>
            </td>
        </tr>
        <tr>
            <td>
                <p>Aspirina 500 mg</p>
            </td>
            <td>
                <p>1 tableta</p>
            </td>
            <td>
                <p>Cada 8 horas</p>
            </td>
            <td>
                <p>Por 7 d&iacute;as</p>
            </td>
            <td>
                <p>En caso de dolor</p>
            </td>
        </tr>
        <tr>
        
            <td>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
           
                 
               <p>________________________</p>
                <p>&nbsp;</p>
                <p ><strong>ZAIRA LUEVANO PELAYO</strong></p>
            </td>
        </tr>
    </tbody>
</table>
                                                                                                 

                                                                                                                             </body>
                        </html>");
            return sb.ToString();
        }

        
    }
}
