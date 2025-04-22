using AtlasConnectionApiCode.Dto.Response;
using AtlasConnectionApiCode.Model;
using AutoMapper;

namespace AtlasConnectionApiCode.Mapper
{
    public class AutoMapperCommonModelProfile : Profile
    {
        public AutoMapperCommonModelProfile()
        {
            CreateMap<CommonModel, CommonTypeDtoResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));                
        }
    }
}
