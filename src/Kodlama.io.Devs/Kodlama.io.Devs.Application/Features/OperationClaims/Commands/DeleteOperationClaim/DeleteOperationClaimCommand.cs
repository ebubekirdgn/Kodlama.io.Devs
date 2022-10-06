using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using static Kodlama.io.Devs.Application.Features.OperationClaims.Constants.OperationClaims;
using static Kodlama.io.Devs.Domain.Constants.OperationClaims;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Admin, Delete };
    }
}
