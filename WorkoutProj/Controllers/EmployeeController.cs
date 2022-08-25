using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutProj.Models;

namespace WorkoutProj.Controllers
{
    public class EmployeeController : Controller
    {
        WorkForceManagementContext db = new WorkForceManagementContext();
        public IActionResult Index()
        {
            var result = db.Employees;
            return View(result.ToList());
        }
    }
}
