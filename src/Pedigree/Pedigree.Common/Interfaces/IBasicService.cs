using System;
using Vouzamo.EntityFramework.Interfaces;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Pagination;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Common.Interfaces
{
    public interface IBasicService<TEntity, TViewModel> where TEntity : IEntity where TViewModel : ISearchable<TEntity>
    {
        IResponse<PagedSearchResults<TEntity, TViewModel>> Search(string term, int page = 1, int resultsPerPage = 1);
        IResponse<PagedResults<TEntity, TViewModel>> Browse(IOrderBySpecification<TEntity> specification, int page = 1, int resultsPerPage = 1);
        IResponse<TViewModel> Get(Guid id);
        IResponse<TViewModel> Create(TViewModel dog);
        IResponse<TViewModel> Update(TViewModel dog);
        IResponse Delete(Guid id);
    }
}
