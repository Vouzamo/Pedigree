using System;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Pagination;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Common.Interfaces
{
    public interface IBasicService<TEntity, TViewModel> : IReadOnlyService<TEntity, TViewModel>, ICreateService<TEntity, TViewModel> where TEntity : IEntity
    {

    }

    public interface IReadOnlyService<TEntity, TViewModel> where TEntity : IEntity
    {
        IResponse<PagedSearchResults<TViewModel>> Search(string term, int page = 1, int resultsPerPage = 1);
        IResponse<PagedResults<TViewModel>> Browse(TViewModel filter, int page = 1, int resultsPerPage = 1);
        IResponse<TViewModel> Get(Guid id);

        IOrderBySpecification<TEntity> BrowseSpecification(TViewModel filter);
        IOrderBySpecification<TEntity> SearchSpecification(string term);
    }

    public interface ICreateService<TEntity, TViewModel> where TEntity : IEntity
    {
        IResponse<TViewModel> Create(TViewModel model);
    }

    public interface IUpdateService<TEntity, TViewModel> where TEntity : IEntity where TViewModel : IEditable
    {
        IResponse<TViewModel> Update(Guid id, TViewModel model);
    }

    public interface IDeleteService<TEntity, TViewModel> where TEntity : IEntity
    {
        IResponse Delete(Guid id);
    }
}
