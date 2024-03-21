using System;
namespace SmartProject.Application.Order
{
	public class OrderCreateDto
	{
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

