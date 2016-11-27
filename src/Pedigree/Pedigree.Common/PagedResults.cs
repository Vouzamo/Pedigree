using System.Collections.Generic;
using Vouzamo.Pagination;

namespace Pedigree.Common
{
    public class PagedFilterResults<TResult, TFilter> : PagedResults<TResult>
    {
        public TFilter Filter { get; protected set; }

        public PagedFilterResults(IEnumerable<TResult> results, int totalResults, int resultsPerPage, int page, TFilter filter) : base(results, totalResults, resultsPerPage, page)
        {
            Filter = filter;
        }

        public PagedFilterResults(PagedResults<TResult> results, TFilter filter) : this(results.Results, results.TotalResults, results.ResultsPerPage, results.Page, filter)
        {

        }
    }
}
