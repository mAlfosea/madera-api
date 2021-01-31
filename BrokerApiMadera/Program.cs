using BrokerApiMadera.DTO;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net.Http;
using System.Text;

namespace BrokerApiMadera
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
            channel.QueueDeclare("user-api",
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
            channel.BasicConsume("user-api", true, consumer);

            Console.ReadLine();
        }

        static private async void PostcreateUser(byte[] userByte)
        {
            var userString = Encoding.UTF8.GetString(userByte);

            var user = JsonConvert.DeserializeObject<UserDTO>(userString);

            user.Id = 0;

            Console.WriteLine(JsonConvert.SerializeObject(user));


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5001/api/UserSynch");

            //call web api with the validated payment
            var response = await client.PostAsync(client.BaseAddress, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            if (response != null)
            {
                Console.WriteLine(response.ToString());
            }
        }
    }
}
