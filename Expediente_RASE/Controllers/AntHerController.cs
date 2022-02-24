﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expediente_RASE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntHerController : ControllerBase
    {
        // GET: api/<AntHerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AntHerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AntHerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AntHerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AntHerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
