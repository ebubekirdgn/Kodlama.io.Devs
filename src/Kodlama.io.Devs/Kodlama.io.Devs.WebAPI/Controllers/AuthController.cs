using Core.Security.Dtos;
using Kodlama.io.Devs.Application.Features.Auths.Commands.Login;
using Kodlama.io.Devs.Application.Features.Auths.Commands.Register;
using Kodlama.io.Devs.Application.Features.Auths.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, ipAddress = getIpAddress() };
            RegisteredDto result = await Mediator.Send(registerCommand);
            return Created("", result.AccessToken);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, ipAddress = getIpAddress() };
            LoginDto result = await Mediator.Send(loginCommand);
            return Ok(result.CreateResponseDto());
        }
    }
}