using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Mapping.Interfaces
{
    public interface IUpdateModelMapper<T>
    {
        void mapUpdatedRecordOverEntity(T updatedRecord, T Entity);
    }
}
