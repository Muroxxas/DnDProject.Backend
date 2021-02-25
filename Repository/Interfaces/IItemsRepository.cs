using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Items.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Interfaces
{
    public interface IItemsRepository : IRepository<Item>
    {
        void CharacterObtainsItem(Guid Character_id, Guid Item_id);
        void CharacterLosesItem(Guid Character_id, Guid Item_id);
        IEnumerable<Item> GetItemsHeldBy(Guid Character_id);

        Character_Item GetHeldItemRecord(Guid Character_id, Guid Item_id);
        IEnumerable<Character_Item> GetHeldItemRecordsForCharacter(Guid Character_id);

        IEnumerable<Tag> GetAllTags();
        IEnumerable<Tag> GetTagsForItem(Guid Item_id);
        void SetTagForItem(Guid item_id, Guid Tag_id);
        void SetAllTagsForItem(Guid Item_id, IEnumerable<Guid> tag_ids);
        void AddTagForItem(Guid Item_id, Guid Tag_id);
        void RemoveTagForItem(Guid Item_id, Guid Tag_id);
    }
}
