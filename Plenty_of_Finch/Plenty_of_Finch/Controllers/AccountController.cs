using Microsoft.AspNetCore.Mvc;

namespace Plenty_of_Finch.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
