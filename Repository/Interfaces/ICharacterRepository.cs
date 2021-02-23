﻿using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Character.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Interfaces
{
    public interface ICharacterRepository : IRepository<CharacterDM>
    {
        IEnumerable<CharacterDM> GetCharactersOwnedBy(Guid User_id);
    }
}
