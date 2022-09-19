namespace Kodlama.io.Devs.Application.Features.SocialMedia.Github.Commands.UpdateGithubAccounts
{
    public class UpdateGithubAccountCommand : IRequest<UpdatedGithubAccountDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubUrl { get; set; }

        public class UpdateGithubAccountCommandHandler : IRequestHandler<UpdateGithubAccountCommand, UpdatedGithubAccountDto>
        {
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly IMapper _mapper;
            private readonly GithubAccountBusinessRules _githubAccountBusinessRules;

            public UpdateGithubAccountCommandHandler(IGithubAccountRepository githubAccountRepository, IMapper mapper, GithubAccountBusinessRules githubAccountBusinessRules)
            {
                _githubAccountRepository = githubAccountRepository;
                _mapper = mapper;
                _githubAccountBusinessRules = githubAccountBusinessRules;
            }

            public async Task<UpdatedGithubAccountDto> Handle(UpdateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                await _githubAccountBusinessRules.GithubUrlCanNotBeDuplicatedWhenInserted(request.GithubUrl);

                GithubAccount mappedGithubAccount = _mapper.Map<GithubAccount>(request);
                GithubAccount updatedGithubAccount = await _githubAccountRepository.UpdateAsync(mappedGithubAccount);
                UpdatedGithubAccountDto updatedGithubAccountDto = _mapper.Map<UpdatedGithubAccountDto>(updatedGithubAccount);

                return updatedGithubAccountDto;
            }
        }
    }
}