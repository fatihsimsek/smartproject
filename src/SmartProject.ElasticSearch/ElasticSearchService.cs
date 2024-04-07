using System;
using System.Net;
using Nest;

namespace SmartProject.ElasticSearch
{
	public class ElasticSearchService : IElasticSearchService
	{
		private readonly IElasticClient _elasticClient;

		public ElasticSearchService(IElasticClient elasticClient)
		{
			this._elasticClient = elasticClient;
		}

        public async Task AddOrUpdateAsync<T>(string indexName, T model) where T : class
        {
            var result = await _elasticClient.IndexAsync(model, ss => ss.Index(indexName));

            if (result.ServerError == null)
                return;

            throw new ElasticSearchException($"Index Document failed at index {indexName} :" +
                                             result.ServerError.Error.Reason);
        }

        public async Task BulkAddOrUpdateAsync<T>(string indexName, List<T> list) where T : class
        {
            var bulk = new BulkRequest(indexName)
            {
                Operations = new List<IBulkOperation>()
            };

            foreach (var item in list)
            {
                bulk.Operations.Add(new BulkIndexOperation<T>(item));
            }

            var response = await this._elasticClient.BulkAsync(bulk);

            if (response.Errors)
                throw new ElasticSearchException($"Bulk InsertOrUpdate Document failed at index {indexName} :{response.ServerError.Error.Reason}");
        }

        public async Task BulkDeleteAsync<T>(string indexName, List<T> list) where T : class
        {
            var bulk = new BulkRequest(indexName)
            {
                Operations = new List<IBulkOperation>()
            };

            foreach (var item in list)
            {
                bulk.Operations.Add(new BulkDeleteOperation<T>(new Id(item)));
            }

            var response = await this._elasticClient.BulkAsync(bulk);

            if (response.Errors)
                throw new ElasticSearchException($"Bulk Delete Document at index {indexName} :{response.ServerError.Error.Reason}");
        }

        public async Task DeleteAsync<T>(string indexName, T model) where T : class
        {
            var response = await this._elasticClient.DeleteAsync(new DeleteRequest(indexName, new Id(model)));

            if (response.ServerError == null)
                return;

            throw new Exception($"Delete Document at index {indexName} :{response.ServerError.Error.Reason}");
        }

        public async Task<ISearchResponse<T>> SearchAsync<T>(string indexName, SearchDescriptor<T> query = null, int skip = 0, int size = 20, string[] includeFields = null) where T : class
        {
            if (query == null)
            {
                query = new SearchDescriptor<T>();
            }

            query.Index(indexName);

            query.Skip(skip).Take(size);

            if (includeFields != null)
                query.Source(ss => ss.Includes(ff => ff.Fields(includeFields.ToArray())));

            return await this._elasticClient.SearchAsync<T>(query);
        }
    }
}

