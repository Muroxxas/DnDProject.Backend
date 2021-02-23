using DnDProject.Backend.Services.Implementations;
using DnDProject.Entities.Character.ViewModels;
using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DnDProject.Backend.Services.Interfaces
{
    public interface ICharacterServices
    {


        CharacterVM CreateCharacterGET();
        void CreateCharacterPOST(Guid user_id, CharacterVM vm);
        void CreateCharacterINVALID(CharacterVM vm);

        CharacterVM UpdateCharacterGET(Guid user_id, Guid character_id);
        void UpdateCharacterPOST(Guid user_id, CharacterVM vm);
        void UpdateCharacterINVALID(CharacterVM vm);


        CharacterSelectVM SelectCharacterGET(Guid user_id);

        //------Create-----
        KnownClassCM GetBlankKnownClassComponent(int Index);
        void CharacterObtainsItem(Guid user_id, Guid character_id, Guid spell_id);
        JsonResult GetBlankNoteComponent(int Index);
        void ExistingCharacterLearnsSpell(Guid user_id, Guid Character_id, Guid Spell_id);


        //------Delete------
        void CharacterForgetsClass(Guid user_id, Guid character_id, Guid Class_id);
        void CharacterLosesItem(Guid user_id, Guid character_id, Guid Item_id);
        void DeleteNote(Guid user_id, Guid character_id, Guid Note_id);
        void CharacterForgetsSpell(Guid user_id, Guid character_id, Guid spell_id);




    }
}
