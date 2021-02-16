using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Races.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Interfaces
{
    public interface IRaceManagerUserAccess : IBaseUserAccess
    {
        void AddRace(Race race);
        void AddRaceAbility(RaceAbility raceAbility);
        void RemoveRace(Race race);
        void RemoveRaceAbility(RaceAbility raceAbility);
    }
}
