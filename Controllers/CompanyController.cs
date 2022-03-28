using David__Dawson_Assignment_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace David__Dawson_Assignment_3.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyRepository _companyRepo;

        public CompanyController(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public IActionResult Index()
        {
            return View(_companyRepo.ReadAll());
        }

        public IActionResult Details(int ID)
        {
            var company = _companyRepo.Read(ID);
            if (company == null)
            {
                return RedirectToAction("Index");
            }
            return View(company);
        }
    }
}
