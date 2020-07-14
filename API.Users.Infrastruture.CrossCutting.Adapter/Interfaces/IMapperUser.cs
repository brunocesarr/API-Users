using API.Users.Application.DTO.DTO;
using API.Users.Domain.Models;
using System.Collections.Generic;

namespace API.Users.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperUser
    {
        #region Mappers
        User MapperToEntity(UserDTO userDTO);

        IEnumerable<UserDTO> MapperListClientes(IEnumerable<User> users);

        UserDTO MapperToDTO(User user);
        #endregion
    }
}
