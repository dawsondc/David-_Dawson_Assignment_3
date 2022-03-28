using David__Dawson_Assignment_3.Models.ViewModels;
using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    public class PersonGameController : Controller
    {
        private IPersonRepository _personRepo;
        private IGameRepository _gameRepo;
        private IPersonGameRepository _personGameRepository;

        public PersonGameController(IPersonRepository personRepo, IGameRepository gameRepo, IPersonGameRepository personGameRepo)
        {
            _personRepo = personRepo;
            _gameRepo = gameRepo;
            _personGameRepository = personGameRepo;
        }

        public IActionResult Create([Bind(Prefix = "id")] int personID, int gameID)
        {
            var person = _personRepo.Read(personID);
            if (person == null)
            {
                return RedirectToAction("Index", "Person");
            }
            var game = _gameRepo.Read(gameID);
            if (game == null)
            {
                return RedirectToAction("Details", "Person", new { ID = personID });
            }
            var personGame = person.PersonRating
                .SingleOrDefault(x => x.gameID == gameID);
            if (personGame != null)
            {
                return RedirectToAction("Details", "Person", new { ID = personID });
            }
            var personGameVM = new PersonGameVM
            {
                Person = person,
                Game = game
            };
            return View(personGameVM);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Create")]
        public IActionResult CreateConfirmed(int personID, int gameID)
        {
            _personGameRepository.Create(personID, gameID);
            return RedirectToAction("Details", "Person", new { ID = personID });
        }

        public IActionResult AssignGame([Bind(Prefix = "id")] int personID, int gameId)
        {
            var person = _personRepo.Read(personID);
            if (person == null)
            {
                return RedirectToAction("Index", "Person");
            }
            var personGame = person.PersonRating
                .FirstOrDefault(x => x.gameID == gameId);
            if (personGame == null)
            {
                return RedirectToAction("Details", "Person", new { id = personID });
            }
            return View(personGame);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("AssignGame")]
        public IActionResult AssignGameConfirmed(int personID, int personGameID, string rating)
        {
            _personGameRepository.UpdateGameRating(personID, rating);
            return RedirectToAction("Details", "Person", new { id = personID });
        }



    }
}
