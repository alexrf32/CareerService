using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace CareerService.Src.Services.RabbitMQ
{
    public class MessageConsumer
    {
        private readonly IConnection _connection;

        public MessageConsumer(IConnection connection)
        {
            _connection = connection;
        }

        public void StartConsuming<T>(string queueName, Action<T> onMessageReceived)
        {
            using var channel = _connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(body));
                onMessageReceived(message);
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            Console.WriteLine($"Started consuming messages from queue '{queueName}'");
        }
    }
}
