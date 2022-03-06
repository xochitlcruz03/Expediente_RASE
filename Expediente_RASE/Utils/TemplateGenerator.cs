using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expediente_RASE.Utils
{
    public class TemplateGenerator
    {
        public static string GetHTMLString(int id)
        {
            var employees = DataStorage.GetAllEmployess(id);
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h3>Consulta-Rase</h3></div>
                                

                                <table align='center'>
                                    <tr>
                                        <th>iagen de logo</th>
                                        <th><p<> nombre de la sucursal</p>
                                        <p> nombre del medico</p>
                                        <p> especialidad del medico</p>
                                        <p> correo del medico</p>
                                        <p> cedula profesional:</p> </th>
                                        <th><P>FECHA:<P>
                                            <P> FOLIO:<P>
                                        </th>
                                    </tr>");
            
            foreach (var emp in employees)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", emp.IdMed, emp.Frecuencia, emp.Duracion, emp.NotasIns);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}
