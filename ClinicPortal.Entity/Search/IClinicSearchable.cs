using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicPortal.Entity.Search.Result;

namespace ClinicPortal.Entity.Search
{
    public interface IClinicSearchable
    {
        Task<IEnumerable<SearchResult>> DoSearchAsync(string terms);
    }
}
