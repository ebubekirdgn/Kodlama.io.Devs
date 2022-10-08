using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim
{
    public class GetByIdUserOperationClaimQuery : IRequest<UserOperationClaimGetByIdDto>
    {
        public int Id { get; set; }
    }
}