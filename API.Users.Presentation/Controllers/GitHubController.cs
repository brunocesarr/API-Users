using API.Users.Application.DTO.DTO.Github;
using API.Users.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Users.Presentation.Controllers
{
    [Route("api/github")]
    [ApiController]
    [Produces("application/json")]
    public class GitHubController : Controller
    {
        private readonly IApplicationServiceGithub _applicationServiceGitHub;

        public GitHubController(IApplicationServiceGithub applicationServiceGitHub)
        {
            _applicationServiceGitHub = applicationServiceGitHub;
        }
        // GET api/github/{id}
        /// <summary>
        /// Get projects by username github
        /// </summary>
        /// <remarks>
        /// Get projects by username github
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet("{username}/projects")]
        [ProducesResponseType(typeof(List<ProjectDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult GetProjects(string username)
        {
            try
            {
                var userProjects = _applicationServiceGitHub.GetProjects(username).Result;

                if (!userProjects.Any())
                    return NoContent();

                return Ok(userProjects);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
