using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Domain.Entities;

namespace UserAPI.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(string email);
        User Get(string email, string password);
    }
}
