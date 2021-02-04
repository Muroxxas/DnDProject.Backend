using DnDProject.Backend.Repository;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Character.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Implementations
{
    public class BaseUserAccess : IBaseUserAccess
    {
        IDataRepository _dataRepository { get; set; }

        public void AddCharacter(Character character)
        {
            _dataRepository.AddCharacter(character);
        }
        public Character GetCharacter(Guid Character_id)
        {

            return _dataRepository.GetCharacter(Character_id);
        }
        public void UpdateCharacter(Character character)
        {
            _dataRepository.UpdateCharacter(character);
        }
        public void DeleteCharacter(Guid Character_id)
        {
            _dataRepository.DeleteCharacter(Character_id);
        }


        public void AddProficiencyRecord(IsProficient proficiencies)
        {
            _dataRepository.AddProficiencyRecord(proficiencies);
        }
        public IsProficient GetProficiencyRecord(Guid Character_id)
        {
            return _dataRepository.GetProficiencyRecord(Character_id);
        }
        public void UpdateProficiencyRecord(IsProficient updatedRecord)
        {
            _dataRepository.UpdateProficiencyRecord(updatedRecord);

        }

        public void AddHealthRecord(Health health)
        {
            _dataRepository.AddHealthRecord(health);
        }
        public Health GetHealthRecord(Guid Character_id)
        {
            return _dataRepository.GetHealthRecord(Character_id);
        }
        public void UpdateHealthRecord(Health updatedRecord)
        {
            _dataRepository.UpdateHealthRecord(updatedRecord);
        }

        public void AddStatsRecord(Stats stats)
        {
            _dataRepository.AddStatsRecord(stats);
        }

        public Stats GetStatsRecord(Guid Character_id)
        {
            return _dataRepository.GetStatsRecord(Character_id);
        }
        public void UpdateStatsRecord(Stats updatedRecord)
        {
            _dataRepository.UpdateStatsRecord(updatedRecord);
        }

        public void SaveChanges()
        {
            _dataRepository.SaveChanges();
        }
        public void SaveChangesAsync()
        {
            _dataRepository.SaveChangesAsync();
        }

        public BaseUserAccess(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

    }
}
