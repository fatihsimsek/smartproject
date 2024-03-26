using System;
namespace SmartProject.Redis
{
	public class RedisOptions
	{
		public required string Configuration { get; set; }
		public required string InstanceName { get; set; }
	}
}