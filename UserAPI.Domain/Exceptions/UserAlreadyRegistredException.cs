using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Domain.Exceptions
{
    public class UserAlreadyRegistredException : Exception
    {
        public override string Message => "Acesso já está cadastrado no sistema. Verifique o e-mail informado.";
    }
}
