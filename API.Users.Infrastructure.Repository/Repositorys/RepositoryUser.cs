using API.Users.Domain.Core.Interfaces.Repositorys;
using API.Users.Infrastructure.Data;
using API.Users.Domain.Models;

namespace API.Users.Infrastructure.Repository.Repositorys
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly SqlContext _context;
        public RepositoryUser(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
