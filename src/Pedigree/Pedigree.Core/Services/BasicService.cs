using Pedigree.Common.Interfaces;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Pagination;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Vouzamo.Specification.Interfaces;
using Vouzamo.Interop;
using Vouzamo.EntityFramework;

namespace Pedigree.Core.Services
{
    public abstract class BasicService<TEntity, TViewModel> : IBasicService<TEntity, TViewModel> where TEntity : class, IBasicEntity where TViewModel : IEditable
    {
        protected IMapper Mapper { get; set; }
        protected DbContext Context { get; set; }

        protected BasicService(IMapper mapper, DbContext context)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual IResponse<PagedSearchResults<TViewModel>> Search(string term, int page = 1, int resultsPerPage = 10)
        {
            try
            {
                IOrderBySpecification<TEntity> specification = SearchSpecification(term);

                IOrderedQueryable<TEntity> results = specification.SatisfiesMany(Context.Set<TEntity>());

                var pagedResults = results.ToPagedResults(resultsPerPage, page);

                var mappedResults = PagedResults<TViewModel>.MapFrom<TEntity, TViewModel>(pagedResults, Mapper);

                var searchResults = new PagedSearchResults<TViewModel>(term, mappedResults);

                return Response<PagedSearchResults<TViewModel>>.SuccessResponse(searchResults);
            }
            catch(Exception ex)
            {
                return Response<PagedSearchResults<TViewModel>>.ErrorResponse(Error.FromException(ex));
            }
            
        }

        public virtual IResponse<PagedResults<TViewModel>> Browse(TViewModel filter, int page = 1, int resultsPerPage = 10)
        {
            try
            {
                var specification = BrowseSpecification(filter);

                var pagedResults = Context.Set<TEntity>().PaginatedQueryBySpecification(specification, resultsPerPage, page);

                var mappedResults = PagedResults<TViewModel>.MapFrom<TEntity, TViewModel>(pagedResults, Mapper);

                return Response<PagedResults<TViewModel>>.SuccessResponse(mappedResults);
            }
            catch (Exception ex)
            {
                return Response<PagedResults<TViewModel>>.ErrorResponse(Error.FromException(ex));
            }
        }

        public virtual IResponse<TViewModel> Get(Guid id)
        {
            try
            {
                // Persistance
                TEntity entity = Context.Set<TEntity>().SingleOrDefault(x => x.Id == id);

                if (entity == null)
                {
                    throw new Exception(string.Format("Entity (.Id = '{0}') not found in database", id));
                }

                // Mapping
                TViewModel model = Mapper.Map<TEntity, TViewModel>(entity);

                return Response<TViewModel>.SuccessResponse(model);
            }
            catch (Exception ex)
            {
                return Response<TViewModel>.ErrorResponse(Error.FromException(ex));
            }
        }

        public virtual IResponse<TViewModel> Create(TViewModel model)
        {
            try
            {
                // Generate Id
                model.Id = Guid.NewGuid();

                // Mapping
                TEntity entity = Mapper.Map<TViewModel, TEntity>(model);

                // Persistance
                Context.Entry(entity).State = EntityState.Added;
                Context.SaveChanges();

                return Response<TViewModel>.SuccessResponse(model);
            }
            catch (Exception ex)
            {
                return Response<TViewModel>.ErrorResponse(Error.FromException(ex));
            }
        }

        public abstract IOrderBySpecification<TEntity> BrowseSpecification(TViewModel filter);

        public abstract IOrderBySpecification<TEntity> SearchSpecification(string term);
    }
}
