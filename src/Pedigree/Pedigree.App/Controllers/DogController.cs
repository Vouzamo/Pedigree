using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pedigree.Common.Models;
using Pedigree.Core.Extensions;

namespace Pedigree.App.Controllers
{
    [Route("api/[controller]")]
    public class DogController : Controller
    {
        public static List<Dog> Dogs { get { return new List<Dog>() { new Dog("Viper", Sex.Bitch), new Dog("Fraiser", Sex.Dog), new Dog("Breeze", Sex.Bitch) }; } }

        // GET api/values
        [HttpGet]
        public IEnumerable<Dog> Get()
        {
            return Dogs;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Dog Get(Guid id)
        {
            return Dogs.SingleOrDefault(x => x.Id == id);
        }

        [HttpGet("{id}/setSire/{sireId}")]
        public IActionResult SetSire(Guid id, Guid sireId)
        {
            var dog = Get(id);
            var sire = Get(sireId);

            var success = dog.SetSire(sire);

            return success ? new StatusCodeResult(200) : new StatusCodeResult(500);
        }

        [HttpGet("{id}/setDam/{sireId}")]
        public IActionResult SetDam(Guid id, Guid damId)
        {
            var dog = Get(id);
            var dam = Get(damId);

            var success = dog.SetDam(dam);

            return success ? new StatusCodeResult(200) : new StatusCodeResult(500);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return new StatusCodeResult(500);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return new StatusCodeResult(500);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new StatusCodeResult(500);
        }
    }
}
