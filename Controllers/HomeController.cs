using Crud_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_ADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            StudentDbContext studentDbContext = new StudentDbContext();
            List<Student> obj = studentDbContext.GetDetails();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if(ModelState.IsValid==true) 
                {
                    StudentDbContext db = new StudentDbContext();
                    bool check = db.AddStudent(student);
                    if (check==true) 
                    {
                        TempData["AddMsg"] = "<script>alert('Data has been inserted'); </script>";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }

                return View();
            }

            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id) 
        {
            StudentDbContext db=new StudentDbContext();
            var data=db.GetDetails().Find(model=>model.id==id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(int id,Student student)
        {
            StudentDbContext db=new StudentDbContext();
            bool check=db.DeleteStudent(id);
            if (check==true)
            {
                TempData["DeleteMsg"] = "<script>alert('Deleted')</script>";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id) 
        {
            StudentDbContext db=new StudentDbContext();
            var data=db.GetDetails().Find(model=>model.id== id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id,Student student)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    StudentDbContext db = new StudentDbContext();
                    bool check=db.UpdateStudent(student);
                    if (check==true) 
                    {
                        TempData["EditMsg"] = "Updated";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();

            }

            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            StudentDbContext db=new StudentDbContext();
            var data=db.GetDetails().Find(model=>model.id==id);
            return View(data);
        }
    }
}