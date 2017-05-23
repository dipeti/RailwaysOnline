using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RailwaysOnline.Data;

namespace RailwaysOnline.Controllers
{
    public class HomeController : Controller
    {
        private IJourneyRepository journeyRepository;
        public HomeController(IJourneyRepository journeyRepository)
        {
            this.journeyRepository = journeyRepository;
        }
        [HttpGet]
        public ViewResult Index()
        {
            return View(journeyRepository.LastFiveJourneys);
        }

        [HttpPost]
        public IActionResult Index(string from, string to, DateTime date)
        {
            return View(journeyRepository.FindJourneysBy(from, to, date));
        }

        public string Show()
        {
            return "Results...";
        }
    }
}