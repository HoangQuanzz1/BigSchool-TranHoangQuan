using lab3_tranhoangquan.Models;
using lab3_tranhoangquan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
namespace lab3_tranhoangquan.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
              
            };
            return View(viewModel);
        }
       
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
           
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}