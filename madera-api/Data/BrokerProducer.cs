using madera_api.DTO;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace madera_api.Data
{
    static public class BrokerProducer
    {
        public static void publishMessage(UserDTO userDto)
        {
            //borker queue creation
            var factory = new RabbitMQ.Client.ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("user-erp",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            //convert payment in json
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(userDto));

            //send message to broker
            channel.BasicPublish("", "user-erp", null, body);
        }
    }
}
