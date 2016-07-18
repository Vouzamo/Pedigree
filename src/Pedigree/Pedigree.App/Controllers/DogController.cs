using Microsoft.AspNetCore.Mvc;
using Pedigree.App.Extensions;
using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using System;

namespace Pedigree.App.Controllers
{
    public class DogController : BasicController<Dog, DogViewModel, IDogService>
    {
        public DogController(IDogService service) : base(service)
        {
            
        }

        [HttpGet("rename/{id}/{name}")]
        public IActionResult Rename(Guid id, string name)
        {
            var result = Service.Rename(id, name);

            return result.ToObjectResult();
        }

        [HttpGet("assignSire/{id}/{sireId}")]
        public IActionResult AssignSire(Guid id, Guid sireId)
        {
            var result = Service.AssignSire(id, sireId);

            return result.ToObjectResult();
        }

        [HttpGet("assignDam/{id}/{damId}")]
        public IActionResult AssignDam(Guid id, Guid damId)
        {
            var result = Service.AssignDam(id, damId);

            return result.ToObjectResult();
        }
    }
}
