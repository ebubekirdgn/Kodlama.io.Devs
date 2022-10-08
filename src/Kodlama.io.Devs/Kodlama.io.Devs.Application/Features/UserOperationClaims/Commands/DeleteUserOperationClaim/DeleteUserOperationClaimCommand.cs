using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using static Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants.UserOperationClaims;
using static Kodlama.io.Devs.Domain.Constants.OperationClaims;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Admin, Delete };
    }
}