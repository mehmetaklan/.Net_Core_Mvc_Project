using Departman_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Departman_Management.Controllers
{
    public class EmployeeController : Controller
    {
        Context ContextDB = new Context();
        public IActionResult Index()
        {
            var Values = ContextDB.employees.Include(x=>x.Department).ToList();
            return View(Values);
        }

        [HttpGet]
        public IActionResult Add()
        {
             List<SelectListItem> dprtmnts = (from x in ContextDB.departments.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.dprtmnts = dprtmnts;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee newEmployee)
        {
            var emp = ContextDB.departments.Where(x=>x.Id == newEmployee.Department.Id).FirstOrDefault();
            newEmployee.Department = emp; 
            ContextDB.employees.Add(newEmployee);
            ContextDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
