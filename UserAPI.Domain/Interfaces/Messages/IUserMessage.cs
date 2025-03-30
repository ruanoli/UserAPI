using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Domain.Entities;

namespace UserAPI.Domain.Interfaces.Messages
{
    /// <summary>
    /// Interface para definir métodos de envio de mensagens / notificações
    /// de usuários. Esta interface será implementada por uma infra de mensageria
    /// com RabittMQ
    /// </summary>
    public interface IUserMessage
    {
        //enviar notificação para fila da mensageria
        void SendPasswordRecoveryMessage(User user);
    }
}
