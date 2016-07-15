using Pedigree.Common.Interfaces;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Pagination;
using Vouzamo.Command.Interfaces;
using Vouzamo.EntityFramework.Commands;
using System;
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

        public virtual IResponse<PagedSearchResults<TViewModel>> Search(string term, int page = 1, int resultsPerPage = 10)
        {
            var command = new SearchEntityCommand<TViewModel>(term, page, resultsPerPage);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse<PagedResults<TViewModel>> Browse(TViewModel filter, int page = 1, int resultsPerPage = 10)
        {
            var command = new BrowseEntityCommand<TViewModel>(filter, page, resultsPerPage);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse<TViewModel> Get(Guid id)
        {
            var command = new GetEntityCommand<TViewModel>(id);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse<TViewModel> Create(TViewModel model)
        {
            var command = new PostEntityCommand<TViewModel>(model);
            var result = Dispatcher.Invoke(command);

            return result;
        }
    }
}
