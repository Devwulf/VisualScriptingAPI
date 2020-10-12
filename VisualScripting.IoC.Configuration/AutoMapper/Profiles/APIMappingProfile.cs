using AutoMapper;
using DC = VisualScripting.API.DataContracts;
using S = VisualScripting.Services.Model;

namespace VisualScripting.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.User, S.User>().ReverseMap();
            CreateMap<DC.Address, S.Address>().ReverseMap();
            CreateMap<DC.Scriplet, S.Scriplet>().ReverseMap();
            CreateMap<DC.NodeItem, S.NodeItem>().ReverseMap();
            CreateMap<DC.VariableItem, S.VariableItem>().ReverseMap();
            CreateMap<DC.IdValuePair, S.IdValuePair>().ReverseMap();
            CreateMap<DC.ItemSlotPair, S.ItemSlotPair>().ReverseMap();
        }
    }
}
