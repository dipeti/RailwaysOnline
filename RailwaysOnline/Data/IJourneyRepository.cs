using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwaysOnline.Models;

namespace RailwaysOnline.Data
{
    interface IJourneyRepository
    {
        IEnumerable<Journey> Journeys { get; }
        void Flush();
    }
}
