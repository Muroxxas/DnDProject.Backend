using DnDProject.Entities.Items.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Interfaces
{
    public interface IItemsManagerUserAccess : IBaseUserAccess
    {
        void AddItem(Item item);
        void RemoveItem(Item item);
        void RemoveItemById(Guid Item_id);
        void SetTagForItem(Guid Item_id, Guid Tag_id);
        void SetAllTagsForItem(Guid Item_id, IEnumerable<Guid> Tag_ids);
    }
}
