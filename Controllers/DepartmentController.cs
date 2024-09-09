using Departman_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Departman_Management.Controllers
{
    public class DepartmentController : Controller
    {
        Context ContextDB = new Context();
        [Authorize] 
        public IActionResult Index()
        {
            var Values = ContextDB.departments.ToList();
            return View(Values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department newDepartment)
        {
            ContextDB.departments.Add(newDepartment);
            ContextDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Department department) 
        {
            ContextDB.departments.Remove(department);
            ContextDB.SaveChanges();
            return View("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var EditedDeparment = ContextDB.departments.Find(id);
            return View(EditedDeparment);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            Department UpdatedDepartment = ContextDB.departments.Find(department.Id);
            UpdatedDepartment.Name = department.Name;
            ContextDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var emps = ContextDB.employees.Where(x =>x.Department.Id == id).ToList();
            ViewBag.Title = ContextDB.departments.Find(id).Name;
            return View(emps);
        }
    }
}
