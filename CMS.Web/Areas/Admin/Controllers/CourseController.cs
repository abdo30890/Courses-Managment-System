using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Web.Models;

namespace CMS.Web.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        // GET: Admin/Course
        public ActionResult Index()
        {
            var courses = new List<Course>
            {
                new Course
                {
                    Id = 1,
                    CourseName = "Programming",
                    Description = "Welcome to new project",


                }

            };
            return View(courses);
        }
    }
}