using API.Users.Application.DTO.DTO;
using API.Users.Domain.Models;
using API.Users.Infrastructure.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace API.Users.Infrastructure.CrossCutting.Adapter.Map
{
    public class MapperUser : IMapperUser
    {
        #region properties

        List<UserDTO> userDTOs = new List<UserDTO>();

        #endregion


        #region methods
        public IEnumerable<UserDTO> MapperListClientes(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                UserDTO userDTO = new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Email = user.Email
                };

                userDTOs.Add(userDTO);
            }
            return userDTOs;
        }

        public UserDTO MapperToDTO(User user)
        {
            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email
            };

            return userDTO;
        }

        public User MapperToEntity(UserDTO userDTO)
        {
            User user = new User
            {
                Id = userDTO.Id,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Username = userDTO.Username,
                Email = userDTO.Email
            };
            return user;
        }
        #endregion
    }
}
