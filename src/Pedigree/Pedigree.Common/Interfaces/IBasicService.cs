using System;
using Vouzamo.EntityFramework.Interfaces;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Pagination;

namespace Pedigree.Common.Interfaces
{
    public interface IBasicService<TEntity, TViewModel> : IReadOnlyService<TEntity, TViewModel>, ICreateService<TEntity, TViewModel> where TEntity : IEntity where TViewModel : ISearchable<TEntity>
    {

    }

    public interface IReadOnlyService<TEntity, TViewModel> where TEntity : IEntity where TViewModel : ISearchable<TEntity>
    {
        IResponse<PagedSearchResults<TViewModel>> Search(string term, int page = 1, int resultsPerPage = 1);
        IResponse<PagedResults<TViewModel>> Browse(TViewModel filter, int page = 1, int resultsPerPage = 1);
        IResponse<TViewModel> Get(Guid id);
    }

    public interface ICreateService<TEntity, TViewModel> where TEntity : IEntity where TViewModel : ISearchable<TEntity>
    {
        IResponse<TViewModel> Create(TViewModel model);
    }

    public interface IUpdateService<TEntity, TViewModel> where TEntity : IEntity where TViewModel : ISearchable<TEntity>
    {
        IResponse<TViewModel> Update(Guid id, TViewModel model);
    }

    public interface IDeleteService<TEntity, TViewModel> where TEntity : IEntity where TViewModel : ISearchable<TEntity>
    {
        IResponse Delete(Guid id);
    }
}
