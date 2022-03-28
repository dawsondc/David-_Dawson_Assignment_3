using David__Dawson_Assignment_3.Models.ViewModels;
using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    public class CompanyGameDevelopmentController : Controller
    {
        private ICompanyRepository _companyRepo;
        private IGameRepository _gameRepo;
        private ICompanyGameDevelopmentRepository _gameDevelopmentRepository;

        public CompanyGameDevelopmentController(ICompanyRepository companyRepo, IGameRepository gameRepo, ICompanyGameDevelopmentRepository companyGameDevelopmentRepo)
        {
            _companyRepo = companyRepo;
            _gameRepo = gameRepo;
            _gameDevelopmentRepository = companyGameDevelopmentRepo;
        }

        public IActionResult Create([Bind(Prefix = "ID")] int companyID, int gameID)
        {
            var company = _companyRepo.Read(companyID);
            if (company == null)
            {
                return RedirectToAction("Index", "Company");
            }
            var game = _gameRepo.Read(gameID);
            if (game == null)
            {
                return RedirectToAction("Details", "Company", new { ID = companyID });
            }
            var companyGame = company.CompanyBudget
                .SingleOrDefault(x => x.gameID == gameID);
            if (companyGame != null)
            {
                return RedirectToAction("Details", "Company", new { ID = companyID });
            }
            var companyGameVM = new CompanyGameVM
            {
                Company = company,
                Game = game
            };
            return View(companyGameVM);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Create")]
        public IActionResult CreateConfirmed(int companyID, int gameID)
        {
            _gameDevelopmentRepository.Create(companyID, gameID);
            return RedirectToAction("Details", "Company", new { ID = companyID });
        }



    }
}
