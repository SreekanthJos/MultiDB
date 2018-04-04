using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.Business;
using Example.BusinessEntities;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        readonly IPersonRepository personReposiotry;
        public HomeController(IPersonRepository personReposiotry)
        {
            this.personReposiotry = personReposiotry;
        }
        public ActionResult Index()
        {
            this.personReposiotry.GetPersons();
            ViewBag.Title = "Home Page";
            List<PersonDto> persons = personReposiotry.GetPersons();
            return View();
        }
    }
}
