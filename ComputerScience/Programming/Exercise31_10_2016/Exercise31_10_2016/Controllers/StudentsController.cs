using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise31_10_2016.Controllers
{
    public class StudentsController : Controller
    {
        Models.Students.Repository r = new Models.Students.Repository();
        string operationTopic;
        // GET: Students
        public ActionResult Index()
        {
            return View(r);
        }
        [HttpPost]
        public ActionResult Index(string submit)
        {
            Models.Students.Repositoryother ro = new Models.Students.Repositoryother(r, operationTopic);
            if (submit == "Operations on Students")
            {
                ro.operationTopic=operationTopic = "s";
                return View("CRUD",ro);
            }
            if (submit == "Operations on Courses")
            {
                ro.operationTopic = operationTopic = "c";
                return View("CRUD",ro);
            }
            if (submit == "Operations on Faculties")
            {
                ro.operationTopic = operationTopic = "f";
                return View("CRUD",ro);
            }
            return View(r);
        }
        [HttpPost]
        public ActionResult CRUD(string submit, string name,string id)
        {
            return View("Index", r);
        }
        [HttpPost]
        public ActionResult OperationsOnStudents(string submit)
        {
            return View("Index", r);
        }
    }
}