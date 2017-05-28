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
        public IEnumerable<Journey> LastFiveJourneys => Journeys.Where(j => 0 == j.DepartureTime.Date.CompareTo(DateTime.Today)).Take(5).ToList();

        public IEnumerable<Journey> FindJourneysBy(string from, string to, DateTime date)
        {
            return Journeys.Where(j =>
                j.FromCity.ToString() == from && 
                j.ToCity.ToString() == to &&
                0 == j.DepartureTime.Date.CompareTo(date)).ToList();
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
