﻿using DnDProject.Backend.Contexts;
using DnDProject.Backend.Repository.Implementations;
using DnDProject.Backend.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository
{
    public static class RepositoryFactory
    {
        public static ICharacterRepository GetCharacterRepository(CharacterContext context)
        {
            return new CharacterRepository(context);
        }
        public static IHealthRepository GetHealthRepository(CharacterContext context)
        {
            return new HealthRepository(context);
        }
        public static ICurrencyRepository GetCurrencyRepository(CharacterContext context)
        {
            return new CurrencyRepository(context);
        }
        public static IIsProficientRepository GetIsProficientRepository(CharacterContext context)
        {
            return new IsProficientRepository(context);
        }
        public static INotesRepository GetNotesRepository(CharacterContext context)
        {
            return new NotesRepository(context);
        }
        public static IStatsRepository GetStatsRepository(CharacterContext context)
        {
            return new StatsRepository(context);
        }

        public static ISpellsRepository GetSpellsRepository(SpellsContext spellsContext) 
        {
            return new SpellsRepository(spellsContext);
        }
        public static IItemsRepository GetItemsRepository(ItemsContext itemsContext)
        {
            return new ItemsRepository(itemsContext);
        }
        public static IPlayableClassRepository GetPlayableClassRepository(PlayableClassContext playableClassContext)
        {
            return new PlayableClassRepository(playableClassContext);
        }
        public static IClassAbilityRepository GetClassAbilityRepository(PlayableClassContext playableClassContext)
        {
            return new ClassAbilityRepository(playableClassContext);
        }
        public static ISubclassRepository GetSubclassRepository( PlayableClassContext playableClassContext)
        {
            return new SubclassRepository(playableClassContext);
        }
        public static ISubclassAbilityRepository GetSubclassAbilityRepository(PlayableClassContext playableClassContext)
        {
            return new SubclassAbilityRepository(playableClassContext);
        }
        public static IRaceRepository GetRacesRepository(RaceContext raceContext)
        {
            return new RaceRepository(raceContext);
        }
    }
}
