using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwaysOnline.Models;

namespace RailwaysOnline.Data
{
    public static class DbInitializer
    {
        public static void EnsurePopulated(RailwaysDbContext context)
        {
            if (context.Journeys.Any())
            {
                return; // DB has already been seeded;
            }
            var journeys = new Journey[]
            {
                new Journey()
                {
                    FromCity = Cities.Brussels,
                    ToCity = Cities.Amsterdam,
                    ArrivalTime = new DateTime(2018, 01, 01, 11, 0, 0),
                    DepartureTime = new DateTime(2018, 01, 01, 10, 0, 0),
                    BusinessSeats = 20,
                    EconomySeats = 100
                },
                new Journey()
                {
                    FromCity = Cities.London,
                    ToCity = Cities.Amsterdam,
                    ArrivalTime = new DateTime(2018, 01, 01, 12, 0, 0),
                    DepartureTime = new DateTime(2018, 01, 01, 9, 30, 0),
                    BusinessSeats = 20,
                    EconomySeats = 100
                },
                new Journey()
                {
                    FromCity = Cities.Paris,
                    ToCity = Cities.Brussels,
                    ArrivalTime = new DateTime(2018, 01, 01, 12, 0, 0),
                    DepartureTime = new DateTime(2018, 01, 01, 11, 0, 0),
                    BusinessSeats = 20,
                    EconomySeats = 100
                },
                new Journey()
                {
                    FromCity = Cities.Brussels,
                    ToCity = Cities.Berlin,
                    ArrivalTime = new DateTime(2018, 01, 01, 13, 0, 0),
                    DepartureTime = new DateTime(2018, 01, 01, 9, 0, 0),
                    BusinessSeats = 20,
                    EconomySeats = 100
                },
            };
            foreach (Journey journey in journeys)
            {
                context.Add(journey);
            }
            context.SaveChanges();
        }
    }
}
