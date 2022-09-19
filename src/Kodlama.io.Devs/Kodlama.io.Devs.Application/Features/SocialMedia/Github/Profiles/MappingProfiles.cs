namespace Kodlama.io.Devs.Application.Features.SocialMedia.Github.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubAccount, GithubAccountListDto>()
                .ForMember(u => u.UserEmail, opt => opt.MapFrom(u => u.User.Email))
                .ReverseMap();

            CreateMap<IPaginate<GithubAccount>, GithubAccountListModel>().ReverseMap();
        }
    }
}