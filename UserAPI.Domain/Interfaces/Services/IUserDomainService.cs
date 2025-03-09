using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Domain.Entities;

namespace UserAPI.Domain.Interfaces.Services
{
    public interface IUserDomainService
    {
        void CreateUser(User user);
        User Authenticate(string email, string password);
        User RecoverPasssword(string email);
        User UpdateData(Guid id, string name, string password);
    }
}
