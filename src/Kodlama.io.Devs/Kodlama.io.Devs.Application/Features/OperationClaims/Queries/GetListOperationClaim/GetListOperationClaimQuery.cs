using Kodlama.io.Devs.Application.Features.OperationClaims.Models;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}