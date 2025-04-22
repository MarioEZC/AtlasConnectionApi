using AtlasConnectionApiCode.Dto.Request;
using AtlasConnectionApiCode.Model;
using AutoMapper;
using MongoDB.Bson;

namespace AtlasConnectionApiCode.Mapper;
public class AutoMapperUserModelProfile : Profile
{
    public AutoMapperUserModelProfile()
    {
        CreateMap<SaveUserDtoRequest, UserModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? ObjectId.GenerateNewId() : ObjectId.Parse(src.Id)))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => src.PhoneNumbers))
            .ForMember(dest => dest.Directions, opt => opt.MapFrom(src => src.Directions));

        CreateMap<PhoneNumber, Telephonemodel>()
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
            .ForMember(dest => dest.NumberType, opt => opt.MapFrom(src => src.NumberType));

        CreateMap<Direction, DirectionModel>()
            .ForMember(dest => dest.Direction, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.DirectionType, opt => opt.MapFrom(src => src.DirectionType));

    }
}