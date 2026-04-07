using Microsoft.AspNetCore.Mvc;
using Plenty_of_Finch.DBConnections;

namespace Plenty_of_Finch.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        

        //What does this code do? 
        [HttpGet("Login/Math")]
        public IActionResult Math(int x, int y)
        {
            ViewBag.numbers = x + y;
            return View("Login");
        }

        [HttpGet("Login/LoginCheck")]
        public IActionResult LoginCheck(string username, string password)
        {
            Databasestuff db = new Databasestuff();
            int trueorfalse = db.checkLogin(username, password);
            ViewBag.check = trueorfalse;
            return View("Login");
        }
    }
}
