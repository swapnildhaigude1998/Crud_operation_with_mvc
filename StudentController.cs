using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using CrudOpeartionwithMVC.Models;
using System.Data.Entity;
namespace CrudOpeartionwithMVC.Controllers
{
    public class StudentController : Controller
    {
        demodbEntities db;

        public StudentController()
        {
            db = new demodbEntities();
        }
        public ActionResult DisplayStudent()
        {
            List<tblstudent> lst = db.tblstudents.ToList();
            return View(lst);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(tblstudent st)
        {
            db.tblstudents.Add(st);
            db.SaveChanges();
            return RedirectToAction("DisplayStudent");
        }
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            tblstudent s = db.tblstudents.Find(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult EditStudent(tblstudent st)
        {
            db.Entry<tblstudent>(st).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DisplayStudent");
        }

        public ActionResult DeleteStudent(int id)
        {
            tblstudent s= db.tblstudents.Find(id);
            db.tblstudents.Remove(s);
            db.SaveChanges();
            return RedirectToAction("DisplayStudent");
        }
    }
}