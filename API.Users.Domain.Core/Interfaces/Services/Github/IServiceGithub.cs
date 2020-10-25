using API.Users.Domain.Models.Github;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Users.Domain.Core.Interfaces.Services.Github
{
    public interface IServiceGithub
    {
        Task<List<Project>> GetProjects(string username);
    }
}
