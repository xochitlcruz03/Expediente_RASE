using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expediente_RASE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMedicinaController : ControllerBase
    {
        private Models.RASE_DBContext oContext;
        private IMapper _mapper;
        private readonly string _connectionString;

        public TMedicinaController(Models.RASE_DBContext context, IConfiguration configuration, IMapper mapper) //Inyeccion de una dependencia
        {
            this.oContext = context;
            _connectionString = configuration.GetConnectionString("Sucursal2");
            this._mapper = mapper;
        }
        // GET: api/<TMedicinaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TMedicinaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TMedicinaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TMedicinaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TMedicinaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
