using AutoMapper;
using DnDProject.Backend.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Mapping.Implementations
{
    public class UpdateModelMapper<T> : IUpdateModelMapper<T>
    {
        public void mapUpdatedRecordOverEntity(T updatedRecord, T Entity)
        {

            var record_Over_Entity = new MapperConfiguration(
            cfg => cfg.CreateMap<T, T>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
            );

            var mapper = record_Over_Entity.CreateMapper();

            mapper.Map<T, T>(updatedRecord, Entity);
        }
    }
}
