using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class GithubAccount : Entity
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }

        public virtual User? User { get; set; }

        public GithubAccount()
        {
        }

        public GithubAccount(int id, int userId, string githubUrl) : this()
        {
            Id = id;
            UserId = userId;
            GithubUrl = githubUrl;
        }
    }
}