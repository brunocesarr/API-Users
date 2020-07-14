using Autofac;
using API.Users.Application.Interfaces;
using API.Users.Application.Service;
using API.Users.Domain.Core.Interfaces.Repositorys;
using API.Users.Domain.Core.Interfaces.Services;
using API.Users.Domain.Services.Services;
using API.Users.Infrastructure.CrossCutting.Adapter.Interfaces;
using API.Users.Infrastructure.CrossCutting.Adapter.Map;
using API.Users.Infrastructure.Repository.Repositorys;

namespace API.Users.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceUser>().As<IServiceUser>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperUser>().As<IMapperUser>();
            #endregion

            #endregion
        }
    }
}