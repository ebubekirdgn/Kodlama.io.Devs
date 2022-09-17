namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommand : IRequest<CreatedProgrammingTechnologyDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand, CreatedProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public CreateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository ProgrammingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules ProgrammingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = ProgrammingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = ProgrammingTechnologyBusinessRules;
            }

            public async Task<CreatedProgrammingTechnologyDto> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programmingTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);
                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology createdProgrammingTechnology = await _programmingTechnologyRepository.AddAsync(mappedProgrammingTechnology);
                CreatedProgrammingTechnologyDto createdProgrammingTechnologyDto = _mapper.Map<CreatedProgrammingTechnologyDto>(createdProgrammingTechnology);

                return createdProgrammingTechnologyDto;
            }
        }
    }
}