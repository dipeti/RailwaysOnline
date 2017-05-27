using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwaysOnline.Models;

namespace RailwaysOnline.Data
{
    public class JourneyRepository : IJourneyRepository
    {
        private RailwaysDbContext context;

        public JourneyRepository(RailwaysDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Journey> Journeys => context.Journeys.OrderByDescending(j => j.DepartureTime).ToList();
        public IEnumerable<Journey> LastFiveJourneys => Journeys.Take(5).ToList();

        public IEnumerable<Journey> FindJourneysBy(string from, string to, DateTime date)
        {
            return Journeys.Where(j =>
                j.FromCity.ToString() == from && 
                j.ToCity.ToString() == to &&
                0 > DateTime.Compare(date, j.DepartureTime)).ToList();
        }

        public void Flush()
        {
            context.SaveChanges();
        }

        public void Persist(Journey journey)
        {
            context.Attach(journey);
        }
    }
}
