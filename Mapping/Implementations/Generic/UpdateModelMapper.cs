using AutoMapper;
using DnDProject.Backend.Mapping.Interfaces.Generic;
using DnDProject.Backend.Mapping.Mapping_Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Mapping.Implementations.Generic
{
    public  class UpdateModelMapper<TViewModel, TEntity> : IUpdateModelMapper<TViewModel, TEntity>
    {
        IMapper mapper;
        public void mapUpdatedRecordOverEntity(TViewModel updatedRecord, TEntity Entity)
        {
            mapper.Map<TViewModel, TEntity>(updatedRecord, Entity);
        }

        public UpdateModelMapper()
        {
            var record_Over_Entity = new MapperConfiguration(
                cfg => cfg.CreateMap<TViewModel, TEntity>()
                .IgnoreNotMapped()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
            );

            mapper = record_Over_Entity.CreateMapper();
        }
    }
}
