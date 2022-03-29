using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    /// <summary>
    /// Class to hold controller and its functions
    /// </summary>
    public class GameController : Controller
    {
        private IPersonRepository _personRepo;
        private IGameRepository _gameRepo;

        /// <summary>
        /// Instance of controller containing passthrough variables
        /// </summary>
        /// <param name="personRepo">will be set to the private variable</param>
        /// <param name="gameRepo">will be set to the private variable</param>
        public GameController(IPersonRepository personRepo, IGameRepository gameRepo)
        {
            _personRepo = personRepo;
            _gameRepo = gameRepo;
        }

        /// <summary>
        /// Action Result to assign game to a person
        /// </summary>
        /// <param name="personID">this variable will be used to hold the personID</param>
        /// <returns></returns>
        public IActionResult AssignGame([Bind(Prefix ="id")]int personID)
        {

            var person = _personRepo.Read(personID);

            if(person == null)
            {
                return RedirectToAction("Index", "Person");
            }
            var allGames = _gameRepo.ReadAll();
            var personGames = person.GameRating
                .Select(x => x.Game).ToList();
            var gameNotSelected = allGames.Except(personGames);
            ViewData["Person"] = person;

            return View(gameNotSelected);
        }
    }
}
