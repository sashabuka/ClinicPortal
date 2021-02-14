using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicPortal.Entity.Search.Result;
using ClinicPortal.Entity.Search.Result.Details;

namespace ClinicPortal.Entity.Search
{
    public interface IClinicSearchable
    {
        Task<IEnumerable<SearchResult>> DoSearchAsync(string terms);
        Task<DetailsResult> DoDetailedSearch(string id);
    }
}
