using System;
using System.Collections.Generic;
using System.Linq;
using ClinicPortal.Entity.Search.Result;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClinicPortal.Entity.Convertor
{
    public class SearchResultConvertor: IClinicApiConvertor<IEnumerable<SearchResult>>
    {
        private const int DATA_INDEX = 3;

        private const int NAME_INDEX = 0;
        private const int ID_INDEX = 1;
        private const int SPEC_INDEX = 2;
        private const int ADDRESS_INDEX = 3;

        public static IEnumerable<SearchResult> Get(string input)
        {
            var response = JArray.Parse(input);
            var result = new List<SearchResult>();

            if (response.Count <= DATA_INDEX) return null;
            foreach (var item in response[DATA_INDEX].Children())
            {
                if (item.Count() <= DATA_INDEX) continue;
                var properties = item as JArray;

                if (properties == null) continue;

                result.Add(new SearchResult()
                {
                    FullName = properties[NAME_INDEX].Value<string>(),
                    Id = properties[ID_INDEX].Value<string>(),
                    Address = properties[ADDRESS_INDEX].Value<string>(),
                    Specialty = properties[SPEC_INDEX].Value<string>()
                });
            }

            return result;
        }

        public IEnumerable<SearchResult> Execute(string input)
        {
            return Get(input);
        }
    }
}
