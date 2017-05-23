using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RailwaysOnline.Data;

namespace RailwaysOnline.Controllers
{
    public class HomeController : Controller
    {
        private RailwaysDbContext context;
        public HomeController(RailwaysDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View(context.Journeys.ToList());
        }
    }
}