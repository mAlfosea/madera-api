using madera_erp_api.DTO;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madera_erp_api.Data
{
    public class BrokerProducer
    {
       static public void publishMessage(UserDTO userDto)
        {
            //borker queue creation
            var factory = new RabbitMQ.Client.ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("user-api",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            //convert payment in json
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(userDto));

            //send message to broker
            channel.BasicPublish("", "user-api", null, body);
        }
    }
}
