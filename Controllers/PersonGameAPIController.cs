using David__Dawson_Assignment_3.Models.ViewModels;
using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Class to hold controller and its functions for the API
    /// </summary>
    public class PersonGameAPIController : ControllerBase
    {
        private readonly IPersonRepository _personRepo;
        private readonly IGameRepository _gameRepo;
        private readonly IPersonGameRepository _personGameRepo;

        /// <summary>
        /// instance of controller with passthrough instances of the interfaces
        /// </summary>
        /// <param name="personRepo"></param>
        /// <param name="gameRepo"></param>
        /// <param name="personGameRepo"></param>
        public PersonGameAPIController(IPersonRepository personRepo, IGameRepository gameRepo, IPersonGameRepository personGameRepo)
        {
            _personRepo = personRepo;
            _gameRepo = gameRepo;
            _personGameRepo = personGameRepo;
        }

        /// <summary>
        /// Post method for adding a game to a person
        /// </summary>
        /// <param name="personID"></param>
        /// <param name="gameID"></param>
        /// <returns>adds game to person through API</returns>
        [HttpPost("create")]
        public IActionResult Post([FromForm] int personID, [FromForm] int gameID)
        {
            var personGameRating = _personGameRepo.Create(personID, gameID);

            //Removing circular references
            personGameRating?.Person?.GameRating.Clear();
            personGameRating?.Game?.PersonRating.Clear();

            return CreatedAtAction("Get", new { ID = personGameRating?.personGameID }, personGameRating);
        }

        /// <summary>
        /// put to update game entry to assign rating through API
        /// </summary>
        /// <param name="personID"></param>
        /// <param name="personGameID"></param>
        /// <param name="Rating"></param>
        /// <returns>rating to game entry</returns>
        [HttpPut("assignrating")]
        public IActionResult Put([FromForm] int personID, [FromForm] int personGameID, [FromForm] string Rating)
        {
            _personGameRepo.UpdateGameRating(personGameID, Rating);

            return NoContent();
        }

        /// <summary>
        /// deleting whole entry from person
        /// </summary>
        /// <param name="personID"></param>
        /// <param name="personGameID"></param>
        /// <returns>deleted entry</returns>
        [HttpDelete("delete")]
        public IActionResult Delete([FromForm] int personID, [FromForm] int personGameID)
        {
            _personGameRepo.Remove(personID, personGameID);
            return NoContent();
        }

        /// <summary>
        /// additonal function
        /// </summary>
        /// <returns>displays list of people with game they are play and the rating, should be in order by last name</returns>
        [HttpGet("playthroughs")]
        public IActionResult Get()
        {
            
            var person = _personRepo.ReadAll();
            var personGameList =
            _personGameRepo.ReadAll();
            var model = from x in person
                        join y in personGameList
                        on x.personID equals y.personID
                        orderby x.LastName, x.FirstName
                        select new GameListVM
                        {
                            Person = x.FirstName + " " + x.LastName,
                            Game = y.Game!.Name,
                            Rating = y.Rating
                        };

            return Ok(model);
        }
    }
}
