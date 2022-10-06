using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimShouldExists(int id)
        {
            OperationClaim? result = await _operationClaimRepository.GetAsync(x => x.Id == id);
            if (result == null) throw new BusinessException("Not exists");
        }

        public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Operation Claim name exists");
        }
    }
}