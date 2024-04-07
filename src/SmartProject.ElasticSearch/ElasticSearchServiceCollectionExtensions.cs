using System;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace SmartProject.ElasticSearch
{
	public static class ElasticSearchServiceCollectionExtensions
	{
        public static IServiceCollection AddElasticsearch(this IServiceCollection services, ElasticSearchOptions elasticSearchOptions)
        {
            var settings = new ConnectionSettings(new Uri(elasticSearchOptions.Url));

            if (!string.IsNullOrEmpty(elasticSearchOptions.DefaultIndex))
                settings = settings.DefaultIndex(elasticSearchOptions.DefaultIndex);

            if (elasticSearchOptions.AuthenticationRequired)
                settings = settings.BasicAuthentication(elasticSearchOptions.AuthenticationUser, elasticSearchOptions.AuthenticationPassword);

            settings.EnableApiVersioningHeader();

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
            services.AddSingleton<IElasticSearchService, ElasticSearchService>();

            return services;
        }
    }
}

