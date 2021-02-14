using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClinicPortal.Entity.Search.Result;
using ClinicPortal.Entity.Search.Result.Details;

namespace ClinicPortal.Entity
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchResult>> SearchByDefault(string terms);
        Task<DetailsResult> SearchById(string id);
    }
}
