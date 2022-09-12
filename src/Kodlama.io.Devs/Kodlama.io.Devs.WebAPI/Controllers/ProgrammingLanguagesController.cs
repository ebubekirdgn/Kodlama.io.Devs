using Kodlama.io.Devs.Application.Features.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.Dtos;
using Kodlama.io.Devs.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand command)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand command)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand command)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new GetListProgrammingLanguageQuery() { PageRequest = pageRequest };

            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery) //int id olarak verebiliriz.
        {
            ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(programmingLanguageGetByIdDto);
        }
    }
}