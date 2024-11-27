using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class CourseController : Controller
    {
        StudentManagementDBEntities db =new StudentManagementDBEntities();
        // GET: Course
        public ActionResult Index()
        {
            var data=db.Courses.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Course c)
        {
            db.Courses.Add(c);
            db.SaveChanges();   
            return View();
        }
        public ActionResult Update(int id)
        {
           var data= db.Courses.Where(model => model.id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(Course c)
        {
            db.Entry(c).State=EntityState.Modified;
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var data = db.Courses.Where(model => model.id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(Course c)
        {
            db.Entry(c).State = EntityState.Deleted;
            db.SaveChanges();
            return View();
        }
    }
}