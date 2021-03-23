using DnDProject.Backend.Contexts;
using DnDProject.Backend.Repository.Implementations.Generic;
using DnDProject.Backend.Repository.Interfaces;
using DnDProject.Entities.Items.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Implementations
{
    public class ItemsRepository : Repository<Item>, IItemsRepository
    {
        public ItemsContext itemsContext { get { return Context as ItemsContext; } }

        public void CharacterObtainsItem(Guid Character_id, Guid Item_id)
        {
            Character_Item newHeldItem = new Character_Item
            {
                Character_id = Character_id,
                Item_id = Item_id,
                isEquipped = false,
                IsAttuned = false,
                count = 1
            };
            itemsContext.HeldItems.Add(newHeldItem);
        }
        public void CharacterObtainsItem(Character_Item record)
        {
            itemsContext.HeldItems.Add(record);
        }
        public Character_Item GetHeldItemRecord(Guid Character_id, Guid Item_id)
        {
            return itemsContext.HeldItems.Where(x => x.Character_id == Character_id && x.Item_id == Item_id).FirstOrDefault();
        }
        public IEnumerable<Character_Item> GetHeldItemRecordsForCharacter(Guid Character_id)
        {
            return itemsContext.HeldItems.Where(x => x.Character_id == Character_id).ToList();
        }
        public void CharacterLosesItem(Guid Character_id, Guid Item_id)
        {
            Character_Item foundRecord = itemsContext.HeldItems.Where(x => x.Character_id == Character_id & x.Item_id == Item_id).First();
            itemsContext.HeldItems.Remove(foundRecord);

        }
        public IEnumerable<Item> GetItemsHeldBy(Guid Character_id)
        {
            List<Character_Item> heldItemRecords = itemsContext.HeldItems.Where(x => x.Character_id == Character_id).ToList();

            List<Item> foundItems = new List<Item>();
            foreach (Character_Item heldItem in heldItemRecords)
            {
                Guid item_id = heldItem.Item_id;
                Item foundItem = itemsContext.Items.Where(x => x.Item_id == item_id).First();
                foundItems.Add(foundItem);
            }
            return foundItems;
        }
        public IEnumerable<Tag> GetAllTags()
        {
            return itemsContext.Tags;
        }
        public IEnumerable<Tag> GetTagsForItem(Guid Item_id)
        {
            List<Item_Tag> itemTagRecords = itemsContext.Item_Tags.Where(x => x.Item_id == Item_id).ToList();
            List<Tag> foundTags = new List<Tag>();
            foreach(Item_Tag itemTag in itemTagRecords)
            {
                Guid tag_id = itemTag.Tag_id;
                Tag foundTag = itemsContext.Tags.Find(tag_id);
                foundTags.Add(foundTag);
            }
            return foundTags;
        }
        public void SetTagForItem(Guid item_id, Guid Tag_id)
        {
            Item_Tag newRecord = new Item_Tag
            {
                Item_id = item_id,
                Tag_id = Tag_id
            };
            itemsContext.Item_Tags.Add(newRecord);
        }
        public void SetAllTagsForItem(Guid Item_id, IEnumerable<Guid> tag_ids)
        {
            List<Item_Tag> itemTags = new List<Item_Tag>();
            foreach(Guid tag_id in tag_ids)
            {
                Item_Tag record = new Item_Tag
                {
                    Item_id = Item_id,
                    Tag_id = tag_id
                };
                itemTags.Add(record);
            }
            itemsContext.Item_Tags.AddRange(itemTags);
        }
        public void AddTagForItem(Guid Item_id, Guid Tag_id)
        {
            throw new NotImplementedException();
        }
        public void RemoveTagForItem(Guid Item_id, Guid Tag_id)
        {
            throw new NotImplementedException();
        }


        public ItemsRepository(ItemsContext itemsContext) : base(itemsContext)
        {

        }
    }
}
