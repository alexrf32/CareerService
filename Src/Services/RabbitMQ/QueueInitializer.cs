using RabbitMQ.Client;

namespace CareerService.Src.Services.RabbitMQ
{
    public class QueueInitializer
    {
        private readonly IConnection _connection;

        public QueueInitializer(IConnection connection)
        {
            _connection = connection;
        }

        public void InitializeQueue(string queueName)
        {
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            Console.WriteLine($"Queue '{queueName}' initialized.");
        }
    }
}
