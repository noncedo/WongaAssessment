using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace App1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

             var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("message-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            
            var message = new { Name = "Producer", Message = "Noncedo" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message.Message));

            channel.BasicPublish("", "message-queue", null, body);
          
        }
    }
}
