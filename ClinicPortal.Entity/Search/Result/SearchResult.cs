using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ClinicPortal.Entity.Convertor;

namespace ClinicPortal.Entity.Search.Result
{
    public class SearchResult
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public string Address { get; set; }
    }
}
