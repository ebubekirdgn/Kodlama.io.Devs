using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgrammingTechnology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgrammingLanguage? ProgramingLanguage { get; set; }

        public ProgrammingTechnology()
        {

        }

        public ProgrammingTechnology(int id, int programmingLanguageId, string name) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;

        }
    }
}
