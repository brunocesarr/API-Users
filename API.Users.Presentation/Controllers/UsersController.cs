using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Users.Application.DTO.DTO;
using API.Users.Application.Interfaces;
using System.Collections;

namespace API.Users.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;

        public UsersController(IApplicationServiceUser ApplicationServiceUser)
        {
            _applicationServiceUser = ApplicationServiceUser;
        }

        // GET api/users
        /// <summary>
        /// Get all users
        /// </summary>
        /// <remarks>
        /// Get a list of all users
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            return Ok(_applicationServiceUser.GetAll());
        }

        // GET api/users/{id}
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <remarks>
        /// Get a users
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> Get(int id)
        {
            try
            {
                var user = _applicationServiceUser.GetById(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/users
        [HttpPost]
        public ActionResult Post([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Add(userDTO);
                return Ok("Cliente Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/users/{id}
        [HttpPut]
        public ActionResult Put([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Update(userDTO);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/users/{id}
        [HttpDelete()]
        public ActionResult Delete([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return NotFound();

                _applicationServiceUser.Remove(userDTO);
                return Ok("Cliente Removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
