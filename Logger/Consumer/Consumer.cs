using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Logger;
using Microsoft.Extensions.Configuration;
using Logger.Consumer.Configuration;

namespace Logger.Consumer
{
    public static class Consumer
    {
        public static void Init(IConfigurationRoot config)
        {
            var section = config.GetSection("RabbitMQConfig");
            RabbitMQConfig rmqConfig = section.Get<RabbitMQConfig>();
            var factory = new ConnectionFactory() { HostName = rmqConfig.Hostname };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                ILogger logger = new Logger.Logger();
                channel.QueueDeclare(queue: rmqConfig.QueueName,
                                     durable: rmqConfig.QueueDurability,
                                     exclusive: rmqConfig.QueueExlusivity,
                                     autoDelete: rmqConfig.QueueAutoDelete,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    logger.Log(new DAO.LogEntry(message));

                };
                channel.BasicConsume(queue: rmqConfig.QueueName,
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
