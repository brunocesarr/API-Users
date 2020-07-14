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
            var objCliente = _mapperUser.MapperToEntity(obj);
            _serviceUser.Add(objCliente);
        }

        public void Dispose()
        {
            _serviceUser.Dispose();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var objProdutos = _serviceUser.GetAll();
            return _mapperUser.MapperListClientes(objProdutos);
        }

        public UserDTO GetById(int id)
        {
            var objcliente = _serviceUser.GetById(id);
            return _mapperUser.MapperToDTO(objcliente);
        }

        public void Remove(UserDTO obj)
        {
            var objCliente = _mapperUser.MapperToEntity(obj);
            _serviceUser.Remove(objCliente);
        }

        public void Update(UserDTO obj)
        {
            var objCliente = _mapperUser.MapperToEntity(obj);
            _serviceUser.Update(objCliente);
        }
    }
}
