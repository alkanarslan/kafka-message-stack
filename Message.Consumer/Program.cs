using System;
using Confluent.Kafka;

namespace Message.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Consumer");
            var topicName = "dev-topic";
            var kafkaUrl = "192.168.2.184:9092";
            var config = new ConsumerConfig {GroupId = "group1", BootstrapServers = kafkaUrl};
            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe(topicName);
                while (true)
                {
                    var consumeResult = consumer.Consume();
                    //Mail gonderme, Notifiction Gonderme vs gibi işler yapab bir bussinnes düşünelim.
                    
                    Console.WriteLine($"Received message at {consumeResult.TopicPartitionOffset}: {consumeResult.Message.Value}");
                    consumer.Commit();
                }
            }
        }
    }
}