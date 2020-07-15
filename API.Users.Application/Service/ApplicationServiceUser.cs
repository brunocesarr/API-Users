using API.Users.Application.DTO.DTO;
using API.Users.Application.Interfaces;
using API.Users.Domain.Core.Interfaces.Services;
using API.Users.Infrastructure.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace API.Users.Application.Service
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser _serviceUser;
        private readonly IMapperUser _mapperUser;

        public ApplicationServiceUser(IServiceUser ServiceUser, IMapperUser MapperUser)
        {
            _serviceUser = ServiceUser;
            _mapperUser = MapperUser;
        }


        public void Add(UserDTO obj)
        {
            var objUsers = _mapperUser.MapperToEntity(obj);
            _serviceUser.Add(objUsers);
        }

        public void Dispose()
        {
            _serviceUser.Dispose();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var objUsers = _serviceUser.GetAll();
            return _mapperUser.MapperListClientes(objUsers);
        }

        public UserDTO GetById(int id)
        {
            var objUsers = _serviceUser.GetById(id);
            return _mapperUser.MapperToDTO(objUsers);
        }

        public void Remove(UserDTO obj)
        {
            var objUsers = _mapperUser.MapperToEntity(obj);
            _serviceUser.Remove(objUsers);
        }

        public void Update(UserDTO obj)
        {
            var objUsers = _mapperUser.MapperToEntity(obj);
            _serviceUser.Update(objUsers);
        }
    }
}
