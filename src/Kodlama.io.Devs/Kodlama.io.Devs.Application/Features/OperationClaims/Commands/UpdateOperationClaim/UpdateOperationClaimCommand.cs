using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using static Kodlama.io.Devs.Application.Features.OperationClaims.Constants.OperationClaims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Kodlama.io.Devs.Domain.Constants.OperationClaims;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string[] Roles => new[] { Admin, Update };
    }
}