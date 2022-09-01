using AutoMapper;
using Autenticacao01.DTOs;
using Autenticacao01.Models;

namespace Autenticacao01.Profiles
{
    public class DiarioProfile : Profile
    {
        public DiarioProfile()
        {
            CreateMap<DiarioRequestDTO, Diario>();
            CreateMap<Diario, DiarioResponseDTO>();
        }
    }
}
