using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, OperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<OperationClaimDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.OperationClaimShouldExists(request.Id);
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
            OperationClaimDto operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);
            return operationClaimDto;
        }
    }
}