using System;
using SmartProject.Domain.Common;

namespace SmartProject.Domain.Features
{
	public class Order : AggregateRoot
    {
		public long CustomerId { get; set; }
		public long ProductId { get; set; }
		public int Quantity { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal Amount { get; set; }
	}
}

