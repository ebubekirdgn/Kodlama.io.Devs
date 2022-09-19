using Kodlama.io.Devs.Application.Features.SocialMedia.Github.Commands.CreateGithubAccounts;
using Kodlama.io.Devs.Application.Features.SocialMedia.Github.Commands.DeleteGithubAccounts;
using Kodlama.io.Devs.Application.Features.SocialMedia.Github.Commands.UpdateGithubAccounts;
using Kodlama.io.Devs.Application.Features.SocialMedia.Github.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubAccountsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGithubAccountCommand command)
        {
            CreatedGithubAccountDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGithubAccountCommand command)
        {

            DeletedGithubAccountDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubAccountCommand command)
        {
            UpdatedGithubAccountDto result = await Mediator.Send(command);
            return Created("", result);
        }
    }
}
