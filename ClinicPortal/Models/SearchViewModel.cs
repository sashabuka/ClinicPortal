using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClinicPortal.Controllers;
using Newtonsoft.Json;

namespace ClinicPortal.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Please enter search term")]
        public string SearchString { get; set; }

        public IEnumerable<SearchResultViewModel> Result { get; set; }

        [JsonIgnore]
        public static SearchViewModel Empty => new SearchViewModel();
    }
}