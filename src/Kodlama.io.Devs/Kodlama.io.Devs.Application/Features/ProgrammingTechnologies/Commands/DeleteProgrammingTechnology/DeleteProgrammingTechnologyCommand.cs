﻿namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology
{
    public class DeleteProgrammingTechnologyCommand : IRequest<DeletedProgrammingTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingTechnologyCommandHandler : IRequestHandler<DeleteProgrammingTechnologyCommand, DeletedProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public DeleteProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<DeletedProgrammingTechnologyDto> Handle(DeleteProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programmingTechnologyBusinessRules.FindTheProgrammingTechnologyYouWantToDelete(request.Id);

                ProgrammingTechnology findDataForDeletedProgrammingTechnology = await _programmingTechnologyRepository.GetAsync(p => p.Id == request.Id);
                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(findDataForDeletedProgrammingTechnology);
                ProgrammingTechnology deletedProgrammingTechnology = await _programmingTechnologyRepository.DeleteAsync(mappedProgrammingTechnology);
                DeletedProgrammingTechnologyDto deletedProgrammingTechnologyDto = _mapper.Map<DeletedProgrammingTechnologyDto>(deletedProgrammingTechnology);

                return deletedProgrammingTechnologyDto;
            }
        }
    }
}