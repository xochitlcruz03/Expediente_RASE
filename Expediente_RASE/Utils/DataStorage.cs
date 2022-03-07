using Expediente_RASE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.Utils
{
    public class DataStorage {

        public static List<TInsMed_POST> GetAllEmployees() =>
                    new List<TInsMed_POST>
                    {
                new TInsMed_POST {  IdCon=65, IdMed=52, Frecuencia= "e", Duracion="Male"},
                
                    };
    }
}
