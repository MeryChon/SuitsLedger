using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            // Suit
            CreateMap<Suit, SuitToReturnDTO>()
                .ForMember(s => s.AuthorizedPerson, o => o.MapFrom(src => src.AuthorizedPerson.DisplayName));
            CreateMap<SuitDTO, Suit>().ReverseMap();

            // Authorized Person
            CreateMap<AuthorizedPerson, AuthorizedPersonToReturnDTO>();
            CreateMap<AuthorizedPersonDTO, AuthorizedPerson>().ReverseMap();
        }

    }
}