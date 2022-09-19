namespace Kodlama.io.Devs.Application.Features.SocialMedia.Github.Models
{
    public class GithubAccountListModel : BasePageableModel
    {
        public IList<GithubAccountListDto> Items { get; set; }
    }
}