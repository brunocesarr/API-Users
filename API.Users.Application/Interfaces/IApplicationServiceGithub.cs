using API.Users.Application.DTO.DTO.Github;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Users.Application.Interfaces
{
    public interface IApplicationServiceGithub
    {
        Task<List<ProjectDTO>> GetProjects(string username);
    }
}
