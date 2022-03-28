using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository _personRepo;

        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public IActionResult Index()
        {
            return View(_personRepo.ReadAll());
        }

        public IActionResult Details(int ID)
        {
            var person = _personRepo.Read(ID);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}
