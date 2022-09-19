namespace Kodlama.io.Devs.Application.Features.SocialMedia.Github.Commands.CreateGithubAccounts
{
    public class CreateGithubAccountCommand : IRequest<CreatedGithubAccountDto>
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }

        public class CreateGithubAccountCommandHandler : IRequestHandler<CreateGithubAccountCommand, CreatedGithubAccountDto>
        {
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly IMapper _mapper;
            private readonly GithubAccountBusinessRules _githubAccountBusinessRules;

            public CreateGithubAccountCommandHandler(IGithubAccountRepository githubAccountRepository, IMapper mapper, GithubAccountBusinessRules githubAccountBusinessRules)
            {
                _githubAccountRepository = githubAccountRepository;
                _mapper = mapper;
                _githubAccountBusinessRules = githubAccountBusinessRules;
            }

            public async Task<CreatedGithubAccountDto> Handle(CreateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                await _githubAccountBusinessRules.GithubUrlCanNotBeDuplicatedWhenInserted(request.GithubUrl);

                GithubAccount mappedGithubAccount = _mapper.Map<GithubAccount>(request);
                GithubAccount createdGithubAccount = await _githubAccountRepository.AddAsync(mappedGithubAccount);
                CreatedGithubAccountDto createdGithubAccountDto = _mapper.Map<CreatedGithubAccountDto>(createdGithubAccount);

                return createdGithubAccountDto;
            }
        }
    }
}