using Microsoft.AspNetCore.Mvc;
using Plenty_of_Finch.Models;

namespace Plenty_of_Finch.Controllers
{
    public class DatingProfileController : Controller
    {
        [HttpGet]
        public IActionResult DatingProfile()
        {
            /*
             *              * TODO Add controls to fetch dating profile data from API
             * 
             * 
             */
            DatingProfileViewModel model = new DatingProfileViewModel();
            return View(model);
        }
    }
}
