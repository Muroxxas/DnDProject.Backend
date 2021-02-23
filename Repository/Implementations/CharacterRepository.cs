using DnDProject.Backend.Contexts;
using DnDProject.Backend.Repository.Implementations.Generic;
using DnDProject.Backend.Repository.Interfaces;
using DnDProject.Entities.Character.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Implementations
{
    public class CharacterRepository : Repository<CharacterDM>, ICharacterRepository
    {
        //cast the context inherited from the generic Repository as a CharacterContext.
        public CharacterContext _characterContext { get { return Context as CharacterContext; } }
        
        public IEnumerable<CharacterDM> GetCharactersOwnedBy(Guid User_id)
        {
            IEnumerable<CharacterDM> foundCharacters = (from character in _characterContext.Characters
                                                      where character.User_id == User_id
                                                      select character).ToList();

            foundCharacters.OrderBy(character => character.Name);
            return foundCharacters;
        }

        //When constructing this repository, pass the generic repository the same context the real repository is based upon.
        public CharacterRepository(CharacterContext context) : base(context) { }
    }
}
