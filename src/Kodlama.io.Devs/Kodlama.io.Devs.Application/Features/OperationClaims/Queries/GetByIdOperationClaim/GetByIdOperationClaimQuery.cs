using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQuery : IRequest<OperationClaimDto>
    {
        public int Id { get; set; }
    }
}
