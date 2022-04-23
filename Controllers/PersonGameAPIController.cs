using David__Dawson_Assignment_3.Models.ViewModels;
using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonGameAPIController : ControllerBase
    {
        private readonly IPersonRepository _personRepo;
        private readonly IGameRepository _gameRepo;
        private readonly IPersonGameRepository _personGameRepo;

        public PersonGameAPIController(IPersonRepository personRepo, IGameRepository gameRepo, IPersonGameRepository personGameRepo)
        {
            _personRepo = personRepo;
            _gameRepo = gameRepo;
            _personGameRepo = personGameRepo;
        }

        [HttpPost("create")]
        public IActionResult Post([FromForm] int personID, [FromForm] int gameID)
        {
            var personGameRating = _personGameRepo.Create(personID, gameID);

            //Removing circular references
            personGameRating?.Person?.GameRating.Clear();
            personGameRating?.Game?.PersonRating.Clear();

            return CreatedAtAction("Get", new { ID = personGameRating?.personGameID }, personGameRating);
        }

        [HttpPut("assignrating")]
        public IActionResult Put([FromForm] int personID, [FromForm] int personGameID, [FromForm] string Rating)
        {
            _personGameRepo.UpdateGameRating(personGameID, Rating);

            return NoContent();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromForm] int personID, [FromForm] int personGameID)
        {
            _personGameRepo.Remove(personID, personGameID);
            return NoContent();
        }

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
