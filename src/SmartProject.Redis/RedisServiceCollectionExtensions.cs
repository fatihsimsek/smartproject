using System;
using Microsoft.Extensions.DependencyInjection;

namespace SmartProject.Redis
{
	public static class RedisServiceCollectionExtensions
	{
		public static void AddRedis(this IServiceCollection services, RedisOptions options)
		{
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = options.Configuration;
                options.InstanceName = options.InstanceName;
            });

            services.AddSingleton<IRedisCacheService, RedisCacheService>();
        }
	}
}

