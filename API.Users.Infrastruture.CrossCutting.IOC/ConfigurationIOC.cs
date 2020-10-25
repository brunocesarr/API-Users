using Autofac;
using API.Users.Application.Interfaces;
using API.Users.Application.Service;
using API.Users.Domain.Core.Interfaces.Repositorys;
using API.Users.Domain.Core.Interfaces.Services;
using API.Users.Domain.Services.Services;
using API.Users.Infrastructure.CrossCutting.Adapter.Interfaces;
using API.Users.Infrastructure.CrossCutting.Adapter.Map;
using API.Users.Infrastructure.Repository.Repositorys;
using API.Users.Domain.Services.Services.Github;
using API.Users.Domain.Core.Interfaces.Services.Github;
using API.Users.Infrastructure.CrossCutting.Adapter.Map.Github;
using API.Users.Infrastructure.CrossCutting.Adapter.Interfaces.Github;

namespace API.Users.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();
            builder.RegisterType<ApplicationServiceGithub>().As<IApplicationServiceGithub>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceUser>().As<IServiceUser>();
            builder.RegisterType<ServiceGithub>().As<IServiceGithub>();
            #endregion

            #region IOC Repositorys
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperUser>().As<IMapperUser>();
            builder.RegisterType<MapperGithubProject>().As<IMapperGithubProject>();
            #endregion

            #endregion
        }
    }
}