namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology
{
    public class GetListProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingTechnologyQueryHandler : IRequestHandler<GetListProgrammingTechnologyQuery, ProgrammingTechnologyListModel>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTechnology> programmingTechnologies = await
                    _programmingTechnologyRepository.GetListAsync(include:
                    p => p.Include(pl => pl.ProgramingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                ProgrammingTechnologyListModel mappedProgrammingTechnologies = _mapper.Map<ProgrammingTechnologyListModel>(programmingTechnologies);

                return mappedProgrammingTechnologies;
            }
        }
    }
}