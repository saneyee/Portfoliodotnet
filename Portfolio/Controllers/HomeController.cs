using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Project"] = "Your application description page.";

            return View();
        }
        public IActionResult Blog()
        {
            ViewData["Project"] = "Your blog page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Project"] = "Your contact page.";

            return View();
        }



        public IActionResult Projects()
        {

            var topProjects = Project.GetProjects();
            return View(topProjects);

        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
