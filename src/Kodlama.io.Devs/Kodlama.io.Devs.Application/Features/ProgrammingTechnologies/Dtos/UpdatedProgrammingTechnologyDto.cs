namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos
{
    public class UpdatedProgrammingTechnologyDto : BaseProgrammingTechnologyDto
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
    }
}