
using Microsoft.AspNetCore.Mvc;
using Plenty_of_Finch.Models;

namespace Plenty_of_Finch.Controllers.Account
{
    public class RegisterController : Controller
    {

        //Replace Page_Load and returns the view for the register model
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            Validation validation = new Validation();
            string errorMessage = validation.RegistrationValidation(
                model.FirstName,
                model.LastName,
                model.Age,
                model.Gender,
                model.Email,
                model.City,
                model.Phone,
                model.Address,
                model.City,
                model.State,
                model.ZipCode
                );

            if (errorMessage != "")
            {
                model.ErrorMessage = errorMessage;
                return View(model);
            }

            // The newUserID will be assigned when the API call is made to create the user in the database. For now, we will just set it to 0.
            HttpContext.Session.SetInt32("UserID", 0);
            return RedirectToAction("MyProfile", "Profile");
        }
    }
}
