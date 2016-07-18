using Pedigree.Common.Interfaces;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Pagination;
using Vouzamo.Command.Interfaces;
using Vouzamo.EntityFramework.Commands;
using System;

namespace Pedigree.Core.Services
{
    public abstract class BasicService<TEntity, TViewModel> : IBasicService<TEntity, TViewModel> where TEntity : IEntity where TViewModel : new()
    {
        protected ICommandDispatcher Dispatcher { get; set; }

        protected BasicService(ICommandDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        public virtual IResponse<PagedSearchResults<TViewModel>> Search(string term, int page = 1, int resultsPerPage = 10)
        {
            var command = new SearchCommand<TViewModel>(term, page, resultsPerPage);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse<PagedResults<TViewModel>> Browse(TViewModel filter, int page = 1, int resultsPerPage = 10)
        {
            var command = new BrowseCommand<TViewModel>(filter, page, resultsPerPage);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse<TViewModel> Get(Guid id)
        {
            var command = new GetCommand<TViewModel>(id);
            var result = Dispatcher.Invoke(command);

            return result;
        }

        public virtual IResponse<TViewModel> Create(TViewModel model)
        {
            var command = new PostCommand<TViewModel>(model);
            var result = Dispatcher.Invoke(command);

            return result;
        }
    }
}
