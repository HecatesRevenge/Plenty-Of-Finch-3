using Microsoft.AspNetCore.Mvc;
using Plenty_of_Finch.DBConnections;
using Plenty_of_Finch.Models;
using Plenty_of_Finch.Models.Login;

namespace Plenty_of_Finch.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();

            // Check for Remember Me cookie.
            if (Request.Cookies.ContainsKey("PlentyOfFinch_Username"))
            {
                model.Username = Request.Cookies["PlentyOfFinch_Username"];
                model.RememberMe = true;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                model.ErrorMessage = "Username and password are required.";
                return View(model);
            }

            AuthenticationConnection authDataBase = new AuthenticationConnection();
            int userID = authDataBase.VerifyLogin(model.Username, model.Password);



            /*
             *Stores userID in session
             *Creates a new cookies if remeber me is check
             *will expire in 10 days.
             *adds cooking to the response based on username and options
             
             */
            if (userID > 0)
            {

                HttpContext.Session.SetInt32("UserID", userID);


                if (model.RememberMe)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTimeOffset.Now.AddDays(30);
                    options.HttpOnly = true;
                    options.IsEssential = true;
                    Response.Cookies.Append("PlentyOfFinch_Username", model.Username, options);
                }
                else
                {

                    Response.Cookies.Delete("PlentyOfFinch_Username");
                }

                return RedirectToAction("Search", "Search");
            }
            else
            {
                model.ErrorMessage = "Invalid username or password.";
                model.Password = "";
                return View(model);
            }
        }


        //Clears session and cookue if requested and redirects to login page
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }


        [HttpGet]
        public IActionResult DeleteCookie()
        {
            Response.Cookies.Delete("PlentyOfFinch_Username");
            return RedirectToAction("Login", "Login");
        }


        //Redirects to forgetpassword page and starts at step 1 of the process
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ForgotPasswordViewModel model = new ForgotPasswordViewModel();
            model.Step = 1;
            return View(model);
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            AuthenticationConnection authDataBase = new AuthenticationConnection();

            //Simple if statments to help user along in resetting their password.

            if (model.Step == 1)
            {
                if (string.IsNullOrEmpty(model.Username))
                {
                    model.ErrorMessage = "Please enter your username.";
                    return View(model);
                }

                System.Data.DataSet ds = authDataBase.GetSecurityQuestion(model.Username);

                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    model.ErrorMessage = "Username not found.";
                    return View(model);
                }

                model.SecurityQuestion = ds.Tables[0].Rows[0]["Question"].ToString();
                model.Step = 2;
                return View(model);
            }


            if (model.Step == 2)
            {
                if (string.IsNullOrEmpty(model.SecurityAnswer))
                {
                    model.ErrorMessage = "Please enter your answer.";
                    return View(model);
                }

                bool correct = authDataBase.VerifySecurityAnswer(
                    model.Username, model.SecurityQuestion, model.SecurityAnswer);

                if (!correct)
                {
                    model.ErrorMessage = "Incorrect answer. Please try again.";
                    return View(model);
                }

                model.Step = 3;
                return View(model);
            }


            if (model.Step == 3)
            {
                if (string.IsNullOrEmpty(model.NewPassword) || string.IsNullOrEmpty(model.ConfirmPassword))
                {
                    model.ErrorMessage = "Please enter and confirm your new password.";
                    return View(model);
                }

                if (model.NewPassword != model.ConfirmPassword)
                {
                    model.ErrorMessage = "Passwords do not match.";
                    return View(model);
                }

                bool success = authDataBase.ResetPassword(model.Username, model.NewPassword);

                if (success)
                {
                    model.SuccessMessage = "Password reset successfully! You can now log in.";
                    model.Step = 4;
                }
                else
                {
                    model.ErrorMessage = "Failed to reset password. Please try again.";
                }

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotUsername()
        {
            ForgotUsernameViewModel model = new ForgotUsernameViewModel();
            model.Step = 1;
            return View(model);
        }


        //Similar to forgot password but with email instead of username and security question instead of answer.
        [HttpPost]
        public IActionResult ForgotUsername(ForgotUsernameViewModel model)
        {
            AuthenticationConnection authDataBase = new AuthenticationConnection();

            if (model.Step == 1)
            {
                if (string.IsNullOrEmpty(model.Email))
                {
                    model.ErrorMessage = "Please enter your email address.";
                    return View(model);
                }

                System.Data.DataSet ds = authDataBase.GetSecurityQuestionByEmail(model.Email);

                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    model.ErrorMessage = "No account found with that email address.";
                    return View(model);
                }

                model.SecurityQuestion = ds.Tables[0].Rows[0]["Question"].ToString();
                model.Step = 2;
                return View(model);
            }

            if (model.Step == 2)
            {
                if (string.IsNullOrEmpty(model.SecurityAnswer))
                {
                    model.ErrorMessage = "Please enter your answer.";
                    return View(model);
                }

                bool correct = authDataBase.VerifySecurityAnswerByEmail(
                    model.Email, model.SecurityQuestion, model.SecurityAnswer);

                if (!correct)
                {
                    model.ErrorMessage = "Incorrect answer. Please try again.";
                    return View(model);
                }

                model.RetrievedUsername = authDataBase.GetUsernameByEmail(model.Email);
                model.SuccessMessage = "Your username is: " + model.RetrievedUsername;
                model.Step = 3;
                return View(model);
            }

            return View(model);
        }
    }

}

