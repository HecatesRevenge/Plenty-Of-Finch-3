using Microsoft.AspNetCore.Mvc;
using Plenty_of_Finch.DBConnection;
using System.Data;



namespace Plenty_of_Finch.Controllers.MyNest
{
    public class MyNestController : Controller
    {


        public IActionResult DisplayMyNestList()
        {

            //TODO check to make sure this is the proper way of getting userID
            int currentUserID = HttpContext.Session.GetInt32("UserID") ?? 0;
            DataBaseConnection dbConnection=new DataBaseConnection();
            DataSet dsNest=dbConnection.GetMyNest(currentUserID);
            //Check to make sure this can be displayed properly in the view, if not we may need to create a MyNestViewModel and convert the dataset to a list of MyNestViewModel objects
            return View(dsNest);

        }

        
        }
    }
}
