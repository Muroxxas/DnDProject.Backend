using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Interfaces
{
    public interface ICharacterCMBuilder
    {

        //Builds and returnss a HeldItemRowCm for a given item that is now coming into the character's possession.
        HeldItemRowCM buildNewHeldItemRowCM(Guid Item_id);

        //builds and returns a HeldItemRowCM for a given item for which a Character_item row exists.
        HeldItemRowCM buildExistingHeldItemRowCM(Guid Character_id, Guid Item_id);


        //Builds and returns a set of HeldItemRowCMs. This set represents all the items held by a character at time of calling.
        IEnumerable<HeldItemRowCM> buildItemRowCMsForCharacter(Guid Character_id);

        ItemDetailsCM buildItemDetailsCM(Guid Item_id);

        KnownSpellRowCM buildKnownSpellRowCM(Guid Spell_id);

        SpellDetailsCM buildSpellDetailsCM(Guid Spell_id);
        //Builds and returns a set of KnownSpellRowCMs. This set represents all the spells known by a character at time of calling.
        IEnumerable<KnownSpellRowCM> buildKnownSpellRowCMsForCharacter(Guid Character_id);

        //Builds and returns a set of NoteCMs. This represents all the notes a character has within the database at the time of calling.
        IEnumerable<NoteCM> buildNoteCMsFOrCharacter(Guid Character_id);

        ClassRowCM buildNewClassRowCM(int Index);

        ClassRowCM buildKnownClassRowCM(int Index, Character_Class_Subclass ccsc, ClassesListModel[] CLM);

        //KnownClassRowCM buildExistingKnownClassRowCM(Guid Character_id, Guid Class_id);


        StatsCM buildStatsCM(Guid Character_id);

        StatBonusCM buildStatBonusCM(StatsCM cm);

        ProficiencyCM buildProficiencyCM(Guid Character_id, StatBonusCM statBonus, int totalLevel);

        IsProficientCM buildIsProficientCM(Guid Character_id);

        SkillBonusCM buildSkillBonusCM(StatBonusCM statBonus, int totalLevel, IsProficientCM proficiencies);

        //SavesCM buildSavesCM(Guid Character_id, StatBonusCM statBonus, int totalLevel);


    }
}
