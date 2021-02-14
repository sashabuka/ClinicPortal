using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicPortal.Entity.Search.Result.Details;

namespace ClinicPortal.Models
{
    public class DetailsViewModel
    {
        public DetailsResult Details { get; }

        public DetailsViewModel(DetailsResult details)
        {
            Details = details;
        }
    }
}
