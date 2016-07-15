using Microsoft.AspNetCore.Mvc;
using Pedigree.App.Extensions;
using Pedigree.Common.Interfaces;
using System;
using Vouzamo.EntityFramework.Interfaces;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.App.Controllers
{
    [Route("api/[controller]")]
    public abstract class BasicController<TEntity, TViewModel, TService> where TService : IBasicService<TEntity, TViewModel> where TEntity : IEntity where TViewModel : ISearchable<TEntity>, new()
    {
        protected TService Service { get; set; }

        protected BasicController(TService service)
        {
            Service = service;
        }

        [HttpGet("search/{term}")]
        public virtual IActionResult Search(string term, int page = 1, int resultsPerPage = 10)
        {
            var results = Service.Search(term, page, resultsPerPage);

            return results.ToObjectResult();
        }

        [HttpGet("")]
        public IActionResult Browse(TViewModel filter, int page = 1, int resultsPerPage = 10)
        {
            var results = Service.Browse(filter, page, resultsPerPage);

            return results.ToObjectResult();
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(Guid id)
        {
            var result = Service.Get(id);

            return result.ToObjectResult();
        }

        [HttpPost("")]
        public virtual IActionResult Create([FromBody]TViewModel model)
        {
            var result = Service.Create(model);

            return result.ToObjectResult();
        }
    }
}
