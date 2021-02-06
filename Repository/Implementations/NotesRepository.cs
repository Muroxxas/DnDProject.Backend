using DnDProject.Backend.Contexts;
using DnDProject.Backend.Repository.Implementations.Generic;
using DnDProject.Backend.Repository.Interfaces;
using DnDProject.Entities.Character.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Implementations
{
    public class NotesRepository : Repository<Note>, INotesRepository
    {
        //cast the context inherited from the generic Repository as a CharacterContext.
        public CharacterContext characterContext { get { return Context as CharacterContext; } }

        public IEnumerable<Note> GetNotesOwnedBy(Guid Character_id)
        {
            List<Note> foundNotes = characterContext.Set<Note>()
                .Where(x => x.Character_id == Character_id).ToList();

            foundNotes.OrderBy(note => note.Name);

            return foundNotes;
        }

        //When constructing this repository, pass the generic repository the same context the real repository is based upon.
        public NotesRepository(CharacterContext context) : base(context) { }
    }
}
