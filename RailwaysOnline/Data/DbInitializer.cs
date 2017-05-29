using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RailwaysOnline.Models;
using Microsoft.Extensions.DependencyInjection;

namespace RailwaysOnline.Data
{
    public static class DbInitializer
    {
        public static void EnsureJourneyPopulated(RailwaysDbContext context)
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
                        FromCity = Cities.London,
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

        private const string ADMIN_USER = "admin";
        private const string ADMIN_PASSWORD = "Secret123$";

        public static async void EnsureUsersPopulated(IApplicationBuilder app)
        {
            UserManager<User> userManager =
                app.ApplicationServices.GetRequiredService<UserManager<User>>();
            User user = await userManager.FindByIdAsync(ADMIN_USER);
            if (user == null)
            {
                user = new User("Admin");
                user.Language = Languages.en;
                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }
        }
    }
}
