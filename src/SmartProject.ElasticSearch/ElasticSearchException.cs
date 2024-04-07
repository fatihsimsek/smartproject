using System;
namespace SmartProject.ElasticSearch
{
	public class ElasticSearchException : Exception
	{
		public ElasticSearchException(string message) : base(message)
		{
		}
    }
}

