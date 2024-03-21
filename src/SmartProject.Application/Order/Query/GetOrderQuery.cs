using System;
using MediatR;

namespace SmartProject.Application.Order
{
	public sealed record GetOrderQuery : Common.Query<OrderDto>
	{
		public long OrderId { get; set; }
	}

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        public Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

