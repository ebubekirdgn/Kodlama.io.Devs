using Core.Security.Dtos;
using Kodlama.io.Devs.Application.Features.Auths.Dtos;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoginDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string ipAddress { get; set; }
    }
}
