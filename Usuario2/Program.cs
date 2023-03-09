using System.Text;
using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "Message",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);


const string message = "Mesage del chat usuario 2";

/*
string message name;

Console.WriteLine("Enter your name: ");


name = Console.ReadLine();*/

var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: string.Empty,
                     routingKey: "Message",
                     basicProperties: null,
                     body: body);
Console.WriteLine($" [x] Enviado a usuario 1: {message}");