namespace Kodlama.io.Devs.Application.Features.SocialMedia.Github.Commands.DeleteGithubAccounts
{
    public class DeleteGithubAccountCommand : IRequest<DeletedGithubAccountDto>
    {
        public int Id { get; set; }

        public class DeleteGithubAccountCommandHandler : IRequestHandler<DeleteGithubAccountCommand, DeletedGithubAccountDto>
        {
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly IMapper _mapper;
            private readonly GithubAccountBusinessRules _githubAccountBusinessRules;

            public DeleteGithubAccountCommandHandler(IGithubAccountRepository githubAccountRepository, IMapper mapper, GithubAccountBusinessRules githubAccountBusinessRules)
            {
                _githubAccountRepository = githubAccountRepository;
                _mapper = mapper;
                _githubAccountBusinessRules = githubAccountBusinessRules;
            }

            public async Task<DeletedGithubAccountDto> Handle(DeleteGithubAccountCommand request, CancellationToken cancellationToken)
            {
                await _githubAccountBusinessRules.FindTheGithubAccountUrlYouWantToDelete(request.Id);

                GithubAccount findDataForDeletedGithubAccount = await _githubAccountRepository.GetAsync(p => p.Id == request.Id);
                GithubAccount mappedGithubAccount = _mapper.Map<GithubAccount>(findDataForDeletedGithubAccount);
                GithubAccount deletedGithubAccount = await _githubAccountRepository.DeleteAsync(mappedGithubAccount);
                DeletedGithubAccountDto deletedGithubAccountDto = _mapper.Map<DeletedGithubAccountDto>(deletedGithubAccount);

                return deletedGithubAccountDto;
            }
        }
    }
}