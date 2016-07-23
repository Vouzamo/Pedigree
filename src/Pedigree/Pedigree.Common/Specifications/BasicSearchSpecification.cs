using System;
using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Vouzamo.EntityFramework.Interfaces;
using Vouzamo.Specification;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Common.Specifications
{
    public class DogSearchSpecification : ISearchSpecification<Dog>
    {
        public IOrderBySpecification<Dog> Search(string term)
        {
            return new BasicSearchSpecification<Dog>(term).OrderBy(x => x.Name);
        }
    }

    public class PersonSearchSpecification : ISearchSpecification<Person>
    {
        public IOrderBySpecification<Person> Search(string term)
        {
            return new BasicSearchSpecification<Person>(term).OrderBy(x => x.Name);
        }
    }

    public class CoatColorSearchSpecification : ISearchSpecification<CoatColor>
    {
        public IOrderBySpecification<CoatColor> Search(string term)
        {
            return new BasicSearchSpecification<CoatColor>(term).OrderBy(x => x.Name);
        }
    }

    public class TitleSearchSpecification : ISearchSpecification<Title>
    {
        public IOrderBySpecification<Title> Search(string term)
        {
            return new BasicSearchSpecification<Title>(term).OrderBy(x => x.Name);
        }
    }

    public class BasicSearchSpecification<T> : WhereSpecification<T> where T : IBasicEntity
    {
        public BasicSearchSpecification(string term)
        {
            Predicate = x => x.Name.Contains(term);
        }
    }
}
