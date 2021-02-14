using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ClinicPortal.Domain.Search;
using ClinicPortal.Entity;
using ClinicPortal.Entity.Search;
using ClinicPortal.Entity.Search.Result;
using ClinicPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Http.Logging;

namespace ClinicPortal.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

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
                var result = await _searchService.SearchByDefault(viewModel.SearchString);
                ClearSearchString(viewModel);
                UpdateViewModel(viewModel, result);
                return View(viewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private static void ClearSearchString(SearchViewModel viewModel)
        {
            viewModel.SearchString = string.Empty;
        }

        private static void UpdateViewModel(SearchViewModel viewModel, IEnumerable<SearchResult> result)
        {
            viewModel.Result = result.Select(item => new SearchResultViewModel()
            {
                Id = item.Id,
                Address = item.Address,
                Specialty = item.Specialty,
                Name = item.FullName
            });
        }

        public async Task<ActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var result = await _searchService.SearchById(id);
                return View(new DetailsViewModel(result));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
    }

}
