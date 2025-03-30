using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Domain.Entities;
using UserAPI.Domain.Interfaces.Messages;

namespace UserAPI.Infrastructure.Messages
{
    public class UserMessageProducer : IUserMessage
    {
        public void SendPasswordRecoveryMessage(User user)
        {
            #region Conexão com o servidor do RabittMQ
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri("amqps://aoioxrbb:LUKCybdVHw526-YJfOBNpi__POLXFZc3@gull.rmq.cloudamqp.com/aoioxrbb")
            };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    //Criar a fila onde iremos escrever as mensagens de recuperação de senha dos users.
                    model.QueueDeclare(
                        queue :"recoverPassword", //nome da fila
                        durable: true, //a fila nunca irá perder os conteúdos
                        exclusive: false, //a fila aceita multiplas conexões
                        autoDelete: false, //os itens da fila não são removidos automaticamentes
                        arguments: null
                        );

                    //Escrever os dados do usuário que solicitou a recuperação da senha (conteúdo) na fila
                    model.BasicPublish(
                        exchange: string.Empty,
                        routingKey: "recoverPassword",
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user))
                        );
                }
            }
            #endregion
        }
    }
}
