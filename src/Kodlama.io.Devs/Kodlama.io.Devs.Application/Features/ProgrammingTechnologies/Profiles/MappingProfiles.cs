namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingTechnology, ProgrammingTechnologyListDto>()
                .ForMember(p => p.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgramingLanguage.Name))
                .ReverseMap();

            CreateMap<IPaginate<ProgrammingTechnology>, ProgrammingTechnologyListModel>().ReverseMap();
            CreateMap<ProgrammingTechnology, CreatedProgrammingTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingTechnology, CreateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, UpdatedProgrammingTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingTechnology, DeleteProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, DeletedProgrammingTechnologyDto>().ReverseMap();
        }
    }
}