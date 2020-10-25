using API.Users.Domain.Core.Interfaces.Repositorys;
using API.Users.Domain.Core.Interfaces.Services.Github;
using API.Users.Domain.Models.Github;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System;

namespace API.Users.Domain.Services.Services.Github
{
    public class ServiceGithub : IServiceGithub
    {
        public readonly IHttpClientFactory _clientFactory;

        public ServiceGithub(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Project>> GetProjects(string username)
        {
            try
            {
                var projects = new List<Project>();

                var request = new HttpRequestMessage(HttpMethod.Get, $"users/{username}/repos");
                var client = _clientFactory.CreateClient("github");
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    projects.AddRange(
                        await JsonSerializer
                            .DeserializeAsync<List<Project>>(responseStream)
                    );
                }
                else
                {
                    throw new HttpRequestException("Erro na requisição!");
                }

                return projects;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
