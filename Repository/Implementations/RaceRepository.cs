using DnDProject.Backend.Contexts;
using DnDProject.Backend.Repository.Implementations.Generic;
using DnDProject.Backend.Repository.Interfaces;
using DnDProject.Entities.Races.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Implementations
{
    public class RaceRepository : Repository<Race>, IRaceRepository
    {
        private RaceContext _raceContext { get { return Context as RaceContext; } }

        public void AddRaceAbility (RaceAbility raceAbility)
        {
            _raceContext.RaceAbilities.Add(raceAbility);
        }
        public RaceAbility GetRaceAbility(Guid RaceAbility_id)
        {
            return _raceContext.RaceAbilities.Find(RaceAbility_id);
        }
        public IEnumerable<RaceAbility> GetAbilitiesOfRace(Guid Race_id)
        {
            return _raceContext.RaceAbilities.Where(x => x.Race_id == Race_id);
        }
        public void RemoveRaceAbility(RaceAbility toBeRemoved)
        {
            _raceContext.RaceAbilities.Remove(toBeRemoved);
        }

        public RaceRepository(RaceContext raceContext) : base(raceContext)
        {
        }
    }
}
