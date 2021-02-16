using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Races.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Interfaces
{
    public interface IRaceRepository : IRepository<Race>
    {
        void AddRaceAbility(RaceAbility raceAbility);

        RaceAbility GetRaceAbility(Guid RaceAbility_id);
        IEnumerable<RaceAbility> GetAbilitiesOfRace(Guid Race_id);

        void RemoveRaceAbility(RaceAbility raceAbility);
    }
}
