using System;
using Microsoft.AspNetCore.Mvc;
using Pedigree.Common.Interfaces;
using Pedigree.Common.ViewModels;

namespace Pedigree.App.Controllers
{
    [Route("[controller]")]
    public class DogsController : Controller
    {
        protected const int RESULTS_PER_PAGE = 12;
        protected IDogService DogService { get; set; }

        public DogsController(IDogService dogService)
        {
            DogService = dogService;
        }

        [Route("")]
        public IActionResult List(DogViewModel filter, int page = 1)
        {
            var response = DogService.Browse(filter, page, RESULTS_PER_PAGE);

            if(!response.Success)
            {
                return new EmptyResult();
            }

            return View(response.Result);
        }

        [Route("{id}/pedigree")]
        public IActionResult Pedigree(Guid id, PedigreeGenerations generations = PedigreeGenerations.Fourth)
        {
            var response = DogService.GeneratePedigree(id, generations);

            if(!response.Success)
            {
                return new EmptyResult();
            }

            return View(response.Result);
        }
    }
}
