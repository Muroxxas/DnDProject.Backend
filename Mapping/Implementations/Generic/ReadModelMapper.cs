using AutoMapper;
using DnDProject.Backend.Mapping.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Mapping.Implementations.Generic
{
    public class ReadModelMapper<DataModel, ViewModel> : IReadModelMapper<DataModel, ViewModel>
    {

        IMapper mapper;
        public void mapDataModelToViewModel(DataModel dataModel, ViewModel viewModel)
        {
            mapper.Map<DataModel, ViewModel>(dataModel, viewModel);
        }

        public ReadModelMapper()
        {
            var dataModel_To_viewModel = new MapperConfiguration(
                cfg => cfg.CreateMap<DataModel, ViewModel>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
                );

            mapper = dataModel_To_viewModel.CreateMapper();
        }
    }
}
