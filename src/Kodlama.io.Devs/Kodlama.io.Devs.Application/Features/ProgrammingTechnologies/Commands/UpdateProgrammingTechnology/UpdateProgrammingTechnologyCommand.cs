namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommand : IRequest<UpdatedProgrammingTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingTechnologyCommandHandler : IRequestHandler<UpdateProgrammingTechnologyCommand, UpdatedProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public UpdateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository,
                IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<UpdatedProgrammingTechnologyDto> Handle(UpdateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programmingTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology updatedProgrammingTechnology = await _programmingTechnologyRepository.UpdateAsync(mappedProgrammingTechnology);
                UpdatedProgrammingTechnologyDto updatedProgrammingTechnologyDto = _mapper.Map<UpdatedProgrammingTechnologyDto>(updatedProgrammingTechnology);

                return updatedProgrammingTechnologyDto;
            }
        }
    }
}