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
            //
            //var employees = DataStorage.GetAllEmployess();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h3>Consulta-Rase</h3></div>
                                
                                <table>
    <tbody>
        <tr>
            <td>
                <p>Fecha:07/03/2022</p>
            </td>
            <td>
                <p>Consulta-rase</p>
            </td>
            <td>
                <p>&nbsp;</p>
            </td>
        </tr>
        <tr>
            <td>
                <p>IMG</p>
            </td>
            <td  align='center'>
                <p >Matriz Consultorio&nbsp;<br>&nbsp;nombre Doctor<br>&nbsp;Especialidad<br>&nbsp;correo<br>&nbsp;c&eacute;dula:</p>
            </td>
            <td>
                <p>Receta de Medicamentos</p>
                <p>Generado por: RASE</p>
                <p>Folio: ID_CON</p>
            </td>
        </tr>
        <tr>
            <td>
                <p>Paciente: NOM_PAC</p>
            </td>
        </tr>
        <tr>
            <td>
                <p>Medicamentos</p>
            </td>
        </tr>
        <tr>
            <td>
                <p>Medicamento</p>
            </td>
            <td>
                <p>Dosis&nbsp;</p>
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
                <p>&nbsp;</p>
            </td>
            <td>
                <p>&nbsp;</p>
            </td>
            <td>
                <p>&nbsp;</p>
            </td>
            <td>
                <p>&nbsp;</p>
            </td>
            <td>
                <p>&nbsp;</p>
            </td>
        </tr>
        <tr>
            <td aling = 'center'>
                <p>_______________________</p>
                <p>NOMBRE_DOCTOR</p>
            </td>
        </tr>
    </tbody>
</table>

                                <table align='center'>
                                    <tr>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }


    } 
}
            
           //foreach (var emp in employees)
           /*{
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", 
                                  emp.IdMed, emp.Frecuencia, emp.Duracion, emp.NotasIns);
            }
            sb.Append(@"
                                </table>/*
                            </body>
                        </html>");
            return sb.ToString();
        }

        
    }
}/*
