using API.Users.Application.DTO.DTO;
using API.Users.Application.Interfaces;
using API.Users.Domain.Core.Interfaces.Services;
using API.Users.Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
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
            try
            {
                ValidaUserDtoRequisicao(obj);

                var objUsers = _mapperUser.MapperToEntity(obj);

                _serviceUser.Add(objUsers);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
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
            try
            {
                ValidaIdDaRequisicao(id);

                var objUsers = _serviceUser.GetById(id);
                
                return _mapperUser.MapperToDTO(objUsers);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Remove(UserDTO obj)
        {
            try
            {
                ValidaUserDtoRequisicao(obj);

                var objUsers = _mapperUser.MapperToEntity(obj);

                _serviceUser.Remove(objUsers);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Update(UserDTO obj)
        {
            try
            {
                ValidaUserDtoRequisicao(obj);

                var objUsers = _mapperUser.MapperToEntity(obj);

                _serviceUser.Update(objUsers);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #region private methods
        private void ValidaIdDaRequisicao(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("ID inválido!");
            }
        }

        private void ValidaUserDtoRequisicao(UserDTO userDto)
        {
            if(userDto == null)
            {
                throw new ArgumentException("User inválido!");
            }
        }
        #endregion
    }
}
