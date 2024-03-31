using System;
using Confluent.Kafka;

namespace SmartProject.Kafka
{
    public class KafkaConsumerConfig<Tk, Tv> : ConsumerConfig
    {
        public required string Topic { get; set; }

        public KafkaConsumerConfig()
        {
            AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
            EnableAutoOffsetStore = false;
        }
    }
}

