using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Database;
using ProfilesAPI.Models;
using System.Data;

namespace ProfilesAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {


        //Used for searching function
        [HttpGet]
        public IActionResult GetAllProfiles(string state, string commitment, string ageRange, string Wingspan)
        {
            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();
            DataSet profilesDataSet;

            if (!string.IsNullOrEmpty(state))
            {
                profilesDataSet = databaseConnection.SearchByState(state);
            }
            else if (!string.IsNullOrEmpty(commitment))
            {
                profilesDataSet = databaseConnection.SearchByCommitment(commitment);
            }
            else if (!string.IsNullOrEmpty(ageRange))
            {
                profilesDataSet = databaseConnection.SearchByAgeRange(ageRange);
            }
            else if (!string.IsNullOrEmpty(Wingspan))
            {
                profilesDataSet = databaseConnection.SearchByWingSpan(Wingspan);
            }
            else
            {
                profilesDataSet = databaseConnection.GetAllBirdProfiles();
            }

            //This ensure that if there are no profiles in the database, the API will return a 204 No Conten
            if (profilesDataSet == null || profilesDataSet.Tables.Count == 0)
            {
                return NoContent();
            }

            List<BirdProfiles> profiles = new List<BirdProfiles>();

            foreach (DataRow row in profilesDataSet.Tables[0].Rows)
            {
                BirdProfiles profile = new BirdProfiles();
                profile.BirdID = Convert.ToInt32(row["BirdID"]);
                profile.FirstName = row["FirstName"].ToString();
                profile.LastName = row["LastName"].ToString();
                profile.Age = Convert.ToInt32(row["Age"]);
                profile.City = row["City"].ToString();
                profile.State = row["State"].ToString();
                profile.Species = row["Species"].ToString();
                profile.ProfileImage = row["ProfileImage"].ToString();
                profiles.Add(profile);
            }

            return Ok(profiles);
        }


        //Returns Profile based on ID, if full is true, it will return the full profile, otherwise it will return the public profile
        [HttpGet("{id}")]
        public IActionResult GetProfile(int id, bool full)
        {
            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();
            DataSet profilesDataSet;


            // If full is true, get the full profile, otherwise get the public profile
            if (full)
            {
                profilesDataSet = databaseConnection.GetBirdProfileFull(id);
            }
            else
            {
                profilesDataSet = databaseConnection.GetBirdProfilePublic(id);
            }


            //Makes sure that if there is no profile with ID API will return 404
            if (profilesDataSet == null || profilesDataSet.Tables.Count == 0)
            {
                return NotFound();
            }



            DataRow row = profilesDataSet.Tables[0].Rows[0];

            BirdProfiles profile = new BirdProfiles();
            profile.BirdID = Convert.ToInt32(row["BirdID"]);
            profile.FirstName = row["FirstName"].ToString();
            profile.LastName = row["LastName"].ToString();
            profile.Age = Convert.ToInt32(row["Age"]);
            profile.Gender = row["Gender"].ToString();
            profile.City = row["City"].ToString();
            profile.State = row["State"].ToString();
            profile.ProfileImage = row["ProfileImage"].ToString();
            profile.Biography = row["Biography"].ToString();
            profile.Goals = row["Goals"].ToString();
            profile.CommitmentType = row["CommitmentType"].ToString();
            profile.AgeRange = row["AgeRange"].ToString();
            profile.Species = row["Species"].ToString();
            profile.Wingspan = row["WingSpan"].ToString();
            profile.FavoriteSeed = row["FavoriteSeed"].ToString();
            profile.Plumage = row["Plumage"].ToString();
            profile.Occupation = row["Occupation"].ToString();
            profile.TotalLikes = Convert.ToInt32(row["TotalLikes"]);

            if (full)
            {
                profile.Email = row["Email"].ToString();
                profile.PhoneNumber = row["PhoneNumber"].ToString();
                profile.HomeAddress = row["HomeAddress"].ToString();
            }

            return Ok(profile);
        }

        [HttpPost]
        public IActionResult CreateProfile([FromBody] ProfileCreateRequest request)
        {
            if (request == null || request.BirdID == 0)
            {
                return BadRequest("Invalid profile input.");

            }

            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();


            int newProfileID = databaseConnection.CreateDatingProfile(
                request.BirdID,
                request.Biography,
                request.ProfileImage,
                request.Species,
                request.Wingspan,
                request.CommitmentType,
                request.Goals,
                request.Plumage,
                request.AgeRange,
                request.Occupation,
                request.FavoriteSeed,
                request.IsVisible
            );



            if (newProfileID == -1)
            {
                return StatusCode(500, "Failed to create profile.");
            }

            return Ok(newProfileID);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, [FromBody] ProfileUpdateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid profile input.");
            }
            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();


            bool updateSuccess = databaseConnection.UpdateBirdProfile(
                id,
                request.Biography,
                request.ProfileImage,
                request.Species,
                request.Wingspan,
                request.CommitmentType,
                request.Goals,
                request.Plumage,
                request.AgeRange,
                request.Occupation,
                request.FavoriteSeed,
                request.IsVisible
            );

            if (!updateSuccess)
            {
                return StatusCode(500, "Failed to update profile.");
            }

            return Ok("Profile updated successfully.");
        }

        [HttpGet("id/viewcount")]
        public IActionResult GetViewCount(int id)
        {
            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();
            int viewCount = databaseConnection.GetProfileViewCount(id);
            return Ok(viewCount);

        }

        [HttpPost("{id}/logview")]
        public IActionResult LogView(int id, int viewerID)
        {
            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();
            bool success = databaseConnection.LogProfileView(viewerID, id);

            if (!success)
            {
                return StatusCode(500, "Failed to log profile view.");
            }

            return Ok("View logged.");
        }


        [HttpGet("checkaccepteddate")]
        public IActionResult CheckAcceptedDate(int userID, int targetID)
        {
            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();
            bool hasAccepted = databaseConnection.CheckAcceptedDateRequest(userID, targetID);
            return Ok(hasAccepted);
        }

        [HttpGet("checkinnest")]
        public IActionResult CheckInNest(int userID, int targetID)
        {
            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();
            bool inNest = databaseConnection.CheckBirdInNest(userID, targetID);
            return Ok(inNest);
        }


        [HttpPost("addtonest")]
        public IActionResult AddToNest(int userID, int targetID)
        {
            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();

            bool alreadyInNest = databaseConnection.CheckBirdInNest(userID, targetID);
            if (alreadyInNest)
            {
                return Ok("Already in nest.");
            }

            bool added = databaseConnection.AddBirdToNest(userID, targetID);
            if (added)
            {
                databaseConnection.IncrementTotalLikes(targetID);
                return Ok("Added to nest.");
            }

            return StatusCode(500, "Failed to add to nest.");
        }

        [HttpPost("daterequest")]
        public IActionResult SendDateRequest(int senderID, int receiverID)
        {
            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();

            bool alreadySent = databaseConnection.CheckExistingDateRequest(senderID, receiverID);
            if (alreadySent)
            {
                return Ok("Request already sent.");
            }

            bool success = databaseConnection.DateRequest(senderID, receiverID);
            if (!success)
            {
                return StatusCode(500, "Failed to send date request.");
            }

            return Ok("Date request sent.");
        }

        [HttpGet("checkdaterequest")]
        public IActionResult CheckDateRequest(int senderID, int receiverID)
        {
            ProfileDatabaseConnection databaseConnection = new ProfileDatabaseConnection();
            bool requestExists = databaseConnection.CheckExistingDateRequest(senderID, receiverID);
            return Ok(requestExists);
        }

    }
}


