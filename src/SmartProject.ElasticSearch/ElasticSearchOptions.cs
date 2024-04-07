using System;
namespace SmartProject.ElasticSearch
{
	public class ElasticSearchOptions
	{
		public required string DefaultIndex { get; set; }
		public required string Url { get; set; }
		public bool AuthenticationRequired { get; set; }
		public string AuthenticationUser { get; set; }
		public string AuthenticationPassword { get; set; }
    }
}

