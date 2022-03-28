using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    public class GameController : Controller
    {
        private ICompanyRepository _companyRepo;
        private IGameRepository _gameRepo;

        public GameController(ICompanyRepository companyRepo, IGameRepository gameRepo)
        {
            _companyRepo = companyRepo;
            _gameRepo = gameRepo;
        }

        public IActionResult AssignGame([Bind(Prefix ="ID")]int companyID)
        {

            var game = _gameRepo.Read(companyID);

            if(game == null)
            {
                return RedirectToAction("Index", "Company");
            }
            var allGames = _gameRepo.ReadAll();
            var gameSelect = game.GameBudget
                .Select(x => x.Game).ToList();
            var gameNotSelected = allGames.Except(gameSelect);
            ViewData["Game"] = game;

            return View(gameNotSelected);
        }
    }
}
