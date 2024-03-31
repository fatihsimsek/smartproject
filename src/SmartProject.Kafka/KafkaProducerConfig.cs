using System;
using Confluent.Kafka;

namespace SmartProject.Kafka
{
    public class KafkaProducerConfig<Tk, Tv> : ProducerConfig
    {
        public required string Topic { get; set; }
    }
}

