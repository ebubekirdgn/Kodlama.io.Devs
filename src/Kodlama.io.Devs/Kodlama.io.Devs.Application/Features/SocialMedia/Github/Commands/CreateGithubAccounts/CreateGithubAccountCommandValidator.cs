namespace Kodlama.io.Devs.Application.Features.SocialMedia.Github.Commands.CreateGithubAccounts
{
    public class CreateGithubAccountCommandValidator : AbstractValidator<CreateGithubAccountCommand>
    {
        public CreateGithubAccountCommandValidator()
        {
            RuleFor(g => g.GithubUrl).NotEmpty();
        }
    }
}