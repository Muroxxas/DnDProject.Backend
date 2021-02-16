using DnDProject.Backend.Unit_Of_Work.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Races.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Implementations
{
    public class RaceManagerUserAccess : BaseUserAccess, IRaceManagerUserAccess
    {
        private IUnitOfWork _worker { get; set; }

        public void AddRace(Race race)
        {
            _worker.Races.Add(race);
        }
        public void AddRaceAbility(RaceAbility raceAbility)
        {
            _worker.Races.AddRaceAbility(raceAbility);
        }
        public void RemoveRace(Race toBeRemoved)
        {
            _worker.Races.Remove(toBeRemoved);
        }
        public void RemoveRaceAbility(RaceAbility toBeRemoved)
        {
            _worker.Races.RemoveRaceAbility(toBeRemoved);
        }
        public RaceManagerUserAccess(IUnitOfWork worker) : base(worker)
        {
            _worker = worker;
        }
    }
}
