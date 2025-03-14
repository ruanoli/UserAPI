using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Application.Models;

namespace UserAPI.Application.Interfaces
{
    /// <summary>
    /// Interface de serviços da aplicação
    /// </summary>
    public interface IUserAppService
    {
        AuthenticateResponseModel Authenticate(AuthenticateRequestModel model);
        CreateAccountResponseModel CreateAccount(CreateAccountRequestModel model);
        RecoverPasswordResponseModel RecoverPassword(RecoverPasswordRequestModel model);
    }
}
