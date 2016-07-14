using Pedigree.Common.Models;
using Pedigree.Common.Specifications;
using System;
using System.Linq;
using Vouzamo.EntityFramework.Interfaces;
using Vouzamo.Specification;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Common.ViewModels
{
    public class PersonViewModel : ISearchable<Person>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IOrderBySpecification<Person> SearchSpecification(string keyword)
        {
            return new BasicSearchSpecification<Person>(keyword).OrderBy(x => x.Name);
        }
    }
}
