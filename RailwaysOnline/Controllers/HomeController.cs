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
using RailwaysOnline.Models;

namespace RailwaysOnline.Controllers
{
    public class HomeController : Controller
    {
        private IJourneyRepository journeyRepository;
        public HomeController(IJourneyRepository journeyRepository)
        {
            this.journeyRepository = journeyRepository;
        }
        
        public ViewResult Index()
        {
            return View(new JourneyViewModel()
            {
                Journeys = journeyRepository.LastFiveJourneys,
                Date = DateTime.Now,
            });
        }

        [HttpPost]
        public ViewResult Index(string from, string to, DateTime date)
        {
            return View("JourneyResults",journeyRepository.FindJourneysBy(from, to, date));
        }

        
        

        


        

    }
}