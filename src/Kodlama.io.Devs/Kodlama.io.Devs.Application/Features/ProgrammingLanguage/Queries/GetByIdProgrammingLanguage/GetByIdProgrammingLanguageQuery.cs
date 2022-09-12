using AutoMapper;
using Kodlama.io.Devs.Application.Features.Dtos;
using Kodlama.io.Devs.Application.Features.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguage.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto>
        {
            private readonly IProgrammingLanguagesRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguagesRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

                _programmingLanguageBusinessRules.ProgrammingLanguageExistWhenRequested(programmingLanguage);

                ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage); // !!!

                return programmingLanguageGetByIdDto;
            }
        }
    }
}