using API.Users.Application.DTO.DTO.Github;
using API.Users.Domain.Models.Github;
using System.Collections.Generic;

namespace API.Users.Infrastructure.CrossCutting.Adapter.Interfaces.Github
{
    public interface IMapperGithubProject
    {
        #region Mappers
        Project MapperToEntity(ProjectDTO projectDto);

        List<ProjectDTO> MapperProjects(List<Project> projects);

        ProjectDTO MapperToDTO(Project project);
        #endregion
    }
}
