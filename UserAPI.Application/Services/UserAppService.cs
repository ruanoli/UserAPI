using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Application.Interfaces;
using UserAPI.Application.Models;
using UserAPI.Domain.Entities;
using UserAPI.Domain.Interfaces.Services;

namespace UserAPI.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService _userDomainService;

        public UserAppService(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        public AuthenticateResponseModel Authenticate(AuthenticateRequestModel model)
        {
            var user = _userDomainService.Authenticate(model.Email, model.Password);

            return new AuthenticateResponseModel
            {
                Id = user.Id,
                Name = user.Email,
                Email = user.Password,
                AccessDate = DateTime.Now
            };
        }

        public CreateAccountResponseModel CreateAccount(CreateAccountRequestModel model)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                LastUpdateDate = DateTime.Now,
                RegisterDate = DateTime.Now
            };

            _userDomainService.CreateUser(user);

            return new CreateAccountResponseModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                DateTimeRegister = user.RegisterDate
            };
        }

        public RecoverPasswordResponseModel RecoverPassword(RecoverPasswordRequestModel model)
        {
            var user = _userDomainService.RecoverPasssword(model.Email);

            return new RecoverPasswordResponseModel
            {
                Id =user.Id,
                Name = user.Name,
                Email = user.Email,
                RecoverPasswordDateTime = DateTime.Now,
            };
        }
    }
}
