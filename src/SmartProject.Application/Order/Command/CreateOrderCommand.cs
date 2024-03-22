using System;
using MediatR;
using SmartProject.Application.Common;

namespace SmartProject.Application.Order
{
	public sealed class CreateOrderCommand : Common.Command<Response<long>>
    {
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<long>>
    {
        public Task<Response<long>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

