using System;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SmartProject.Domain;
using SmartProject.Domain.Common;
using SmartProject.Infrastructure;

namespace SmartProject.Application.Order
{
	public sealed class GetOrderQuery : Common.Query<Result<OrderDto>>
	{
		public long OrderId { get; set; }
	}

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Result<OrderDto>>
    {
        private readonly IRepository<Domain.Features.Order> _repository;

        public GetOrderQueryHandler(IRepository<Domain.Features.Order> repository)
        {
            this._repository = repository;
        }

        public async Task<Result<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            Domain.Features.Order? order = await this._repository.GetByIdAsync(request.OrderId);

            if (order == null)
                return Result<OrderDto>.Fail();

            return Result<OrderDto>.Success(new OrderDto()
            {
                OrderId = order.Id,
                CustomerId = order.CustomerId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                Amount = order.Amount
            });
        }
    }
}

