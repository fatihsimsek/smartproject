using System;
namespace SmartProject.Application.Order
{
	public class OrderDto
	{
		public long OrderId { get; set; }
		public long CustomerId { get; set; }
		public long ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal Amount { get; set; }
	}
}

