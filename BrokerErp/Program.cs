using BrokerErp.DTO;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net.Http;
using System.Text;

namespace BrokerErp
{
    class Program
    {
        static void Main(string[] args)
        {
            // CONSUMER
            //creation of the listener
            var factory = new ConnectionFactory
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

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                PostcreateUser(body);
            };
            channel.BasicConsume("user-erp", true, consumer);

            Console.WriteLine("------------- Consummer ERP connected -------------");
            Console.ReadLine();
        }

        static private async void PostcreateUser(byte[] userByte)
        {
            var userString = Encoding.UTF8.GetString(userByte);

            var user = JsonConvert.DeserializeObject<UserDTO>(userString);

            user.Id = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44349/api-erp/UserSynch");

            Console.WriteLine("Un nouvel utilisateur a été crée dans l'app Madera");
            Console.WriteLine(JsonConvert.SerializeObject(userString));

            //call web api with the validated payment
            var response = await client.PostAsync(client.BaseAddress, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            if (response != null)
            {
                Console.WriteLine(response.ToString());
            }
        }
    }
}
