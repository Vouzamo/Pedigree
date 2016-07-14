using Microsoft.EntityFrameworkCore;
using System;
using Vouzamo.Command.Interfaces;
using Vouzamo.EntityFramework;
using Vouzamo.EntityFramework.Interfaces;
using Vouzamo.Interop;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Pagination;

namespace Pedigree.Core.Commands.CommandHandlers
{
    public class BrowseEntityCommandHandler<TEntity, TViewModel> : ICommandHandler<BrowseEntityCommand<TEntity, TViewModel>, IResponse<PagedResults<TEntity, TViewModel>>> where TEntity : class, IEntity where TViewModel : ISearchable<TEntity>, new()
    {
        protected IMapper Mapper { get; set; }
        protected DbContext Context { get; set; }

        public BrowseEntityCommandHandler(IMapper mapper, DbContext context)
        {
            Mapper = mapper;
            Context = context;
        }

        public virtual IResponse<PagedResults<TEntity, TViewModel>> Handle(BrowseEntityCommand<TEntity, TViewModel> command)
        {
            try
            {
                var results = Context.Set<TEntity>().PaginatedQueryBySpecification(command.Specification, command.ResultsPerPage, command.Page);

                var mappedResults = new PagedResults<TEntity, TViewModel>(Mapper, results);

                return Response<PagedResults<TEntity, TViewModel>>.SuccessResponse(mappedResults);
            }
            catch (Exception ex)
            {
                return Response<PagedResults<TEntity, TViewModel>>.ErrorResponse(Error.FromException(ex));
            }
        }
    }
}
