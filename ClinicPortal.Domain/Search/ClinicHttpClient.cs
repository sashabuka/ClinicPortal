using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClinicPortal.Entity.Convertor;
using ClinicPortal.Entity.Search;
using ClinicPortal.Entity.Search.Result;
using ClinicPortal.Entity.Utils;
using Newtonsoft.Json;

namespace ClinicPortal.Domain.Search
{
    public class ClinicHttpClient : IClinicSearchable
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl;
        public ClinicHttpClient(string baseClinicUrl)
        {
            httpClient = new HttpClient();
            baseUrl = baseClinicUrl;
        }

        public async Task<IEnumerable<SearchResult>> DoSearchAsync(string terms)
        {
            var url = new ClinicUrlBuilder(baseUrl)
                .Search()
                .WithParams()
                .AddTerms(terms)
                .And()
                .AddMaxList(10)
                .Build();

            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            try
            {
                var res = SearchResultConvertor.Get(result);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
