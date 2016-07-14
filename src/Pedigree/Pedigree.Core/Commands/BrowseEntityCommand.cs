using Vouzamo.EntityFramework.Commands;
using Vouzamo.EntityFramework.Interfaces;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Core.Commands
{
    public class BrowseEntityCommand<TEntity, TViewModel> : ListEntityCommand<TEntity, TViewModel> where TEntity : IEntity where TViewModel : ISearchable<TEntity>, new()
    {
        public IOrderBySpecification<TEntity> Specification { get; protected set; }

        public BrowseEntityCommand(IOrderBySpecification<TEntity> specification, int page = 1, int resultsPerPage = 10) : base(page, resultsPerPage)
        {
            Specification = specification;
        }
    }
}
