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
        }
    }
}
