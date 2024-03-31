﻿using System;
using Confluent.Kafka;
using System.Text;
using System.Text.Json;

namespace SmartProject.Kafka
{
    internal sealed class KafkaSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            if (typeof(T) == typeof(Null))
                return null;

            if (typeof(T) == typeof(Ignore))
                throw new NotSupportedException("Not Supported.");

            var json = JsonSerializer.Serialize(data);

            return Encoding.UTF8.GetBytes(json);
        }
    }
}

