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
    public class CreateModelMapper<ViewModel,DataModel> : ICreateModelMapper<ViewModel,DataModel>
    {

        IMapper mapper;

        public DataModel mapViewModelToDataModel(ViewModel vm)
        {
            DataModel m = (DataModel)Activator.CreateInstance(typeof(DataModel));
            mapper.Map<ViewModel, DataModel>(vm, m);

            return m;

        }
        public CreateModelMapper()
        {
            var vm_To_m = new MapperConfiguration(
                cfg => cfg.CreateMap<ViewModel, DataModel>()
                .IgnoreNotMapped()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
            );

            mapper = vm_To_m.CreateMapper();
        }

    }
}
