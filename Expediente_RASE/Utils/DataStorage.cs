﻿using Expediente_RASE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.Utils
{
    public class DataStorage {
        public static List<TInsMed_POST> GetAllEmployess(int id) =>
           new List<TInsMed_POST>(id);

           /* var libros = await oContext.Libros.ToListAsync();
            return _mapper.Map<List<LibroDTO>>(libros);*/
            /*new List<Employee>
            {
                new Employee { Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                new Employee { Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee { Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee { Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee { Name="John", LastName="Doe", Age=45, Gender="Male"}
            };*/
    }
}
