using Pedigree.Common.Interfaces;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Pagination;
using Vouzamo.Command.Interfaces;
using Vouzamo.EntityFramework.Commands;
using Pedigree.Core.Commands;
using System;
using Vouzamo.Specification.Interfaces;
using Vouzamo.EntityFramework.Interfaces;

namespace Pedigree.Core.Services
{
    public abstract class BasicService<TEntity, TViewModel> : IBasicService<TEntity, TViewModel> where TEntity : IEntity where TViewModel : ISearchable<TEntity>, new()
    {
        protected ICommandDispatcher Dispatcher { get; set; }

        protected BasicService(ICommandDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        public virtual IResponse<PagedSearchResults<TEntity, TViewModel>> Search(string term, int page = 1, int resultsPerPage = 10)
        {
            var command = new SearchEntityCommand<TEntity, TViewModel>(term, page, resultsPerPage);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse<PagedResults<TEntity, TViewModel>> Browse(IOrderBySpecification<TEntity> specification, int page = 1, int resultsPerPage = 10)
        {
            var command = new BrowseEntityCommand<TEntity, TViewModel>(specification, page, resultsPerPage);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse<TViewModel> Get(Guid id)
        {
            var command = new GetEntityCommand<TEntity, TViewModel>(id);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse<TViewModel> Create(TViewModel dog)
        {
            var command = new PostEntityCommand<TEntity, TViewModel>(dog);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse<TViewModel> Update(TViewModel dog)
        {
            var command = new PutEntityCommand<TEntity, TViewModel>(dog.Id, dog);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse Delete(Guid id)
        {
            var command = new DeleteEntityCommand<TEntity>(id);
            var result = Dispatcher.Invoke(command);

            // Remove references to the id

            return result;
        }
    }
}
