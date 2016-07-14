using Pedigree.Common.Models;
using Pedigree.Common.Specifications;
using System;
using System.Linq;
using Vouzamo.EntityFramework.Interfaces;
using Vouzamo.Specification;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Common.ViewModels
{
    public class DogViewModel : ISearchable<Dog>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Sex? Sex { get; set; }

        public Guid? SireId { get; set; }
        public Guid? DamId { get; set; }

        public IOrderBySpecification<Dog> SearchSpecification(string keyword)
        {
            return new BasicSearchSpecification<Dog>(keyword).OrderBy(x => x.Name);
        }
    }
}
