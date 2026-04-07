using Microsoft.AspNetCore.Mvc;

namespace apiTesting.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index2()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index2(int x, int y)
        {
            int z = x + y;
            ViewBag.numbers = z;
            return View();
        }
        [HttpGet("Login/Index2Check")]
        public IActionResult Index2(string username, string password)
        {
            Databasestuff db = new Databasestuff();
            int trueorfalse = db.checkLogin(username, password);
            ViewBag.check = trueorfalse;    
            return View();
        }
    }
}
