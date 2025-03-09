using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public override string Message => "Acesso não encontrado.";
    }
}
