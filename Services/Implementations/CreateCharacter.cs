using DnDProject.Backend.Mapping.Implementations;
using DnDProject.Backend.Mapping.Interfaces;
using DnDProject.Backend.Services.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Character.ViewModels;
using DnDProject.Entities.Character.ViewModels.PartialViewModels;
using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using DnDProject.Entities.Races.DataModels;
using DnDProject.Entities.Races.ViewModels.PartialViewModels.ComponentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Services.Implementations
{
    public class CreateCharacter : ICreateCharacter
    {
        IBaseUserAccess _userAccess;

        public CharacterVM CreateCharacterGET()
        {
            CharacterVM vm = new CharacterVM();
            SetPrimaryTab(vm);

            return vm;
        }
        public void CreateCharacterPOST(CharacterVM vm)
        {
            throw new NotImplementedException();
        }
        public CharacterVM CreateCharacterINVALID(CharacterVM vm)
        {
            throw new NotImplementedException();
        }




        private void SetPrimaryTab(CharacterVM vm)
        {
            PrimaryTabVM primaryTab = new PrimaryTabVM();
            SetListOfRaces(primaryTab);
            primaryTab.Stats = new StatsCM();
            primaryTab.IsProficient = new IsProficientCM();
            primaryTab.Combat = new CombatCM();

            vm.PrimaryTab = primaryTab;
        }

        private void SetListOfRaces(PrimaryTabVM primaryTab)
        {
            List<RaceListModel> races = new List<RaceListModel>();

            //Get foundRaces from userAccess
            List<Race> foundRaces = _userAccess.GetAllRaces().ToList();

            //foreach race in foundRaces,
            foreach(Race race in foundRaces)
            {
                RaceListModel lm = CharacterMapper.mapRaceToRaceListModel(race);
                races.Add(lm);

            }
                //Map that race to a new raceListModel
                //add that model to races.

            primaryTab.Races = races;
        }

        public CreateCharacter(IBaseUserAccess userAccess)
        {
            _userAccess = userAccess;
        }
    }
}
