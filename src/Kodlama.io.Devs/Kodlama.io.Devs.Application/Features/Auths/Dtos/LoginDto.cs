using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Features.Auths.Dtos
{
    public class LoginDto
    {
        public AccessToken? AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public AuthenticatorType? AuthenticatorType { get; set; }

        public LoginResponseDto CreateResponseDto()
        {
            return new() { AccessToken = AccessToken, AuthenticatorType = AuthenticatorType };
        }

        public class LoginResponseDto
        {
            public AccessToken? AccessToken { get; set; }
            public AuthenticatorType? AuthenticatorType { get; set; }
        }
    }
}
