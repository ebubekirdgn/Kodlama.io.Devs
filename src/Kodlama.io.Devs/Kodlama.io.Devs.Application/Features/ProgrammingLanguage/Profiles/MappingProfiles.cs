using AutoMapper;
using Kodlama.io.Devs.Application.Features.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.Dtos;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        }
    }
}
