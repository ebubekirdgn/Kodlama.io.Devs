using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using static Kodlama.io.Devs.Application.Features.OperationClaims.Constants.OperationClaims;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest
    {
        public string Name { get; set; }
        public string[] Roles => new[] { Admin, Add };
    }
}
