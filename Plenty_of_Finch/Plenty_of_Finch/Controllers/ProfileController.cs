using Microsoft.AspNetCore.Mvc;
using Plenty_of_Finch.Models;

namespace Plenty_of_Finch.Controllers
{


    /*
     * TODO Add controls to fetch profile from API
     * 
     * 
     */
    public class ProfileController : Controller
    {
        public IActionResult MyProfile()
        {
            MyProfileViewModel model = new MyProfileViewModel();
     
            return View(model);
        }
    }
}
