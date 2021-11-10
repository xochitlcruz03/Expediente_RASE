using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Expediente_RASE.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expediente_RASE.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class pruebaController : ControllerBase
    {
        //xochitl 
        private ApplicationDbContext oContext;
        public pruebaController(ApplicationDbContext context) //Inyeccion de una dependencia
        {
            this.oContext = context;
        }
        // GET: api/<pruebaController>
        [HttpGet("lista")]
        public async Task<ActionResult<T_USUARIOS>> PrimerAutor()
        {
            return await oContext.T_USUARIOS.
        }

        // GET api/<pruebaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<pruebaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
