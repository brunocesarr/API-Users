using API.Users.Domain.Core.Interfaces.Repositorys;
using API.Users.Domain.Core.Interfaces.Services;
using API.Users.Domain.Models;

namespace API.Users.Domain.Services.Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        public readonly IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser RepositoryUser)
            : base(RepositoryUser)
        {
            _repositoryUser = RepositoryUser;
        }

    }
}
