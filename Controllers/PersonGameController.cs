using David__Dawson_Assignment_3.Models.ViewModels;
using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    /// <summary>
    /// Class to hold controller and its functions
    /// </summary>
    public class PersonGameController : Controller
    {
        private IPersonRepository _personRepo;
        private IGameRepository _gameRepo;
        private IPersonGameRepository _personGameRepository;

        /// <summary>
        /// instance of controller with passthrough instances of the interfaces
        /// </summary>
        /// <param name="personRepo">to be assigned to the private variable</param>
        /// <param name="gameRepo">to be assigned to the private variable</param>
        /// <param name="personGameRepo">to be assigned to the private variable</param>
        public PersonGameController(IPersonRepository personRepo, IGameRepository gameRepo, IPersonGameRepository personGameRepo)
        {
            _personRepo = personRepo;
            _gameRepo = gameRepo;
            _personGameRepository = personGameRepo;
        }


        public IActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Create view
        /// </summary>
        /// <param name="personID">passthrough variable to represent the personID from the entity</param>
        /// <param name="gameID">passthrough variable to represent the gameID from the entity</param>
        /// <returns>returns the view model of properties</returns>
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
            var personGame = person.GameRating
                .SingleOrDefault(x => x.gameID == gameID);
            if (personGame != null)
            {
                return RedirectToAction("Details", "Person", new { ID = personID });
            }
            //instance of view model assigning vars to the properties
            var personGameVM = new PersonGameVM
            {
                Person = person,
                Game = game
            };
            return View(personGameVM);
        }

        /// <summary>
        /// create post method
        /// </summary>
        /// <param name="personID">passthrough variable to represent the personID from the entity</param>
        /// <param name="gameID">passthrough variable to represent the gameID from the entity</param>
        /// <returns>sends user back to the details page with the game added</returns>
        [HttpPost, ValidateAntiForgeryToken, ActionName("Create")]
        public IActionResult CreateConfirmed(int personID, int gameID)
        {
            _personGameRepository.Create(personID, gameID);
            return RedirectToAction("Details", "Person", new { ID = personID });
        }

        /// <summary>
        /// Rating view
        /// </summary>
        /// <param name="personID">passthrough variable to represent the personID from the entity</param>
        /// <param name="gameID">passthrough variable to represent the gameID from the entity</param>
        /// <returns>returns to proper views if certain variables are NULL </returns>
        public IActionResult AssignGame([Bind(Prefix = "id")] int personID, int gameID)
        {
            var person = _personRepo.Read(personID);
            if (person == null)
            {
                return RedirectToAction("Index", "Person");
            }
            var personGame = person.GameRating
                .FirstOrDefault(x => x.gameID == gameID);
            if (personGame == null)
            {
                return RedirectToAction("Details", "Person", new { id = personID });
            }
            return View(personGame);
        }

        /// <summary>
        /// post for rating view
        /// </summary>
        /// <param name="personID">passthrough variable to represent the personID from the entity</param>
        /// <param name="personGameID">passthrough variable to represent the personGameID from the entity</param>
        /// <param name="rating">passthrough variable to represent the rating from the entity</param>
        /// <returns>returns to details viewwith rating added</returns>
        [HttpPost, ValidateAntiForgeryToken, ActionName("AssignGame")]
        public IActionResult AssignGameConfirmed(int personID, int personGameID, string rating)
        {
            _personGameRepository.UpdateGameRating(personGameID, rating);
            return RedirectToAction("Details", "Person", new { id = personID });
        }

        /// <summary>
        /// Remove view
        /// </summary>
        /// <param name="personID">passthrough variable to represent the personID from the entity</param>
        /// <param name="gameID">passthrough variable to represent the gameID from the entity</param>
        /// <returns>returns to proper view depending on if a certain variable is NULL</returns>
        public IActionResult Remove([Bind(Prefix = "id")] int personID, int gameID)
        {
            var person = _personRepo.Read(personID);
            if (person == null)
            {
                return RedirectToAction("Index", "Person");
            }
            var personGame = person.GameRating
                .FirstOrDefault(x => x.gameID == gameID);
            if (personGame == null)
            {
                return RedirectToAction("Details", "Person", new { id = personID });
            }
            return View(personGame);
        }

        /// <summary>
        /// post for remove view
        /// </summary>
        /// <param name="personID">passthrough variable to represent the personID from the entity</param>
        /// <param name="personGameID">passthrough variable to represent the personGameID from the entity</param>
        /// <returns>returns to the details view with the game entry removed</returns>
        [HttpPost, ValidateAntiForgeryToken, ActionName("Remove")]
        public IActionResult RemoveConfirmed(int personID, int personGameID)
        {
            _personGameRepository.Remove(personID, personGameID);
            return RedirectToAction("Details", "Person", new { id = personID });
        }

        /// <summary>
        /// WIll show a list of people with the games they are playing with theratings for each
        /// </summary>
        /// <returns>will return a list of people with the games they are playing with thier ratings for the game</returns>
        public IActionResult PersonGameList()
        {
            ViewData["Message"] = "Games Currently Being Played";
            var person = _personRepo.ReadAll();
            var personGameList =
            _personGameRepository.ReadAll();
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
            return View(model);
        }

    }
}
