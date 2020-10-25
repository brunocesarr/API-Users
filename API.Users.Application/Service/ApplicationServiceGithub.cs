using API.Users.Application.DTO.DTO.Github;
using API.Users.Application.Interfaces;
using API.Users.Domain.Core.Interfaces.Repositorys;
using API.Users.Domain.Core.Interfaces.Services.Github;
using API.Users.Infrastructure.CrossCutting.Adapter.Interfaces;
using API.Users.Infrastructure.CrossCutting.Adapter.Interfaces.Github;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Users.Application.Service
{
    public class ApplicationServiceGithub : IApplicationServiceGithub
    {
        private readonly IServiceGithub _serviceGithub;
        private readonly IMapperGithubProject _mapperGithubProject;

        public ApplicationServiceGithub(IServiceGithub serviceGithub, IMapperGithubProject mapperGithubProject)
        {
            _serviceGithub = serviceGithub;
            _mapperGithubProject = mapperGithubProject;
        }

        public async Task<List<ProjectDTO>> GetProjects(string username)
        {
            try
            {
                ValidarUsername(username);

                var projects = await _serviceGithub.GetProjects(username);
                
                return _mapperGithubProject.MapperProjects(projects);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #region private methods
        private void ValidarUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username inválido!");
            }
        }
        #endregion
    }
}
