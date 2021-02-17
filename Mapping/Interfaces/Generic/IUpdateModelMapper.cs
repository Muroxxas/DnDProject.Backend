using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Mapping.Interfaces.Generic
{
    public interface IUpdateModelMapper<T, U>
    {
        void mapUpdatedRecordOverEntity(T updatedRecord, U Entity);
    }
}
