using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Domain.Entities;
using UserAPI.Domain.Exceptions;
using UserAPI.Domain.Helpers;
using UserAPI.Domain.Interfaces.Repositories;
using UserAPI.Domain.Interfaces.Services;

namespace UserAPI.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            var userAlreadyRegistred = _userRepository.Get(user.Email);

            if (userAlreadyRegistred != null)
                throw new UserAlreadyRegistredException();

            user.Password = MD5Helper.Encrypt(user.Password);
            _userRepository.Add(user);
        }

        public User Authenticate(string email, string password)
        {
            var user = _userRepository.Get(email, MD5Helper.Encrypt(password));

            if (user == null)
                throw new AccessDaniedException();

            return user;
        }

        public User RecoverPasssword(string email)
        {
            var user = _userRepository.Get(email);

            if(user == null)
                throw new UserNotFoundException();

            //TODO: Enviar email recuperação de senha para o usuário

            return user;
        }

        public User UpdateData(Guid id, string name, string password)
        {
            var user = _userRepository.GetById(id);

            if(user == null )
                throw new UserNotFoundException();

            if(!string.IsNullOrEmpty(name))
                user.Name = name;

            if (!string.IsNullOrEmpty(password))
                user.Password = MD5Helper.Encrypt(password);
            
            _userRepository.Update(user);

            return user;
        }
    }
}
