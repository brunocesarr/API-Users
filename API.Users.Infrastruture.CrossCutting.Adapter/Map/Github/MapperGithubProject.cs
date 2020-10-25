using API.Users.Application.DTO.DTO.Github;
using API.Users.Domain.Models.Github;
using API.Users.Infrastructure.CrossCutting.Adapter.Interfaces.Github;
using System.Collections.Generic;

namespace API.Users.Infrastructure.CrossCutting.Adapter.Map.Github
{
    public class MapperGithubProject : IMapperGithubProject
    {
        #region properties

        private readonly List<ProjectDTO> ProjectsDto = new List<ProjectDTO>();

        #endregion

        #region methods
        public List<ProjectDTO> MapperProjects(List<Project> projects)
        {
            foreach (var project in projects)
            {
                ProjectDTO userDTO = new ProjectDTO
                {
                    Name = project.Name,
                    FullName = project.FullName,
                };

                ProjectsDto.Add(userDTO);
            }
            return ProjectsDto;
        }

        public ProjectDTO MapperToDTO(Project project)
        {
            ProjectDTO projectDto = new ProjectDTO
            {
                Name = project.Name,
                FullName = project.FullName,
            };

            return projectDto;
        }

        public Project MapperToEntity(ProjectDTO projectDto)
        {
            Project project = new Project
            {
                Name = projectDto.Name,
                FullName = projectDto.FullName,
            };

            return project;
        }
        #endregion
    }
}
