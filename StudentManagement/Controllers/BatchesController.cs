using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class BatchesController : Controller
    {
        private StudentManagementDBEntities db = new StudentManagementDBEntities();

        
        public ActionResult Index()
        {
            var data = db.Batches.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Batch B)
        {
            db.Batches.Add(B);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Batches.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Batch B)
        {
            db.Batches.Add(B);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Batches.Find(id);
            return View(data);
        }
       
        [HttpPost]
        public ActionResult Delete(int id, Batch c)
        {
            if (!ModelState.IsValid)
            {
                return View(c);
            }

            var data = db.Batches.Find(id);
            if (data == null)
            {
                return HttpNotFound(); 
            }

            db.Batches.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}
