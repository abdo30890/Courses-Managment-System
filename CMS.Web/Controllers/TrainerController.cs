using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Web.Models;

namespace CMS.Web.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            var addTrainer = new List<Trainer>
            {
                new Trainer
                {
                    Id = 1,
                    TrainerName = "Abdelrahman",
                    Description = "Welcome to new project",
                    Email = "abdo@gmail.com",
                    Website = "www.abdo.com"

                }
            };
            return View(addTrainer);
        }
    }
}