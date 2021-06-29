using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Suit, SuitToReturnDTO>()
            .ForMember(s => s.AuthorizedPerson, o => o.MapFrom(src => src.AuthorizedPerson.DisplayName));
        }

    }
}