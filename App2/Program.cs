using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;


namespace App2
{
    static class Program
    {
       
        static void Main(string[] args)
        {
            ReceiveMessage();
            Console.ReadLine();
        }
    
        public static void ReceiveMessage()
        {
            var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("message-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Hello {0},  I am your Father!", message);
            };

            channel.BasicConsume("message-queue", true, consumer);

        }

    }
}
