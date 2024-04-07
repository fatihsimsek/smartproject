using System;
using Nest;

namespace SmartProject.ElasticSearch
{
	public interface IElasticSearchService
	{
        Task AddOrUpdateAsync<T>(string indexName, T model) where T : class;

        Task BulkAddOrUpdateAsync<T>(string indexName, List<T> list)
            where T : class;

        Task BulkDeleteAsync<T>(string indexName, List<T> list) where T : class;

        Task DeleteAsync<T>(string indexName, T model) where T : class;

        Task<ISearchResponse<T>> SearchAsync<T>(
            string indexName,
            SearchDescriptor<T> query = null,
            int skip = 0,
            int size = 20,
            string[] includeFields = null)
            where T : class;
    }
}

