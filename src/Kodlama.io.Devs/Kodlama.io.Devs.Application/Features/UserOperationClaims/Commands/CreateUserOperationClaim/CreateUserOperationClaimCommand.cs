using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using static Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants.UserOperationClaims;
using static Kodlama.io.Devs.Domain.Constants.OperationClaims;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>, ISecuredRequest
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public string[] Roles => new[] { Admin, Add };
    }
}