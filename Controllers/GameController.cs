using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    public class GameController : Controller
    {
        private IPersonRepository _personRepo;
        private IGameRepository _gameRepo;

        public GameController(IPersonRepository personRepo, IGameRepository gameRepo)
        {
            _personRepo = personRepo;
            _gameRepo = gameRepo;
        }

        public IActionResult AssignGame([Bind(Prefix ="id")]int personID)
        {

            var person = _personRepo.Read(personID);

            if(person == null)
            {
                return RedirectToAction("Index", "Person");
            }
            var allGames = _gameRepo.ReadAll();
            var personGames = person.PersonRating
                .Select(x => x.Game).ToList();
            var gameNotSelected = allGames.Except(personGames);
            ViewData["Person"] = person;

            return View(gameNotSelected);
        }
    }
}
