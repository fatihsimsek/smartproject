using System;
using MediatR;
using SmartProject.Domain;
using SmartProject.Infrastructure;

namespace SmartProject.Application.Order
{
	public sealed class GetOrderQuery : Common.Query<OrderDto?>
	{
		public long OrderId { get; set; }
	}

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto?>
    {
        private readonly IRepository<Domain.Features.Order> _repository;

        public GetOrderQueryHandler(IRepository<Domain.Features.Order> repository)
        {
            this._repository = repository;
        }

        public async Task<OrderDto?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            Domain.Features.Order? order = await this._repository.GetByIdAsync(request.OrderId);

            if (order == null)
                return null;

            return new OrderDto()
            {
                OrderId = order.Id,
                CustomerId = order.CustomerId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                Amount = order.Amount
            };
        }
    }
}

