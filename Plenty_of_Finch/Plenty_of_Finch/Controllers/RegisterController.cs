using Microsoft.AspNetCore.Mvc;
using Plenty_of_Finch.DBConnections;
using Plenty_of_Finch.Helpers;
using Plenty_of_Finch.Models;

using Plenty_of_Finch.Validators;

namespace Plenty_of_Finch.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            model.SecurityQuestionOptions = SecurityQuestions.GetSecurityQuestion();
            return View(model);
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            // Re-populate the dropdown options (they don't survive the POST).
            model.SecurityQuestionOptions = SecurityQuestions.GetSecurityQuestion();

            Validations validator = new Validations();

            string errorMessage = validator.RegistrationValidation(
                model.FirstName, model.LastName, model.Age, model.Gender,
                model.Email, model.City, model.State, model.Username, model.Password);

            if (errorMessage != "")
            {
                model.ErrorMessage = errorMessage;
                return View(model);
            }

            string securityError = validator.SecurityQuestionValidation(
                model.SecurityQuestion1, model.SecurityAnswer1,
                model.SecurityQuestion2, model.SecurityAnswer2,
                model.SecurityQuestion3, model.SecurityAnswer3);

            if (securityError != "")
            {
                model.ErrorMessage = securityError;
                return View(model);
            }

            AuthenticationConnection authDataBase = new AuthenticationConnection();

            int newUserID = authDataBase.CreateAccount(
                model.FirstName,
                model.LastName,
                model.City,
                model.State,
                model.Age,
                model.Gender,
                model.Username,
                model.Password,
                model.Email,
                model.Phone,
                model.Address,
                model.SecurityQuestion1,
                model.SecurityAnswer1,
                model.SecurityQuestion2,
                model.SecurityAnswer2,
                model.SecurityQuestion3,
                model.SecurityAnswer3
            );

            if (newUserID > 0)
            {
                HttpContext.Session.SetInt32("UserID", newUserID);
                return RedirectToAction("MyProfile", "Profile");
            }
            else if (newUserID == -1)
            {
                model.ErrorMessage = "Username already exists. Please choose a different username.";
                return View(model);
            }
            else
            {
                model.ErrorMessage = "An error occurred while creating your account. Please try again.";
                return View(model);
            }
        }



    }
}
