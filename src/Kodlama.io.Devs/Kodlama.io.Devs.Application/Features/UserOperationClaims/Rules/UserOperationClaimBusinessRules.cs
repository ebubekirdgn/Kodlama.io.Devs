using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserRepository _userRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userRepository = userRepository;
        }

        public async Task UserOperationClaimShouldExists(int id)
        {
            var result = await _userOperationClaimRepository.GetAsync(x => x.Id == id);
            if (result is null) throw new BusinessException("Role Not exists");
        }

        public async Task UserShouldExists(int id)
        {
            var result = await _userRepository.GetAsync(x => x.Id == id);
            if (result is null) throw new BusinessException("User Not exists");
        }

        public void UserOperationClaimShouldExistToDelete(UserOperationClaim userOperationClaims)
        {
            if (userOperationClaims is null)
                throw new BusinessException("User Role Action Does Not Exist");
        }
    }
}