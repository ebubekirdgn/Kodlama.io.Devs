using Core.Security.Dtos;
using Kodlama.io.Devs.Application.Features.Auths.Dtos;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Register
{
    public class RegisterCommand : IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string ipAddress { get; set; }
    }
}