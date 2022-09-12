using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

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

        public async Task FindTheProgrammingLanguageYouWantToDelete(int id)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Id == id);
            if (result.Items == null) throw new BusinessException("Programming language can not found.");
        }

        public void ProgrammingLanguageExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested programming language does not exist!");
        }
    }
}