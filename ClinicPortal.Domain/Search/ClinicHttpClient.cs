using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClinicPortal.Entity.Convertor;
using ClinicPortal.Entity.Search;
using ClinicPortal.Entity.Search.Result;
using ClinicPortal.Entity.Search.Result.Details;
using ClinicPortal.Entity.Utils;
using Newtonsoft.Json;

namespace ClinicPortal.Domain.Search
{
    public class ClinicHttpClient : IClinicSearchable
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly IClinicApiConvertor<IEnumerable<SearchResult>> _searchResultConvertor;
        private readonly IClinicApiConvertor<DetailsResult> _detailsApiConvertor;

        public ClinicHttpClient(string baseClinicUrl, 
            IClinicApiConvertor<IEnumerable<SearchResult>> searchResultConvertor, 
            IClinicApiConvertor<DetailsResult> detailsApiConvertor)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseClinicUrl;
            _searchResultConvertor = searchResultConvertor;
            _detailsApiConvertor = detailsApiConvertor;
        }

        public async Task<IEnumerable<SearchResult>> DoSearchAsync(string terms)
        {
            var url = new ClinicUrlBuilder(_baseUrl)
                .Search()
                .WithParams()
                .AddTerms(terms)
                .And()
                .AddMaxList(10)
                .Build();

            var response = await _httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var res = _searchResultConvertor.Execute(result);
            return res;
        }

        public async Task<DetailsResult> DoDetailedSearch(string id)
        {
            var url = new ClinicUrlBuilder(_baseUrl)
                .Search()
                .WithParams()
                .AddTerms(id)
                .And()
                .AddSearchFields(new[] { "NPI" })
                .And()
                .AddFullExtendedFields()
                .Build();

            var response = await _httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var res = _detailsApiConvertor.Execute(result);
            return res;
        }
    }
}
