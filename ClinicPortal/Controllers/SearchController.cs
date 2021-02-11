using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ClinicPortal.Domain.Search;
using ClinicPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Http.Logging;

namespace ClinicPortal.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View(SearchViewModel.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([FromForm] SearchViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(SearchViewModel.Empty);
                var client = new ClinicHttpClient("https://clinicaltables.nlm.nih.gov/api/npi_idv/v3");
                var result = await client.DoSearchAsync(viewModel.SearchString);
                viewModel.SearchString = string.Empty;
                viewModel.Result = result.Select(item=> new SearchResultViewModel()
                {
                    Id = item.Id,
                    Address = item.Address,
                    Specialty = item.Specialty,
                    Name = item.FullName
                });

                return View(viewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult Details()
        {
            return View();
        }
    }

}
