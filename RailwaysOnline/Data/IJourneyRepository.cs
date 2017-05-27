using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwaysOnline.Models;

namespace RailwaysOnline.Data
{
    public interface IJourneyRepository
    {
        IEnumerable<Journey> Journeys { get; }
        IEnumerable<Journey> LastFiveJourneys { get; }
        IEnumerable<Journey> FindJourneysBy(string from, string to, DateTime date);
        void Flush();
        void Persist(Journey journey);
    }
}
