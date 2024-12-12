using RabbitMQ.Client;
using System.Text.Json;

namespace CareerService.Src.Services.RabbitMQ
{
    public class MessagePublisher
    {
        private readonly IConnection _connection;

        public MessagePublisher(IConnection connection)
        {
            _connection = connection;
        }

        public void Publish<T>(string queueName, T message)
        {
            using var channel = _connection.CreateModel();
            var body = System.Text.Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            channel.BasicPublish(exchange: "",
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($"Message published to queue '{queueName}': {message}");
        }
    }
}
