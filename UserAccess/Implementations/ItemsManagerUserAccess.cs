using DnDProject.Backend.Unit_Of_Work.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Items.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Implementations
{
    public class ItemsManagerUserAccess : BaseUserAccess, IItemsManagerUserAccess
    {
        private IUnitOfWork _worker { get; set; }

        public void AddItem(Item item)
        {
            _worker.Items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            _worker.Items.Remove(item);
        }
        public void RemoveItemById(Guid item_id)
        {
            _worker.Items.Remove(item_id);
        }

        public void SetTagForItem(Guid Item_id, Guid Tag_id)
        {
            _worker.Items.SetTagForItem(Item_id, Tag_id);
        }
        public void SetAllTagsForItem(Guid Item_id, IEnumerable<Guid> tag_ids)
        {
            _worker.Items.SetAllTagsForItem(Item_id, tag_ids);
        }
        public ItemsManagerUserAccess(IUnitOfWork worker) : base(worker)
        {
            _worker = worker;
        }
    }
}
