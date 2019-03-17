using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoTProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoTProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly GoTProjectContext _context;

        public AdminController(GoTProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}