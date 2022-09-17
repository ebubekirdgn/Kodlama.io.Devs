namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos
{
    public class CreatedProgrammingTechnologyDto : BaseProgrammingTechnologyDto
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
    }
}