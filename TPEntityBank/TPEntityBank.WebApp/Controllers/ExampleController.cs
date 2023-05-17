using Microsoft.AspNetCore.Mvc;
using TPEntityBank.Models;

namespace TPEntityBank.WebApp.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NamedView()
        {
            return View("MySuperView");
        }

        public  IActionResult DataView()
        {
            ViewData["chaine1"] = "Voici une super chaine de caracteres !";

            ViewBag.chaine2 = "Voila une autre chaine de caractere";
            
            return View();  
        }

        public IActionResult ModelView()
        {
            Transaction tran = new()
            {
                Id = 22,
                TransactionDate = DateTime.Now,
                CompteDebiteur = 10123456789,
                CompteCrediteur = 1012345677,
                Montant = 876
            };
            return View(tran);
        }

    }
}
