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
            Random r = new Random();
            DateTime refDateTime = DateTime.Now;
            for (int i = 0; i < 365; i++)
            {
                refDateTime = refDateTime.AddDays(1);
                var journeys = new Journey[]
                {
                    // AMSTERDAM
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Amsterdam,
                        ToCity = Cities.Berlin,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Amsterdam,
                        ToCity = Cities.Brussels,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Amsterdam,
                        ToCity = Cities.London,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Amsterdam,
                        ToCity = Cities.Berlin,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Amsterdam,
                        ToCity = Cities.Paris,
                        Price = r.Next(300, 800)
                    },
                    // BRUSSELS
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Brussels,
                        ToCity = Cities.Berlin,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Brussels,
                        ToCity = Cities.London,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Brussels,
                        ToCity = Cities.Berlin,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Brussels,
                        ToCity = Cities.Paris,
                        Price = r.Next(300, 800)
                    },
                    // BERLIN
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Berlin,
                        ToCity = Cities.Amsterdam,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Berlin,
                        ToCity = Cities.Brussels,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Berlin,
                        ToCity = Cities.London,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Berlin,
                        ToCity = Cities.Paris,
                        Price = r.Next(300, 800)
                    },
                    // LONDON
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.London,
                        ToCity = Cities.Amsterdam,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.London,
                        ToCity = Cities.Berlin,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.London,
                        ToCity = Cities.Brussels,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Brussels,
                        ToCity = Cities.Paris,
                        Price = r.Next(300, 800)
                    },
                    // PARIS
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Paris,
                        ToCity = Cities.Amsterdam,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Paris,
                        ToCity = Cities.Berlin,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Paris,
                        ToCity = Cities.Brussels,
                        Price = r.Next(300, 800)
                    },
                    new Journey
                    {
                        DepartureTime = refDateTime,
                        ArrivalTime = refDateTime.AddMinutes(r.Next(20, 480)),
                        BusinessSeats = r.Next(0, 20),
                        EconomySeats = r.Next(20, 100),
                        FromCity = Cities.Paris,
                        ToCity = Cities.London,
                        Price = r.Next(300, 800)
                    },
                    
                };
                foreach (Journey journey in journeys)
                {
                    context.Add(journey);
                }
            }
            
            context.SaveChanges();
        }
    }
}
