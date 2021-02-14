using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicPortal.Entity;
using ClinicPortal.Entity.Search;
using ClinicPortal.Entity.Search.Result;
using ClinicPortal.Entity.Search.Result.Details;

namespace ClinicPortal.Domain.Service
{
    public class ClinicSearchService : ISearchService
    {
        private readonly IClinicSearchable _httpClient;

        public ClinicSearchService(IClinicSearchable httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SearchResult>> SearchByDefault(string terms)
        {
            return await _httpClient.DoSearchAsync(terms);
        }

        public async Task<DetailsResult> SearchById(string id)
        {
            return await _httpClient.DoDetailedSearch(id);
        }
    }
}
