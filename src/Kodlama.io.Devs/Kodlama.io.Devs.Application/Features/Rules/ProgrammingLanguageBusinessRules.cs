using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Features.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguagesRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguagesRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming language name exists.");
        }
    }
}
