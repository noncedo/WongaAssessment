using RabbitMQ.Client;
using System;

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

            //used default connection
             var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("message-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            string name = "";
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.ReadLine();

            var message = new { Name = "Producer", Message = name };

          
          
        }
    }
}
