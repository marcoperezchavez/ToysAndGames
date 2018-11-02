using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToysAndGameWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToysAndGameWeb.ApiRest
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ProductsGNL> Get()
        {

            var list = Methods.Helpers.GetProductsList();
            return list;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<ProductsGNL> Get(int id)
        {
            var list = Methods.Helpers.GetProduct(id);
            return list;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] ProductsGNL Products)
        {
            var isSave = Methods.Helpers.SaveAlumno(Products);
            if (isSave)
                return Ok();
            return BadRequest();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] ProductsGNL Products)
        {
            var isUpdated = Methods.Helpers.UpdateAlumno(Products.Id, Products);
            if (isUpdated)
                return Ok();
            return BadRequest();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = Methods.Helpers.DeleteId(id);
            if (isDeleted)
                return Ok();
            return BadRequest();
        }
    }
}
