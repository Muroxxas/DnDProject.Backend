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
        public Character GetCharacter(Guid Character_id)
        {

            return _dataRepository.GetCharacterBy_CharacterID(Character_id);
        }

        public void AddCharacter(Character character)
        {
            _dataRepository.InsertCharacterIntoDb(character);
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
