using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicPortal.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View(SearchModel.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([FromForm] SearchModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(SearchModel.Empty);
                model.SearchString = string.Empty;
                model.Result = new List<SearchResultModel>()
                {
                    new SearchResultModel() {Name = "Test1"},
                    new SearchResultModel() {Name = "Test2"}
                };

                return View(model);
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

    public class SearchResultModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class SearchModel
    {
        [Required(ErrorMessage = "Please enter search term")]
        public string SearchString { get; set; }

        public IEnumerable<SearchResultModel> Result { get; set; }

        [JsonIgnore] public static SearchModel Empty => new SearchModel();
    }
}
