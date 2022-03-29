using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    /// <summary>
    /// class to hold the PersonController and its functions
    /// </summary>
    public class PersonController : Controller
    {
        private IPersonRepository _personRepo;

        /// <summary>
        /// Instance of controller
        /// </summary>
        /// <param name="personRepo">passthrough varible to be set to the pruvate variable</param>
        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        /// <summary>
        /// Index View
        /// </summary>
        /// <returns>Shows the list of people</returns>
        public IActionResult Index()
        {
            return View(_personRepo.ReadAll());
        }

        /// <summary>
        /// Detail view
        /// </summary>
        /// <param name="ID">used to identify the person the user selected</param>
        /// <returns>the details of the selected person</returns>
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
