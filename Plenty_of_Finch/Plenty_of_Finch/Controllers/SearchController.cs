using Microsoft.AspNetCore.Mvc;
using Plenty_of_Finch.Helpers;
using Plenty_of_Finch.Models;
using Plenty_of_Finch.Models.Search;

namespace Plenty_of_Finch.Controllers
{
    public class SearchController : Controller
    {

        [HttpGet]

        public IActionResult Search()
        {



            /*
             *              * TODO Add controls to fetch search results from API
             * 
             * 
             */
            SearchViewModel model = new SearchViewModel();
            model.StateOptions = StateList.GetStates();

            return View(model);
        }
    }
}

