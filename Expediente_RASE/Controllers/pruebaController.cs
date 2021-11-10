using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expediente_RASE.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expediente_RASE.Controllers
{
    [Route("api/T_USUARIOS")]
    [ApiController]
    public class pruebaController : ControllerBase
    {
        //xochitl 
        private ApplicationDbContext oContext;
        public pruebaController(ApplicationDbContext context) //Inyeccion de una dependencia
        {
            this.oContext = context;
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // GET: api/<pruebaController>

        [HttpGet]
        public async Task<ActionResult<List<T_USUARIOS>>> Get()
        {
            return await oContext.T_USUARIOS.ToListAsync();

        }
       

        // PUT api/<pruebaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<pruebaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
      
    }
}
