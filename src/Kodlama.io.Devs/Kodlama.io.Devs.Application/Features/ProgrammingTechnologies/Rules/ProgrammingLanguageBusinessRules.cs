using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository programmingTechnologyRepository)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
        }
        
        public async Task ProgrammingTechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologyRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming technology name exists.");
        }

        public async Task FindTheProgrammingTechnologyYouWantToDelete(int id)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologyRepository.GetListAsync(p => p.Id == id);
            if (result.Items == null) throw new BusinessException("Programming technology can not found.");
        }

    }
}
