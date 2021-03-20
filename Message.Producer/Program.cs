using Confluent.Kafka;
using System;

namespace Message.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var topicName = "dev-topic";
            var kafkaUrl = "192.168.2.184:9092";
            var config = new ProducerConfig() { BootstrapServers = kafkaUrl, };
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("Enter Message: ");
                    var text = Guid.NewGuid().ToString();
                    var message = new Message<Null, string> { Value = text };
                    var result = producer.ProduceAsync(topicName, message).GetAwaiter().GetResult();
                    Console.WriteLine($"Delivered to : {result.TopicPartitionOffset}");
                }
            }
        }
    }
}
