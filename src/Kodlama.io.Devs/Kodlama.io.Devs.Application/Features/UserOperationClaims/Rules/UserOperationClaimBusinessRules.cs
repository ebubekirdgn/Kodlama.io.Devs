using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task UserOperationClaimShouldExists(int id)
        {
            UserOperationClaim? result = await _userOperationClaimRepository.GetAsync(x => x.Id == id);
            if (result == null) throw new BusinessException("Not exists");
        }
    }
}