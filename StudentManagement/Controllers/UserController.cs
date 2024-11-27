using Microsoft.Ajax.Utilities;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    
    public class UserController : Controller
    {
        StudentManagementDBEntities db = new StudentManagementDBEntities();

        // GET: User
        public ActionResult Index()
        {
            var data = db.Users.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User u)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(u); // Return to the Create view with validation messages if invalid
        }

        public ActionResult Update(int id)
        {
            var data = db.Users.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(User u)
        {
            if (ModelState.IsValid)
            {
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(u); // Return to the Update view if validation fails
        }

        public ActionResult Delete(int id)
        {
            var data = db.Users.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}