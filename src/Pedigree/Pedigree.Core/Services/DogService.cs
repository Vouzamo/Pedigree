using System;
using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.Interop.Interfaces;
using Microsoft.EntityFrameworkCore;
using Vouzamo.Specification.Interfaces;
using Pedigree.Common.Specifications;
using Vouzamo.Specification;
using Vouzamo.Interop;

namespace Pedigree.Core.Services
{
    public class DogService : BasicService<Dog, DogViewModel>, IDogService
    {
        public DogService(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }

        public IResponse<DogViewModel> Rename(Guid id, string name)
        {
            throw new NotImplementedException();
        }

        public IResponse<DogViewModel> AssignSire(Guid id, Guid sireId)
        {
            throw new NotImplementedException();
        }

        public IResponse<DogViewModel> AssignDam(Guid id, Guid damId)
        {
            throw new NotImplementedException();
        }

        public IResponse<PedigreeViewModel> GeneratePedigree(Guid id, PedigreeGenerations generations)
        {
            try
            {
                var dogResponse = Get(id);

                if (dogResponse.Success)
                {
                    var dog = dogResponse.Result;

                    PedigreeParentageViewModel sire = default(PedigreeParentageViewModel);
                    if(dog.SireId.HasValue)
                    {
                        var sireResponse = Get(dog.SireId.Value);

                        if(sireResponse.Success)
                        {
                            sire = DetermineParentage(sireResponse.Result, Parentage.Sire, (int)generations);
                        }
                    }

                    PedigreeParentageViewModel dam = default(PedigreeParentageViewModel);
                    if (dog.DamId.HasValue)
                    {
                        var damResponse = Get(dog.DamId.Value);

                        if (damResponse.Success)
                        {
                            dam = DetermineParentage(damResponse.Result, Parentage.Dam, (int)generations);
                        }
                    }

                    var pedigree = new PedigreeViewModel(dogResponse.Result, sire, dam);

                    return Response<PedigreeViewModel>.SuccessResponse(pedigree);
                }
                else
                {
                    throw new Exception("Invalid dog!");
                }
            }
            catch(Exception ex)
            {
                return Response<PedigreeViewModel>.ErrorResponse(Error.FromException(ex));
            }
        }

        private PedigreeParentageViewModel DetermineParentage(DogViewModel dog, Parentage type, int generations, int generation = 1)
        {
            DogViewModel sire = default(DogViewModel);
            DogViewModel dam = default(DogViewModel);

            if (dog.SireId.HasValue)
            {
                var sireResponse = Get(dog.SireId.Value);

                if(sireResponse.Success)
                {
                    sire = sireResponse.Result;
                }
            }

            if (dog.DamId.HasValue)
            {
                var damResponse = Get(dog.DamId.Value);

                if (damResponse.Success)
                {
                    dam = damResponse.Result;
                }
            }

            var parentage = new PedigreeParentageViewModel(dog, type, generations, generation);

            if (generation < generations)
            {
                var parentageGeneration = generation + 1;

                if (sire != null)
                {
                    parentage.Sire = DetermineParentage(sire, Parentage.Sire, generations, parentageGeneration);
                }
                
                if(dam != null)
                {
                    parentage.Dam = DetermineParentage(dam, Parentage.Dam, generations, parentageGeneration);
                }
            }

            return parentage;
        }

        public override IOrderBySpecification<Dog> BrowseSpecification(DogViewModel filter)
        {
            return new DogBrowseSpecification(filter);
        }

        public override IOrderBySpecification<Dog> SearchSpecification(string term)
        {
            return new BasicSearchSpecification<Dog>(term).OrderBy(x => x.Name);
        }
    }
}
