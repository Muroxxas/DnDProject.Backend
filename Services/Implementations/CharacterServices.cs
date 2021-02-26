using DnDProject.Backend.Processors.Interfaces;
using DnDProject.Backend.Services.Interfaces;
using DnDProject.Entities.Character.ViewModels;
using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DnDProject.Backend.Services.Implementations
{
    public class CharacterServices : ICharacterServices
    {
        private ICreateCharacter _creator;
        private IUpdateCharacter _updater;
        private ICharacterCMBuilder _builder;
        public CharacterVM CreateCharacterGET()
        {
           return _creator.CreateCharacterGET();
        }
        public void CreateCharacterPOST(Guid user_id, CharacterVM vm)
        {
            _creator.CreateCharacterPOST(user_id, vm);
        }
        public void CreateCharacterINVALID(CharacterVM vm)
        {
            throw new NotImplementedException();
        }

        public CharacterVM UpdateCharacterGET(Guid user_id, Guid character_id)
        {
            throw new NotImplementedException();
        }
        public void UpdateCharacterPOST(Guid user_id, CharacterVM vm)
        {
            throw new NotImplementedException();
        } 
        public void UpdateCharacterINVALID(CharacterVM vm)
        {
            throw new NotImplementedException();
        }

        public CharacterSelectVM SelectCharacterGET(Guid user_id)
        {
            throw new NotImplementedException();
        }

        //------Create components
        public KnownClassRowCM GetBlankKnownClassRowCM(int Index)
        {
            throw new NotImplementedException();
        }
        public void CharacterObtainsItem(Guid user_id, Guid character_id, Guid spell_id)
        {
            throw new NotImplementedException();
        }
        public JsonResult GetBlankNoteComponent(int Index)
        {
            throw new NotImplementedException();
        }
        public HeldItemRowCM buildHeldItemRowCM(int Index, Guid Item_id)
        {
            HeldItemRowCM cm = _builder.buildNewHeldItemRowCM(Item_id);
            cm.Index = Index;
            return cm;
        }
        public KnownSpellRowCM buildKnownSpellRowCM(int Index, Guid Spell_id)
        {
            KnownSpellRowCM cm = _builder.buildKnownSpellRowCM(Spell_id);
            cm.Index = Index;
            return cm;
        }

        //------Create records ------
        public void ExistingCharacterLearnsSpell(Guid user_id, Guid character_id, Guid spell_id)
        {
            _updater.ExistingCharacterLearnsSpell(user_id, character_id, spell_id);
            throw new NotImplementedException();
        }


        //------Delete records
        public void CharacterForgetsClass(Guid user_id, Guid character_id, Guid Class_id)
        {
            throw new NotImplementedException();
        }
        public void CharacterLosesItem(Guid user_id, Guid character_id, Guid item_id)
        {
            throw new NotImplementedException();
        }
        public void DeleteNote(Guid user_id, Guid character_id, Guid note_id)
        {
            throw new NotImplementedException();
        }
        public void CharacterForgetsSpell(Guid user_id, Guid character_id, Guid note_id)
        {
            throw new NotImplementedException();
        }

        public CharacterServices(ICreateCharacter creator, IUpdateCharacter updater, ICharacterCMBuilder builder )
        {
            _creator = creator;
            _updater = updater;
            _builder = builder;
        }
    }
}
